using Microsoft.AspNetCore.Mvc;
using ProjetRh.Models;
using Rh.Models;

namespace ProjetRH.Controllers
{
    public class AccueilController : Controller
    {
        public ActionResult InsertionDemand()
        {
            return View("/Views/listEmploye");
        }

        [HttpPost]
        public ActionResult ListeEmploye()
        {
            string idDept = Request.Query["idDept"];
            Connexion c = new Connexion();
            Employes emp = new Employes(); 
            Employes[] listemp = emp.GetDonnee(c);
            return View("/Views/listEmploye",listemp);
        }
    }
}