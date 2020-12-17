using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly UserDb _userDb;

        public UsersController(UserDb userDb)
        {
            _userDb = userDb;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            
            return Ok(await _userDb.GetALL());
            
        }

        [HttpGet("{username}")]

        public async Task<ActionResult <User>> GetUser(string username)
        {
            return await _userDb.GetbyUserName(username);
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
