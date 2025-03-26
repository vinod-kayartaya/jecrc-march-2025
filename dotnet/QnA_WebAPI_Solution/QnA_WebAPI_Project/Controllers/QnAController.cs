using Microsoft.AspNetCore.Mvc;
using QnA_WebAPI_Project.Data;
using QnA_WebAPI_Project.Model;

namespace QnA_WebAPI_Project.Controllers
{
    // https://localhost:7238/api/qna
    [Route("api/[controller]")]
    [ApiController]
    public class QnAController : ControllerBase
    {
        AppDbContext context;

        public QnAController(AppDbContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult DisplayAllQuestions()
        {
            return Ok(context.Questions.ToList());
        }

        [HttpPost]
        public IActionResult AddNewQuestion([FromBody] Question question)
        {
            context.Questions.Add(question); // INSERT
            context.SaveChanges(); // COMMIT
            return Ok(question);
        }
    }
}
