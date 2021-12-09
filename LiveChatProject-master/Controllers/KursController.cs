using KursProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace KursProject.Controllers
{
    [ApiController]
    [Route("kurs")]
    public class KursController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMessageRepositories _messageRepositories;
        private readonly IEmailService _emailService;
        private readonly IHubContext<MessageHubClient, IMessageHubClient> _messageHub;
        public KursController(
            IConfiguration configuration, 
            IMessageRepositories messageRepositories, 
            IEmailService emailService,
            IHubContext<MessageHubClient, IMessageHubClient> messageHub)
        {
            _configuration = configuration;
            _messageRepositories = messageRepositories;
            _emailService = emailService;
            _messageHub = messageHub;

        }

        [HttpGet]
        [Route("getMessages")]
        public IActionResult GetMessage()
        {
            var messages = _messageRepositories.GetAll();
            var messagesDto = messages.Select(x => new MessageDto
            {
                Content = x.Content,
                FirstName = x.FistNameAuthor,
                LastName = x.LastNameAuthor

            });


            return Ok(messagesDto);
        }

        [HttpPost]
        [Route("sendMessage")]
        public IActionResult SendMessage([FromBody]MessageDto sendMessageDto)
        {
            var messageEntity = new MessageEntity
            {
                Content = sendMessageDto.Content,
                FistNameAuthor = sendMessageDto.FirstName,
                LastNameAuthor = sendMessageDto.LastName,
                CreatedAt = System.DateTime.Now
            };

            //_emailService.SentMessageEmail("wmg30285@boofx.com", sendMessageDto.Content);
            var result = _messageRepositories.Add(messageEntity);

            if (result)
            {
                _messageHub.Clients.All.NewMessage().Wait();
                return Ok(sendMessageDto);
                
            }
            return NotFound();
        }

        //[Authorize("Administrator")]
        [Route("getSecretData")]
        public IActionResult GetSecretData()
        {
            return Ok("Secret data");
        }


    }
}
