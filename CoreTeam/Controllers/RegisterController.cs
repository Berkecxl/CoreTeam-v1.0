using Microsoft.AspNetCore.Mvc;
using CoreTeam.Models;

namespace CoreTeam.Controllers
{
    public class RegisterController : Controller
    {
       
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] User registration)
        {
            
            if (_context.Users.Any(u => u.Email == registration.Email))
            {
                return BadRequest("Bu maile kayitli kullanici bulunuyor.");
            }

            try
            {
                var user = new User
                {
                    Email = registration.Email,
                    Name = registration.Name,
                    Surname = registration.Surname,
                    Password = registration.Password,
                };


                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok("Kayit Basariyla Gerceklesti!");
            }
            catch (Exception ex){
            
                return BadRequest(ex.Message);
            
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login ([FromBody] User registration)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == registration.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            if (registration.Password != user.Password)
            {
                return BadRequest("Password is incorrect.");
            }

            return Ok($"Tekrardan Hoşgeldin, {user.Name}! ");
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest crequest)
        {
            UserLoginRequest request = new UserLoginRequest();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == crequest.Email);
            if (user == null)
            {
                return BadRequest("Gecersiz Kullanici");
            }
            
            user.Password = request.Password;
            await _context.SaveChangesAsync();

            return Ok("Sifre Basarili bir sekilde degistirildi");

        }
         
        
    
    }
    
}
