using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Data;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly ProjectsAPIDbcontext projectsAPIDbcontext;

        public ProjectsController(ProjectsAPIDbcontext projectsAPIDbcontext)
        {
            this.projectsAPIDbcontext = projectsAPIDbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
           return Ok(await projectsAPIDbcontext.Createprojects.ToListAsync());
            return View();
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetProject([FromRoute] Guid id)
        {
            var project = projectsAPIDbcontext.Createprojects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);


        }

        [HttpPost]
        

        public async Task<IActionResult>AddProject(AddProjectRequest addProjectRequest)
        {

            var project = new CreateProject()
            {
                Id = Guid.NewGuid(),
                ProjectName = addProjectRequest.ProjectName,
                Priority = addProjectRequest.Priority,
                ManagerName = addProjectRequest.ManagerName,
                startdate = addProjectRequest.startdate

            };

           await projectsAPIDbcontext.Createprojects.AddAsync(project);
            await projectsAPIDbcontext.SaveChangesAsync();

            return Ok(project);

        }


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateProject([FromRoute] Guid id, UpdateProjectRequest updateProjectRequest)
        {
            var addproject = projectsAPIDbcontext.Createprojects.Find(id);


            if (addproject != null)
            {
                addproject.ProjectName = updateProjectRequest.ProjectName;
                addproject.Priority = updateProjectRequest.Priority;
                addproject.ManagerName = updateProjectRequest.ManagerName;


                await projectsAPIDbcontext.SaveChangesAsync();

                return Ok(addproject);

            }

            return NotFound();

        }


        [HttpDelete]
        [Route("{id:guid}")]


        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {

            var addproject = projectsAPIDbcontext.Createprojects.Find(id);

            if (addproject != null)
            {
                projectsAPIDbcontext.Remove(addproject);

                await projectsAPIDbcontext.SaveChangesAsync();

                return Ok(addproject);
            }

            return NotFound();
        }
    }
}
