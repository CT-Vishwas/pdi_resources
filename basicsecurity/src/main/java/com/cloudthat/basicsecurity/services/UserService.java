package com.cloudthat.basicsecurity.services;

import com.cloudthat.basicsecurity.entities.User;
import com.cloudthat.basicsecurity.models.UserModel;

public interface UserService {
    User registerUser(UserModel userModel);
    void saveVerificationTokenForUser(String token, User user);
}
