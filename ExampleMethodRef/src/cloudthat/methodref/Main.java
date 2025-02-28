package cloudthat.methodref;

import java.util.ArrayList;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        ArrayList<UserModel> userModels = new ArrayList<>();
        userModels.add(new UserModel("vishwas","vishwas@cloudthat.com"));
        userModels.add(new UserModel("vishwas1","vishwas1@cloudthat.com"));
        userModels.add(new UserModel("vishwas2","vishwas2@cloudthat.com"));
        userModels.add(new UserModel("vishwas3","vishwas3@cloudthat.com"));
        userModels.add(new UserModel("vishwas4","vishwas4@cloudthat.com"));



        ArrayList<User> users = (ArrayList<User>) userModels.stream()
                .map(UserModel::convertToUser)
                .collect(Collectors.toList());

        System.out.println("Users in the system: ");
        users.forEach(System.out::println);

    }

}
