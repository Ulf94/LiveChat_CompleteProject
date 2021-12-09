using System;

namespace KursProject.Domain
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FistNameAuthor { get; set; }
        public string LastNameAuthor { get; set; }
        public DateTime CreatedAt{ get; set; }
    }
}
