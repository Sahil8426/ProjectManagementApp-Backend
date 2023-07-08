using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Data;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    [ApiController]
    [Route("api/AddUser")]
    public class UserController : Controller


    {
        private readonly UserAPIDbContext userAPIDbContext;

        public UserController(UserAPIDbContext userAPIDbContext)
        {
            this.userAPIDbContext = userAPIDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await userAPIDbContext.AddUsers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = userAPIDbContext.AddUsers.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);


        }






        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var createUser = new CreateUser()
            {

                Id = Guid.NewGuid(),
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                EmployeeID = addUserRequest.EmployeeID,
                

            };

            await userAPIDbContext.AddUsers.AddAsync(createUser);
            await userAPIDbContext.SaveChangesAsync();

            return Ok(createUser);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateUser([FromRoute] Guid id,UpdateUserRequest updateUserRequest)
        {
            var user = userAPIDbContext.AddUsers.Find(id);


            if (user != null)
            {
                user.FirstName = updateUserRequest.FirstName;
                user.LastName = updateUserRequest.LastName; 
                user.EmployeeID = updateUserRequest.EmployeeID;
               

                await userAPIDbContext.SaveChangesAsync();

                return Ok(user);

            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {

            var users = userAPIDbContext.AddUsers.Find(id);

            if (users != null)
            {
                userAPIDbContext.Remove(users);

                await userAPIDbContext.SaveChangesAsync();

                return Ok(users);
            }

            return NotFound();
        }


    }
}
