package com.cloudthat.addressbook.controllers;

import com.cloudthat.addressbook.models.ApiResponse;
import com.cloudthat.addressbook.models.ContactModel;
import com.cloudthat.addressbook.models.ErrorResponse;
import com.cloudthat.addressbook.services.ContactService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/contacts")
public class ContactController {

    @Autowired
    private ContactService contactService;

    @GetMapping
    public ResponseEntity<ApiResponse> getAllContacts(){
        List<ContactModel> contactModels = contactService.getAllContacts();
        return ResponseEntity.ok(new ApiResponse<>("Contacts fetched", true,contactModels));
    }

    @GetMapping("/{id}")
    public ResponseEntity<ApiResponse> getContactById(@PathVariable Long id){
        ContactModel contactModel = contactService.getContactById(id);
        return ResponseEntity.ok(new ApiResponse<>("Contacts fetched", true,contactModel));
    }

    @PostMapping
    public ResponseEntity<?> createContact(@Valid @RequestBody ContactModel contactModel, BindingResult bindingResult){
        if(bindingResult.hasErrors()){
            return ResponseEntity.badRequest().body(new ErrorResponse(HttpStatus.BAD_REQUEST, "Cannot create Contact","", bindingResult.getFieldErrors()));
        }

        ContactModel newContactModel = contactService.createContact(contactModel);
        return ResponseEntity.status(HttpStatus.CREATED).body(new ApiResponse<>("Contacts fetched", true,newContactModel));
    }


}
