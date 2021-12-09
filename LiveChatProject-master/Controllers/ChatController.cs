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
        
        //[HttpGet]
        //[Route("getCurrentUser")]
        //public async Task<IActionResult> GetCurrentUser()
        //{
        //    var user = await _userManager.GetUserAsync(User);

        //    if(user == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(user);
        //}

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

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        //{
        //    var foundUser = await _userManager.FindByEmailAsync(userLoginDto.Email);

        //    if(foundUser == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(foundUser, userLoginDto.Password, true, false);
        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    return NotFound();

        //}



    }
}
