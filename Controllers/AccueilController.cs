using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetRh.Models;
using Rh.Models;

namespace ProjetRH.Controllers;
public class AccueilController : Controller
{
    public IActionResult InsertionDemand()
    {
        return View("/Views/listEmploye");
    }
    public IActionResult EmployeListe(){
        // string idDept = Request.Query["idDept"];
        Connexion c = new Connexion();
        Employes emp = new Employes(); 
        Employes[] listemp = emp.GetDonnee(c);
        ViewBag.ListeEmp = listemp;
        return View();
    }

}