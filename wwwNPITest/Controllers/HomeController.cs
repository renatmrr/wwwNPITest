using JSTable.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wwwNPITest.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB.Model.Context _context;

        public HomeController(DB.Model.Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IResult GetProjectsCompany([FromBody] JsTableParametrs param) =>
           Results.Json(
               new ProjectCompany
               {
                   Parametrs = param,
                   Table = _context.ProjectCompanies
               }.Result);

        public IResult GetProjectsCompanyTable([FromBody] JsTableParametrs param, int id) =>
           Results.Json(
               new ProjectCompanyGeneral
               {
                   Parametrs = param,
                   Table = _context.ProjectCompanies
                   .Where(l => l.Id == id)
               }.Result);

        public IResult GetObjectDesignTable([FromBody] JsTableParametrs param, int id) =>
          Results.Json(
              new ObjectDesign
              {
                  Parametrs = param,
                  Table = _context.DesignObjects
                  .Where(l => l.Id == id)
              }.Result);
    }
}
