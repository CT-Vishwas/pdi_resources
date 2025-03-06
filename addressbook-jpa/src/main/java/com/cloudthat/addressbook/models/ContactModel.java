package com.cloudthat.addressbook.models;

import com.cloudthat.addressbook.entities.Address;
import com.cloudthat.addressbook.entities.Email;
import com.cloudthat.addressbook.entities.Gender;
import com.cloudthat.addressbook.entities.Tag;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import org.hibernate.annotations.CreationTimestamp;
import org.hibernate.annotations.UpdateTimestamp;
import org.hibernate.type.TrueFalseConverter;

import java.time.Instant;
import java.util.ArrayList;
import java.util.List;

public class ContactModel {
    private Long id;
    @NotBlank
    @Size(min = 3, max = 30, message = "Name must be between 3 & 30 characters")
    private String name;
    @NotBlank
    @Size(min = 10, max = 10, message = "Phone Number must be 10 characters")
    private String phoneNumber;
    @NotNull(message = "Gender cannot be null")
    private Gender gender;
    private Address address;
    private boolean isActive;
    private List<Email> emails = new ArrayList<>();
    private List<Tag> tags = new ArrayList<>();

    public ContactModel() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public Gender getGender() {
        return gender;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }

    public List<Email> getEmails() {
        return emails;
    }

    public void setEmails(List<Email> emails) {
        this.emails = emails;
    }

    public List<Tag> getTags() {
        return tags;
    }

    public void setTags(List<Tag> tags) {
        this.tags = tags;
    }
}
