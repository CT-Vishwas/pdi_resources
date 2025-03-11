// Program.cs
using System;

public class Program
{
    public static void Main(string[] args)
    {
        var contactManager = new ContactManager("contacts.csv");

        while (true)
        {
            Console.WriteLine("\nContact Manager");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Find Contact");
            Console.WriteLine("4. Remove Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact(contactManager);
                    break;
                case "2":
                    ViewContacts(contactManager);
                    break;
                case "3":
                    FindContact(contactManager);
                    break;
                case "4":
                    RemoveContact(contactManager);
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void AddContact(ContactManager contactManager)
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };

        contactManager.AddContact(contact);
        Console.WriteLine("Contact added.");
    }

    private static void ViewContacts(ContactManager contactManager)
    {
        var contacts = contactManager.GetContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        Console.WriteLine("\nContacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    private static void FindContact(ContactManager contactManager)
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        var contact = contactManager.FindContact(firstName, lastName);
        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
        }
        else
        {
            Console.WriteLine(contact);
        }
    }

    private static void RemoveContact(ContactManager contactManager)
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        contactManager.RemoveContact(firstName, lastName);
        Console.WriteLine("Contact removed (if found).");
    }
}