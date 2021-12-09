using System;
using System.Runtime.InteropServices;

namespace KursProject.Domain
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
