package com.cloudthat.departments.models;

import com.fasterxml.jackson.annotation.JsonFormat;
import org.springframework.http.HttpStatus;
import java.util.Date;

public class ErrorResponse {
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "dd-MM-yyyy hh:mm:ss")
    private Date timestamp;

    private HttpStatus httpStatus;

    private String status;

    private String message;

    private String stackTrace;

    private Object data;

    private Boolean success = false;

    public ErrorResponse(HttpStatus httpStatus, String message, Boolean success) {
        this.httpStatus = httpStatus;
        this.message = message;
        this.success = success;
    }

    public ErrorResponse(HttpStatus httpStatus, String message) {
        this.httpStatus = httpStatus;
        this.message = message;
    }

    public ErrorResponse(HttpStatus httpStatus, String message, String stackTrace) {
        this.httpStatus = httpStatus;
        this.message = message;
        this.stackTrace = stackTrace;
    }
}
