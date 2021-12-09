using System.Collections.Generic;

namespace KursProject.Domain
{
    public interface IMessageRepositories
    {
        IEnumerable<MessageEntity> GetAll();
        bool Add(MessageEntity message);
        bool Remove(MessageEntity message);
    }
}