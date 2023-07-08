using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Data;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    [ApiController]
    [Route("api/AddTask")]
    public class AddTaskController : Controller
    {
        private readonly AddTaskAPIDbContext addTaskAPIDbContext;

        public AddTaskController(AddTaskAPIDbContext addTaskAPIDbContext)
        {
            this.addTaskAPIDbContext = addTaskAPIDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
          return Ok(await addTaskAPIDbContext.AddTasks.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetTask([FromRoute]Guid id)
        {
            var addtask = addTaskAPIDbContext.AddTasks.Find(id);

            if(addtask == null)
            {
                return NotFound();
            }

            return Ok(addtask);


        }

        [HttpPost]
        public async Task<IActionResult> TaskAdd(AddTaskRequest addTaskRequest)
        {
            var addtask = new AddTask()
            {

                Id = Guid.NewGuid(),
                ProjectName = addTaskRequest.ProjectName,
                TaskName = addTaskRequest.TaskName,
                Priority = addTaskRequest.Priority,
                startdate = addTaskRequest.startdate,
                enddate = addTaskRequest.enddate,

            };

            await addTaskAPIDbContext.AddTasks.AddAsync(addtask);
            await addTaskAPIDbContext.SaveChangesAsync();

            return Ok(addtask);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateTask([FromRoute] Guid id,UpdateTaskRequest updateTaskRequest)
        {
            var addtask = addTaskAPIDbContext.AddTasks.Find(id);


            if (addtask != null)
            {
                addtask.ProjectName = updateTaskRequest.ProjectName;
                addtask.TaskName = updateTaskRequest.TaskName;
                addtask.Priority = updateTaskRequest.Priority;
                addtask.startdate = updateTaskRequest.startdate;
                addtask.enddate = updateTaskRequest.enddate;

               await addTaskAPIDbContext.SaveChangesAsync();

                return Ok(addtask);

            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
        {

            var addtask = addTaskAPIDbContext.AddTasks.Find(id);

            if(addtask != null)
            {
                addTaskAPIDbContext.Remove(addtask);

               await addTaskAPIDbContext.SaveChangesAsync();

                return Ok(addtask);
            }

            return NotFound();
        }

    }
}
