using System;
using GreatNotify.Models;

namespace GreatNotify
{
    class Program
    {
        static void Main(string[] args)
        {
            var developer = new Person()
            {
                DateOfBirth = new DateTime(1987, 08, 20),
                FirstName = "Christian",
                LastName = "Nikolov",
                Height = 187,
                Id = 35
            };
            var headOfRecruitment = new Person()
            {
                DateOfBirth = new DateTime(1991, 05, 02),
                FirstName = "Radostina",
                LastName = "Maneva",
                Height = 173,
                Id = 1
            };
            var chatRoom = new ChatRoom();
            var subscriber = new Subscriber("Jonathan Green");
            chatRoom.Publish += subscriber.Notify;
            chatRoom.Schedule(10000);
            chatRoom.Add(developer);
            chatRoom.Add(headOfRecruitment);
            chatRoom.Remove(developer);
            Console.ReadLine();
        }
    }
}
