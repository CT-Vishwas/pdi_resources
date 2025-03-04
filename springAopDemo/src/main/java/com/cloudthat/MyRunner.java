package com.cloudthat;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class MyRunner implements CommandLineRunner {

    @Autowired
    private MyService myService;

    @Override
    public void run(String... args) throws Exception {
        myService.doSomething("Hello, AOP!");
        myService.calculate(5, 10);
        myService.doAnotherThing();
    }
}
