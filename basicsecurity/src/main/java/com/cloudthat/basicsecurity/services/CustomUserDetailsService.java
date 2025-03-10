package com.cloudthat.basicsecurity.services;


import com.cloudthat.basicsecurity.entities.CustomUserDetails;
import com.cloudthat.basicsecurity.entities.User;
import com.cloudthat.basicsecurity.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class CustomUserDetailsService implements UserDetailsService {
	@Autowired
	private UserRepository userRepository;
	
	@Override
	public UserDetails loadUserByUsername(String emailId) throws UsernameNotFoundException {
		User user;
		// TODO Auto-generated method stub
		try {
			user = userRepository.findByEmail(emailId);
		} catch (Exception e) {
			// TODO: handle exception
			throw new UsernameNotFoundException("User Name Not Found");
		}
		return new CustomUserDetails(user);
	}

}
