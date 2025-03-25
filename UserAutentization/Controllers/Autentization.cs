using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UserAutentization.Data;



namespace UserAutentization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Autentization : Controller
    {
        private readonly ILogger<Autentization> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Autentization(
            ILogger<Autentization> logger,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            
            )
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       

        [HttpPost(Name = "Autentize")]
        public ActionResult<UserInfoDto> Autentize(LoginData loginData)
        {
            
            var user = _userManager.FindByNameAsync(loginData.Username).Result;

            if (user == null) { return NotFound(); }
            
            
            var roles= _userManager.GetRolesAsync(user).Result;
            if (roles==null) { return NotFound(); }
            _logger.LogInformation("{roles}",roles);
            
            var result=_userManager.CheckPasswordAsync(user,loginData.Password).Result;
            UserInfoDto userInfo = new UserInfoDto
            {
                UserName = user.UserName,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                PersonRoles = roles.ToList()

            };
            if (result)
            {
                return Ok(userInfo);
                

            }
            return NotFound();

           
           

            
            



            
            
            
        }

    }
}
