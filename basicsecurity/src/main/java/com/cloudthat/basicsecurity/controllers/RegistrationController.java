package com.cloudthat.basicsecurity.controllers;

import com.cloudthat.basicsecurity.entities.User;
import com.cloudthat.basicsecurity.event.RegistrationCompleteEvent;
import com.cloudthat.basicsecurity.models.JwtRequest;
import com.cloudthat.basicsecurity.models.JwtResponse;
import com.cloudthat.basicsecurity.models.UserModel;
import com.cloudthat.basicsecurity.services.CustomUserDetailsService;
import com.cloudthat.basicsecurity.services.UserService;
import com.cloudthat.basicsecurity.services.UserServiceImpl;
import com.cloudthat.basicsecurity.utilities.JWTUtility;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.*;



@RestController
public class RegistrationController {

    @Autowired
    private CustomUserDetailsService userDetailsService;

    @Autowired
    private ApplicationEventPublisher publisher;

    @Autowired
    private UserService userService;

    @Autowired
    private AuthenticationManager authenticationProvider;

    @Autowired
    private JWTUtility jwtUtility;

    @PostMapping("/register")
    public String registeruser(@RequestBody UserModel userModel, final HttpServletRequest request){
        User user = userService.registerUser(userModel);
        publisher.publishEvent(new RegistrationCompleteEvent(user, applicationUrl(request)));
        return "Success";
    }

    @GetMapping("/verifyRegistration")
    public String verifyRegistration(@RequestParam("token") String token) {
        String result = userService.validateVerificationToken(token);
        if(result.equalsIgnoreCase("valid")) {
            return "User verified Succesfully";
        }
        return "Bad user";

    }

    private String applicationUrl(HttpServletRequest request) {
        return "http://"+ request.getServerName()+":"+request.getServerPort()+ request.getContextPath();
    }

    @PostMapping("/login")
    public ResponseEntity<JwtResponse> authenticate(@RequestBody JwtRequest jwtRequest) throws Exception{
        UsernamePasswordAuthenticationToken unauthenticatedToken = UsernamePasswordAuthenticationToken.unauthenticated(
                jwtRequest.getUsername(), jwtRequest.getPassword());
        try {
            authenticationProvider.authenticate(
                    unauthenticatedToken
            );
        } catch (BadCredentialsException e) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,e.getMessage(),false,null,null), HttpStatus.UNAUTHORIZED);
        }catch(NullPointerException ex) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,"User Name Not Found",false,null,null),HttpStatus.UNAUTHORIZED);
        }catch(DisabledException ex) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,"User Account is disabled",false,null,null),HttpStatus.UNAUTHORIZED);
        }

        final UserDetails userDetails
                = userDetailsService.loadUserByUsername(jwtRequest.getUsername());

        final String token =
                jwtUtility.generateToken(userDetails);

        return new ResponseEntity<JwtResponse>(new JwtResponse(token,"Token generated Successfully",true, userDetails.getUsername(),userDetails.getAuthorities().iterator().next().toString()),HttpStatus.OK);
    }
}
