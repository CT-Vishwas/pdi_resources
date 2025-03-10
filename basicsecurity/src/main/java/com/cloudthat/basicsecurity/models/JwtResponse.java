package com.cloudthat.basicsecurity.models;

public class JwtResponse {

    private String jwtToken;
    private String message;
    private Boolean success;
    private String email;
    private String role;

    public JwtResponse() {
    }

    public JwtResponse(String jwtToken, String message, Boolean success, String email, String role) {
        this.jwtToken = jwtToken;
        this.message = message;
        this.success = success;
        this.email = email;
        this.role = role;
    }

    public String getJwtToken() {
        return jwtToken;
    }

    public void setJwtToken(String jwtToken) {
        this.jwtToken = jwtToken;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Boolean getSuccess() {
        return success;
    }

    public void setSuccess(Boolean success) {
        this.success = success;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }
}
