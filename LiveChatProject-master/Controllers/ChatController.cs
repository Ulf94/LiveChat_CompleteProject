using KursProject.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KursProject
{
    public class ChatController : ControllerBase
    {


        private readonly IMessageRepositories _messageRepositories;

        public ChatController(IMessageRepositories messageRepositories)
        {

            _messageRepositories = messageRepositories;
        }

        [HttpPost]
        [Route("chat_ctrl")]
        public async Task<IActionResult> Chat([FromBody] MessageDto messageText)
        {
            var messageEntity = new MessageEntity
            {
                Content = messageText.Content,
                CreatedAt = System.DateTime.Now

            };
            var result = _messageRepositories.Add(messageEntity);

            if (result) return Ok(messageText);

            return NotFound();

        }
    }
}
