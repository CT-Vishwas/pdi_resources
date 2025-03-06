package com.cloudthat.addressbook.services;

import com.cloudthat.addressbook.entities.Contact;
import com.cloudthat.addressbook.entities.Email;
import com.cloudthat.addressbook.entities.Tag;
import com.cloudthat.addressbook.models.ContactModel;
import com.cloudthat.addressbook.models.EmailModel;
import com.cloudthat.addressbook.models.TagModel;
import com.cloudthat.addressbook.repositories.ContactRepository;
import com.cloudthat.addressbook.utilities.GenericConverter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ContactServiceImpl implements ContactService{

    @Autowired
    private ContactRepository contactRepository;

    @Override
    public List<ContactModel> getAllContacts() {
        return contactConverter.convertToModelList(contactRepository.findAll());
    }

    @Override
    public Optional<ContactModel> getContactById(Long id) {
        return contactRepository.findById(id).map(contactConverter::convertToModel);
    }

    @Override
    public ContactModel createContact(ContactModel contactModel) {
        Contact contact = contactConverter.convertToEntity(contactModel);
        Contact savedContact = contactRepository.save(contact);
        return contactConverter.convertToModel(savedContact);
    }

    private GenericConverter<Contact, ContactModel> contactConverter = new GenericConverter<Contact, ContactModel>() {
        @Override
        public ContactModel convertToModel(Contact entity) {
            ContactModel contactModel = new ContactModel();
            contactModel.setId(entity.getId());
            contactModel.setName(entity.getName());
            contactModel.setGender(entity.getGender());
            contactModel.setEmails(emailConverter.convertToModelList(entity.getEmails()));
            contactModel.setTags(tagConverter.convertToModelList(entity.getTags()));


            return contactModel;
        }

        @Override
        public Contact convertToEntity(ContactModel Model) {
            Contact contact = new Contact();
            contact.setId(Model.getId());
            contact.setName(Model.getName());
            contact.setGender(Model.getGender());
            contact.setEmails(emailConverter.convertToEntityList(Model.getEmails()));
            contact.setTags(tagConverter.convertToEntityList(Model.getTags()));

            return contact;
        }
    };

    private GenericConverter<Email, EmailModel> emailConverter = new GenericConverter<Email, EmailModel>() {
        @Override
        public EmailModel convertToModel(Email entity) {
            EmailModel model = new EmailModel();
            model.setId(entity.getId());
            model.setEmailAddress(entity.getEmailAddress());

            return model;
        }

        @Override
        public Email convertToEntity(EmailModel Model) {
            Email email = new Email();
            email.setId(Model.getId());
            email.setEmailAddress(Model.getEmailAddress());

            return email;
        }
    };

    private GenericConverter<Tag, TagModel> tagConverter = new GenericConverter<Tag, TagModel>() {
        @Override
        public TagModel convertToModel(Tag entity) {
            TagModel model = new TagModel();
            model.setId(entity.getId());
            model.setName(entity.getName());

            return model;
        }

        @Override
        public Tag convertToEntity(TagModel Model) {
            Tag tag = new Tag();
            tag.setId(Model.getId());
            tag.setName(Model.getName());

            return tag;
        }
    };
}
