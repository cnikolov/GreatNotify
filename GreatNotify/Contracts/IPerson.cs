using System;

namespace GreatNotify.Contracts
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        int Height { get; set; }
    }
}