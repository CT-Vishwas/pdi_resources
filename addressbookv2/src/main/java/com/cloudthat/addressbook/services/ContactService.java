package com.cloudthat.addressbook.services;

import com.cloudthat.addressbook.entities.Gender;
import com.cloudthat.addressbook.models.ContactModel;
import jakarta.validation.Valid;
import org.springframework.data.domain.Page;

import java.util.List;
import java.util.Optional;

public interface ContactService {

    List<ContactModel> getAllContacts();

    Optional<ContactModel> getContactById(Long id);

    ContactModel createContact(@Valid ContactModel contactModel);

    List<ContactModel> getContactsByGender(Gender gender);

    Page<ContactModel> getPaginatedData(int page, int size);
}
