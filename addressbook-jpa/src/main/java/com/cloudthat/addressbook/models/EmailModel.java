package com.cloudthat.addressbook.models;

public class EmailModel {
    private Long id;
    private String emailAddress;
    private Long contact;

    public EmailModel() {
    }

    public EmailModel(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    @Override
    public String toString() {
        return "EmailModel{" +
                "id=" + id +
                ", emailAddress='" + emailAddress + '\'' +
                '}';
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getEmailAddress() {
        return emailAddress;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    public Long getContact() {
        return contact;
    }

    public void setContact(Long contact) {
        this.contact = contact;
    }
}
