public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{FirstName},{LastName},{PhoneNumber},{Email}";
    }

    public static Contact FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        return new Contact
        {
            FirstName = values[0],
            LastName = values[1],
            PhoneNumber = values[2],
            Email = values[3]
        };
    }
}