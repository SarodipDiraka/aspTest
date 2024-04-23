using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp.Models;
using asp.Repositories.Interfaces;

namespace asp.Controllers;

public class HomeController : Controller
{
    private readonly IToDoElementsRepository _iToDoElementsRepository;

    public HomeController(IToDoElementsRepository context)
    {
        _iToDoElementsRepository = context;
    }

    public IActionResult Index()
    {
        return View(_iToDoElementsRepository.GetAll().ToList());
    }

    [HttpGet, ActionName("Delete")]
    public IActionResult DeleteElement(int id)
    {
        _iToDoElementsRepository.Remove(_iToDoElementsRepository.GetById(id));
        _iToDoElementsRepository.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddElement(string textElement)
    {
        var newToDoElement = new ToDoElement(textElement);
        _iToDoElementsRepository.Add(newToDoElement);
        _iToDoElementsRepository.SaveChanges();
        return PartialView("ToDoElementList", _iToDoElementsRepository.GetAll().ToList());
    }

    [HttpGet, ActionName("Finish")]
    public IActionResult FinishElement(int id)
    {
        var changedToDoElement = _iToDoElementsRepository.GetById(id);
        changedToDoElement.Completed = true;
        _iToDoElementsRepository.Update(changedToDoElement);
        _iToDoElementsRepository.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
