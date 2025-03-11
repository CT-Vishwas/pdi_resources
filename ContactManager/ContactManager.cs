using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ContactManager
{
    private readonly string _filePath;
    private List<Contact> _contacts;

    public ContactManager(string filePath)
    {
        _filePath = filePath;
        _contacts = LoadContacts();
    }

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
        SaveContacts();
    }

    public List<Contact> GetContacts()
    {
        return _contacts;
    }

    public Contact FindContact(string firstName, string lastName)
    {
        return _contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
    }

    public void RemoveContact(string firstName, string lastName)
    {
        _contacts.RemoveAll(c => c.FirstName == firstName && c.LastName == lastName);
        SaveContacts();
    }

    private List<Contact> LoadContacts()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Contact>();
        }

        try
        {
            return File.ReadAllLines(_filePath)
                .Skip(1) // Skip header
                .Select(Contact.FromCsv)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts: {ex.Message}");
            return new List<Contact>();
        }
    }

    private void SaveContacts()
    {
        try
        {
            var lines = new List<string> { "FirstName,LastName,PhoneNumber,Email" };
            lines.AddRange(_contacts.Select(c => c.ToString()));
            File.WriteAllLines(_filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving contacts: {ex.Message}");
        }
    }
}