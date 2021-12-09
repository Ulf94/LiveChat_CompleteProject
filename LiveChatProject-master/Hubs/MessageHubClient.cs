using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace KursProject
{
    public class MessageHubClient : Hub<IMessageHubClient>
    {
    }
}
