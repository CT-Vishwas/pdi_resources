package com.cloudthat.addressbook.services;

import com.cloudthat.addressbook.entities.User;
import com.cloudthat.addressbook.models.UserModel;

public interface UserService {
    User registerUser(UserModel userModel);
    void saveVerificationTokenForUser(String token, User user);

    String validateVerificationToken(String token);
}