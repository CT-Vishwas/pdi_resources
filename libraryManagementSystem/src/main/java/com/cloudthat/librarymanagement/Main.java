package com.cloudthat.librarymanagement;

import com.cloudthat.librarymanagement.exceptions.BookAlreadyExistsException;

public class Main {
    public static void main(String[] args) throws BookAlreadyExistsException {

        System.out.println("Welcome to Library Management System");
        Library library = new Library();

        try {
            library.addBook(new Book("1234567", "Introduction to Java", "James Gosling"));
            library.addBook(new Book("1267899", "Introduction to JavaScript", "James"));
            library.addBook(new Book("1278899", "Introduction to Python", "Vishwas"));
            library.addBook(new Book("1345899", "Introduction to HTML", "John"));
            library.addBook(new Book("1234567", "Introduction to Java", "James Gosling"));
        } catch (BookAlreadyExistsException e) {
            System.out.println("Book Already Exists");
        }

        library.displayAllBooks();
        library.findByIsbn("1278899");
        library.findByIsbn("123456789");
        library.findByTitle("Introduction to HTML");


//        Book b1 = new Book("1234567", "Introduction to Java", "James Gosling");
//        System.out.println(b1);

    }
}