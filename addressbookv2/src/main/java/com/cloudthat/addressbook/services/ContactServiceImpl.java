package com.cloudthat.addressbook.services;

import com.cloudthat.addressbook.entities.Contact;
import com.cloudthat.addressbook.entities.Email;
import com.cloudthat.addressbook.entities.Gender;
import com.cloudthat.addressbook.entities.Tag;
import com.cloudthat.addressbook.models.ContactModel;
import com.cloudthat.addressbook.models.EmailModel;
import com.cloudthat.addressbook.models.TagModel;
import com.cloudthat.addressbook.repositories.ContactRepository;
import com.cloudthat.addressbook.repositories.EmailRepository;
import com.cloudthat.addressbook.utilities.GenericConverter;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class ContactServiceImpl implements ContactService{

    private static final Logger logger = LoggerFactory.getLogger(ContactServiceImpl.class);

    @Autowired
    private ContactRepository contactRepository;

    @Autowired
    private EmailRepository emailRepository;


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
        logger.debug("saved contact: {}",savedContact);
        List<Email> emails = savedContact.getEmails();
        for(Email email: emails){
            email.setContact(savedContact);
            emailRepository.save(email);
        }

        return contactConverter.convertToModel(savedContact);
    }

    @Override
    public List<ContactModel> getContactsByGender(Gender gender) {
        return contactConverter.convertToModelList(contactRepository.findByGender(gender));
    }

    @Override
    public Page<ContactModel> getPaginatedData(int page, int size) {
        Pageable pageable = PageRequest.of(page,size);
        Page<Contact> resultPage = contactRepository.findAll(pageable);

        List<ContactModel> contactModels = resultPage.getContent().stream()
                .map(contactConverter::convertToModel)
                .toList();

        return new PageImpl<>(contactModels,pageable, resultPage.getTotalElements());
    }

    private final GenericConverter<Contact, ContactModel> contactConverter = new GenericConverter<Contact, ContactModel>() {
        @Override
        public ContactModel convertToModel(Contact entity) {
            ContactModel contactModel = new ContactModel();
            contactModel.setId(entity.getId());
            contactModel.setName(entity.getName());
            contactModel.setGender(entity.getGender());
            contactModel.setPhoneNumber(entity.getPhoneNumber());
            contactModel.setAddress(entity.getAddress());
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
            contact.setPhoneNumber(Model.getPhoneNumber());
            contact.setAddress(Model.getAddress());
            contact.setTags(tagConverter.convertToEntityList(Model.getTags()));
            contact.setEmails(emailConverter.convertToEntityList(Model.getEmails()));
            return contact;
        }
    };

    private final GenericConverter<Email, EmailModel> emailConverter = new GenericConverter<Email, EmailModel>() {
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

            logger.debug("Email Convert to Entity: {}",email);
            return email;
        }
    };

    private final GenericConverter<Tag, TagModel> tagConverter = new GenericConverter<Tag, TagModel>() {
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
