package com.cloudthat.basicsecurity.controllers;

import com.cloudthat.basicsecurity.entities.User;
import com.cloudthat.basicsecurity.event.RegistrationCompleteEvent;
import com.cloudthat.basicsecurity.models.UserModel;
import com.cloudthat.basicsecurity.services.UserService;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class RegistrationController {

    @Autowired
    private UserService userService;

    @Autowired
    private ApplicationEventPublisher publisher;

    @PostMapping("/register")
    public String registeruser(@RequestBody UserModel userModel, final HttpServletRequest request){
        User user = userService.registerUser(userModel);
        publisher.publishEvent(new RegistrationCompleteEvent(user, applicationUrl(request)));
        return "Success";
    }

    private String applicationUrl(HttpServletRequest request) {
        return "http://"+ request.getServerName()+":"+request.getServerPort()+ request.getContextPath();
    }
}
