using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetRh.Models;
using ProjetRH.Models;
using Rh.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetRH.Controllers
{
    public class PosteController : Controller
    {
        private readonly ILogger<PosteController> _logger;

        public PosteController(ILogger<PosteController> logger)
        {
            _logger = logger;
        }
        public IActionResult PosteListe()
        {
            Connexion co = new Connexion();
            PosteEffectif pos = new PosteEffectif();
            PosteEffectif[] liste =  pos.selectPosteEffectif(co);
            ViewBag.Listeposteeff=liste;
            return View();
        }
        public IActionResult Choixposte(){
            int idDemande = 3;
            DateTime date = DateTime.Today;
            double heureT =  Convert.ToDouble(Request.Form["heureT"].ToString());
            double hommeJour = Convert.ToDouble(Request.Form["jourH"].ToString());
            Connexion con = new Connexion();
            Demande dem = new Demande(date,heureT,hommeJour,idDemande);
            dem.Insert(con);
            int nombre = dem.EmployeARetruter(heureT,hommeJour);
            ViewBag.nombre= nombre;
            return View(); 
        }
        public IActionResult QCM(){
            return View();
        }
             
        public IActionResult EditCV()
        {
            return View(); 
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}