using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _request;

        public LogsController(IRequestRepository request)
        {
            _request = request;
        }

        public async Task<IActionResult> Logs()
        {
            var usersLogs = await _request.GetRequests();
            return View(usersLogs);
        }
    }


}
