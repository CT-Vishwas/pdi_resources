package com.cloudthat.scansum;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Locale;
import java.util.Scanner;

import static java.util.Locale.US;

public class Main {
    public static void main(String[] args) {
        System.out.println("Welcome to Scan Sum Program");

        Scanner scanner = null;
        Double sumValue = 0.0;

        try {
            scanner = new Scanner(new BufferedReader(new FileReader("C:\\Users\\VishwasKSingh\\deloitte-workspace\\demos\\scansum\\src\\com\\cloudthat\\scansum\\numbers.txt")));
//            scanner.locale(US);

            while (scanner.hasNext()){
                if(scanner.hasNextDouble()){
                    sumValue += scanner.nextDouble();
                }else {
                    scanner.next();
                }
            }
        } catch (FileNotFoundException e) {
            System.out.println("Numbers file is not found");
        }

        System.out.printf("Sum is %.2f",sumValue);
    }
}