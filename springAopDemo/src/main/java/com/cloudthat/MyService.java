package com.cloudthat;

import org.springframework.stereotype.Service;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@Service
class MyService {

    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    public void doSomething(String message) {
        logger.info("Doing something with message: {}", message);
    }

    public int calculate(int a, int b) {
        logger.info("Calculating {} + {}", a,b);
        return a + b;
    }

    public void doAnotherThing(){
        logger.info("Doing another thing");
    }
}
