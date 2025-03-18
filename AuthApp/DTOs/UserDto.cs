using System;

namespace AuthApp.DTOs;

public class UserDto
{
    public required string Username {get; set;}
    public required string Password { get; set;}

    public required string Role { get; set;}
}
