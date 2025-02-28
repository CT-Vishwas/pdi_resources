package cloudthat.addressbook;

public class Main {
    public static void main(String[] args) {
        AddressManager addressManager = new AddressManager();
        Contact c = new Contact(1,"vishwas","vishwas@clouthat.com");
        System.out.println(c.getId());
        System.out.println("name: "+ c.getName());
        System.out.println("Email: "+ c.getEmail());

        try {
            addressManager.addContact(c);
            addressManager.addContact(new Contact(2,"Arjun","arjun@cloudthat.com"));

            addressManager.addContact(new Contact(2,"Arjun","arjun@cloudthat.com"));
        } catch (ContactExistsException e) {
            System.out.println("Cannot add the contact, as it already exists in addressbook");
        }

        System.out.println("Contacts in address book are: ");
        addressManager.displayAllContacts();

    }
}
