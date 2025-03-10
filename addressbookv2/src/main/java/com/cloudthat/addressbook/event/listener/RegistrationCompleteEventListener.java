package com.cloudthat.addressbook.event.listener;


import com.cloudthat.addressbook.entities.User;
import com.cloudthat.addressbook.event.RegistrationCompleteEvent;
import com.cloudthat.addressbook.services.UserService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationListener;
import org.springframework.stereotype.Component;

import java.util.UUID;


@Component
public class RegistrationCompleteEventListener  implements ApplicationListener<RegistrationCompleteEvent> {
    @Autowired
    private UserService userService;


    private Logger log =  LoggerFactory.getLogger(RegistrationCompleteEventListener.class);

    @Override
    public void onApplicationEvent(RegistrationCompleteEvent event) {
        // TODO Auto-generated method stub
        // Create verification token for user with link
        User user = event.getUser();
        String token = UUID.randomUUID().toString();
        userService.saveVerificationTokenForUser(token, user);
        //Send email
        String url = event.getApplicationUrl()+ "/verifyRegistration?token="+token;
        // just mimicking email sending here
        log.info("URL link to verify: {}",url);
    }
}