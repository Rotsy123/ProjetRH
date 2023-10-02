using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetRh.Models;
using Rh.Models;

namespace ProjetRH.Controllers;
public class PosteController : Controller
{
    public IActionResult Poste(){
        return View("Choixposte");
    }

}