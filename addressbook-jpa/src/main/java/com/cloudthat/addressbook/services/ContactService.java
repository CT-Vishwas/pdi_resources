package com.cloudthat.addressbook.services;

import com.cloudthat.addressbook.models.ContactModel;
import jakarta.validation.Valid;

import java.util.List;
import java.util.Optional;

public interface ContactService {

    List<ContactModel> getAllContacts();

    Optional<ContactModel> getContactById(Long id);

    ContactModel createContact(@Valid ContactModel contactModel);
}
