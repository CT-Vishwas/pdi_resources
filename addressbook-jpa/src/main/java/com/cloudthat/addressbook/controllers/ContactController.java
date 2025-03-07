package com.cloudthat.addressbook.controllers;

import com.cloudthat.addressbook.entities.Gender;
import com.cloudthat.addressbook.models.ApiResponse;
import com.cloudthat.addressbook.models.ContactModel;
import com.cloudthat.addressbook.models.ErrorResponse;
import com.cloudthat.addressbook.services.ContactService;
import com.cloudthat.addressbook.services.ContactServiceImpl;
import jakarta.validation.Valid;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/contacts")
public class ContactController {

    private static final Logger logger = LoggerFactory.getLogger(ContactController.class);
    @Autowired
    private ContactService contactService;

    @GetMapping
    public ResponseEntity<ApiResponse> getAllContacts(){
        List<ContactModel> contactModels = contactService.getAllContacts();
        return ResponseEntity.ok(new ApiResponse("Contacts fetched", true,contactModels));
    }

    @GetMapping("/{id}")
    public ResponseEntity<ApiResponse> getContactById(@PathVariable Long id){
        Optional<ContactModel> contactModel = contactService.getContactById(id);
        return ResponseEntity.ok(new ApiResponse("Contacts fetched", true,contactModel));
    }

    @PostMapping
    public ResponseEntity<?> createContact(@Valid @RequestBody ContactModel contactModel, BindingResult bindingResult){
        if(bindingResult.hasErrors()){
            return ResponseEntity.badRequest().body(new ErrorResponse(HttpStatus.BAD_REQUEST, "Cannot create Contact","", bindingResult.getFieldErrors()));
        }
        logger.debug("ContactController Create Contact: {}",contactModel);
        ContactModel newContactModel = contactService.createContact(contactModel);
        return ResponseEntity.status(HttpStatus.CREATED).body(new ApiResponse("Contacts fetched", true,newContactModel));
    }

    @GetMapping("/search")
    public ResponseEntity<ApiResponse> getContactsByGender(@RequestParam(value = "gender", defaultValue = "MALE") Gender gender){
        List<ContactModel> contactModels = contactService.getContactsByGender(gender);
        return ResponseEntity.ok(new ApiResponse("Contacts fetched", true,contactModels));
    }

    @GetMapping("/paginated")
    public ResponseEntity<ApiResponse> getPaginatedData(@RequestParam(defaultValue = "0") int page,@RequestParam(defaultValue = "2") int size ){
        Page<ContactModel> contactModels = contactService.getPaginatedData(page, size);
        return ResponseEntity.ok(new ApiResponse("Contacts fetched", true,contactModels));
    }


}
