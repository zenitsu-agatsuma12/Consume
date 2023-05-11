using Consume.Models;
using Consume.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Consume.Controllers
{
    public class InformationController : Controller
    {
        IInformationRepository _repo;

        public InformationController(IInformationRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllInformation()
        {
            var todolist = _repo.GetAllInformation();
            return View(todolist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Information newInformation) 
        {
            if (ModelState.IsValid)
            {
                var info = _repo.AddInformation(newInformation);
                return RedirectToAction("GetAllInformation");
            }
            ViewData["Message"] = "Data is not valid to create the Information";
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var info = _repo.GetInformationById(id);
            return View(info);
        }

        [HttpGet]
        public IActionResult Update(int informationId)
        {
            var oldTodo = _repo.GetInformationById(informationId);
            return View(oldTodo);
        }
        [HttpPost]
        public IActionResult Update(Information newInformation)
        {
            var todo = _repo.UpdateInformation(newInformation.Id, newInformation);
            return RedirectToAction("GetAllInformation");
        }

        public IActionResult Delete(int id)
        {
            var infolist = _repo.DeleteTodo(id);
            return RedirectToAction(controllerName: "Information", actionName: "GetAllInformation");
        }
    }
}
