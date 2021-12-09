using KursProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KursProject.Database
{
    public class MessageRepositories : IMessageRepositories
    {
        private DbSet<MessageEntity> _messages { get; set; }
        private ApplicationDbContext _dbContext;
        public MessageRepositories(ApplicationDbContext dbContext)
        {
            _messages = dbContext.Message;
            _dbContext = dbContext;
        }
        public bool Add(MessageEntity message)
        {
            _messages.Add(message);
            return _dbContext.SaveChanges() > 0;

        }
        public bool Remove(MessageEntity message)
        {
            _messages.Remove(message);
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return _messages.ToList();
        }

    }
}
