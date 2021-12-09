using System.Threading.Tasks;

namespace KursProject
{
    public interface IMessageHubClient
    {
        Task NewMessage();
    }
}
