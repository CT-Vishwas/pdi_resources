package com.cloudthat.consoleexample;

import java.io.Console;

public class Main {
    public static void main(String[] args) {

        Console c = System.console();

        if (c == null) {
            System.err.println("No Console");
            System.exit(1);
        }

        String login = c.readLine("Enter your login: ");
        char[] oldPassword = c.readPassword("Enter your old password: ");

        System.out.println("The password length is: "+ oldPassword.length);


    }
    static boolean verify(String login, char[] password){
        return true;
    }
}