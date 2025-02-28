package com.cloudthat.librarymanagement;

import com.cloudthat.librarymanagement.exceptions.BookAlreadyExistsException;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Library {

    private Map<String, Book> books;
    private static Set<String> bookIsbns;

    public Library() {
        books = new HashMap<>();
        bookIsbns = new HashSet<>();
    }

    public void addBook(Book book) throws BookAlreadyExistsException {
        if(!bookIsbns.contains(book.getIsbn())){
            books.put(book.getIsbn(), book);
            bookIsbns.add(book.getIsbn());
        } else{
//            System.out.println("Duplicate book found");
            throw new BookAlreadyExistsException("Book with ISBN "+book.getIsbn() + " already exists");
        }

    }

    // Implement methods for removing a book & displayAllBooks
    public void  removeBook(String isbn){
        if(books.containsKey(isbn)){
            Book removedBook = books.remove(isbn);
            System.out.println(" Removed: "+ removedBook);
        }else{
            System.out.println("No book with ISBN: "+ isbn+ "is found");
        }
    }

    public void displayAllBooks(){
        if(books.isEmpty()){
            System.out.println(" No Books in the library. ");
        } else{
            System.out.println("Books in the library: ");
            books.forEach((isbn,book) -> System.out.println(book));
        }
    }

    public void findByIsbn(String isbn){
        Book book = books.get(isbn);
        if(book != null){
            System.out.println("Book Found: ");
            System.out.println(book);
        } else{
            System.out.println("Book Not Found!");
        }
    }

    public void findByTitle(String title){
        for (Map.Entry<String, Book> entry: books.entrySet()){
            if(entry.getValue().getTitle().equals(title)){
                System.out.println("Book Found");
                System.out.println(entry.getValue());
            } else {
                System.out.println("Book not found");
            }
        }
    }
}
