package com.cloudthat;

import org.aspectj.lang.annotation.Aspect;
import org.springframework.stereotype.Component;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.After;
import org.aspectj.lang.annotation.Before;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@Aspect
@Component
public class LoggingAspect {
    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    @Before("execution(* com.cloudthat.MyService.*(..))")
    public void logBefore(JoinPoint joinPoint) {
        logger.info("Before executing: {}", joinPoint.getSignature().toShortString());
        Object[] args = joinPoint.getArgs();
        if (args != null && args.length > 0) {
            logger.info("Arguments: {}", args);
        }
    }

    @After("execution(* com.cloudthat.MyService.*(..))")
    public void logAfter(JoinPoint joinPoint) {
        logger.info("After executing: {}", joinPoint.getSignature().toShortString());
    }
}
