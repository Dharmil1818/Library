using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using BOL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        private ICommentRepository _commentRepository;

        public UsersController(IUserRepository userRepository, ICommentRepository commentRepository)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }


        //api/users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(400)]

        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usersDto = new List<UserDto>();

            foreach(var user in users)
            {
                usersDto.Add(new UserDto
                { 
                     UserId = user.UserId,
                     UserName = user.UserName,
                     CreatedDate = user.CratedDate
                });
            }
            return Ok(usersDto);
        }

        //api/users/userId
        [HttpGet("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(UserDto))]

        public IActionResult GetLocation(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var user = _userRepository.GetUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userDto = new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                CreatedDate = user.CratedDate
            };

            return Ok(userDto);
        } 

        //api/users/userId/comments
        [HttpGet("{userId}/comments")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]
        public IActionResult GetCommentsByUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var comments = _userRepository.GetCommentsByUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentsDto = new List<CommentDto>();

            foreach(var comment in comments)
            {
                commentsDto.Add(new CommentDto
                { 
                CommentId = comment.CommentId,
                Desscription = comment.Description,
                CreatedDate = comment.CreatedDate,
                ModifiedDate = comment.ModifiedDate
                });
            }

            return Ok(commentsDto);
        }
        // TO DO- after implementing ICommentRepository
        //api/users/commentId/user
        [HttpGet("{commentId}/user")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public IActionResult GetUserOfAComment(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            var user = _userRepository.GetUserOfAComment(commentId);
            
            if (!ModelState.IsValid)
                return BadRequest();

            var userDto = new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                CreatedDate = user.CratedDate
            };
            return Ok(userDto);

        }





    }
}
    //    UserManager<User> userManager;
    //    SignInManager<User> SignInManager;

    //    public UsersController(SignInManager<User> _signInManager, UserManager<User> _userManager)
    //    {
    //        SignInManager = _signInManager;
    //        userManager = _userManager;
    //    }

    //    [HttpPost("register")]

    //    public async Task<IActionResult> Register(RegisterViewModel model)
    //    {
    //        try 
    //        { 
    //        if(ModelState.IsValid)
    //            {
    //                var user = new User()
    //                {
    //                    UserName = model.UserName,
    //                    CratedDate = model.CreatedDate
    //                };

    //                var userResult = await userManager.CreateAsync(user);
    //                if(userResult.Succeeded)
    //                {
    //                    var roleResult = await userManager.AddToRoleAsync(user, "User");
    //                    if (roleResult.Succeeded)
    //                    {
    //                        return Ok(user);
    //                    }                    
    //                }
    //              else
    //              {
    //                foreach (var item in userResult.Errors)
    //                {
    //                    ModelState.AddModelError(item.Code, item.Description);
    //                }
    //              }
    //          }
    //            return BadRequest(ModelState.Values);
    //        }
    //        catch (Exception)
    //        {
    //            return StatusCode(500, "Internal Server Error!");
    //        }
    //    }
