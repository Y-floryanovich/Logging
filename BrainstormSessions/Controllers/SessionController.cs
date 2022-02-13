using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Logger;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private const string EndMessage = "Method Index is completed";
        private const string StartMessage = "Method Index is started";

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            LogHandler.Log.Debug(StartMessage);

            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            LogHandler.Log.Debug(EndMessage);
            return View(viewModel);
        }
    }
}
