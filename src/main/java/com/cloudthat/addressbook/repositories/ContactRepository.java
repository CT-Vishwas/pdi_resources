package com.cloudthat.addressbook.repositories;

import com.cloudthat.addressbook.entities.Contact;
import com.cloudthat.addressbook.entities.Gender;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ContactRepository extends JpaRepository<Contact, Long> {
    List<Contact> findByGender(Gender gender);
}
