using JSTable.Model;
using JSTable.Model.ObjectsDesign;
using JSTable.Model.ProgectsCompany;
using JSTable.Model.ProjectCompanyGeneral;
using Microsoft.AspNetCore.Mvc;

namespace wwwNPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DB.Model.Context _context;

        public ValuesController(DB.Model.Context context)
        {
            _context = context;
        }

        [HttpPost("GetProjectsCompany")]
        public IResult GetProjectsCompany([FromBody] JsTableParametrs param) =>
           Results.Json(
               new ProjectCompany
               {
                   Parametrs = param,
                   Table = _context.ProjectCompanies
               }.Result);

        [HttpPost("GetProjectsCompanyTable")]
        public IResult GetProjectsCompanyTable([FromBody] JsTableParametrs param, int id) =>
         Results.Json(
             new ProjectCompanyGeneral
             {
                 Parametrs = param,
                 Table = _context.ProjectCompanies
                 .Where(l => l.Id == id)
             }.Result);
        
        [HttpPost("GetObjectDesignTable")]
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
