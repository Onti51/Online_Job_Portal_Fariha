using Microsoft.AspNetCore.Mvc;
using BAL;
using Models;
[ApiController]
public class JobsController : Controller
{
    [HttpGet]
    [Route("[controller]/AllJobs")]

    public ActionResult<IEnumerable<List<Job>>> AllJobs()
    {


        BusinessOperations BOps = new BusinessOperations();
        (List<Job> ReturnData, string status) = BOps.GetAllJobs();
        var route = Request.Path.Value;


        if (ReturnData == null)
        {
            var Response = NotFound(status);
            // Save Log
            return Response;
        }
        else
        {
            var Response = Ok(ReturnData);
            // Save Log
            return Response;
        }
    }
    [HttpPost]
    [Route("[controller]/NewJob")]

    public ActionResult<IEnumerable<string>> NewJob(Job Data)
    {

        BusinessOperations BOps = new BusinessOperations();
        string ReturnData = BOps.AddNewJob(Data);
        var route = Request.Path.Value;


        if (ReturnData == null)
        {
            var Response = NotFound();
            //Save Log
            return Response;
        }
        else
        {
            var Response = Ok(ReturnData);
            //Save Log
            return Response;
        }
    }
}