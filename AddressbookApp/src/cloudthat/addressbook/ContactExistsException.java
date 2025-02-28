package cloudthat.addressbook;

public class ContactExistsException extends RuntimeException {
    public ContactExistsException(String message) {
        super(message);
    }
}
