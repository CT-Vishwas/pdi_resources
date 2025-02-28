package cloudthat.addressbook;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Optional;

public class AddressManager {

    private ArrayList<Contact> addressbook ;
    private HashSet<Integer> contactIds;

    public AddressManager() {
        this.addressbook = new ArrayList<Contact>();
        this.contactIds = new HashSet<>();
    }

    public Contact addContact(Contact contact){

//        if(findContact(contact.getId()) != null){
//            throw new ContactExistsException("Contact with id "+contact.getId()+" already exists");
//        }
        Optional<Contact> existingContact = findContact(contact.getId());
        if(existingContact != null){
            if(contact.equals(existingContact)){
                throw new ContactExistsException("Contact with id "+contact.getId()+" already exists");
            }
        }
        this.addressbook.add(contact);
        this.contactIds.add(contact.getId());
        return contact;
    }

    public String removeContact(int id){
        Contact availableContact=null;
        for(Contact c: this.addressbook){
            if(c.getId() == id){
                availableContact = c;
            }
        }
        this.addressbook.remove(availableContact);
        this.contactIds.remove(availableContact.getId());
        return "Contact Removed Successfully";
    }

    public Optional<Contact> findContact(int id){
//        for(Contact c: this.addressbook) {
//            if (c.getId() == id) {
//                return c;
//            }
//        }

        return  this.addressbook.stream()
                .filter(contact -> contact.getId() == id)
                .findFirst();

    }

    public Optional<Contact> findContact(String name){
        return this.addressbook
                .stream()
                .filter(contact ->  contact.getName().equalsIgnoreCase(name))
                .findAny();
    }

    public void displayAllContacts(){
        for(Contact c: this.addressbook){
            System.out.println(c);
        }
    }
}
