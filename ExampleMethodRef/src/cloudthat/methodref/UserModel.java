package cloudthat.methodref;

import java.util.UUID;

public class UserModel {
    String name;
    String email;

    public UserModel() {
    }

    public UserModel(String name, String email) {
        this.name = name;
        this.email = email;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String toString() {
        return "UserModel{" +
                "name='" + name + '\'' +
                ", email='" + email + '\'' +
                '}';
    }

    public static User convertToUser(UserModel userModel){
        User user = new User();
        user.setId(UUID.randomUUID());
        user.setName(userModel.getName());
        user.setEmail(userModel.getEmail());

        return user;
    }
}
