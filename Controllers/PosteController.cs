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
        public IActionResult QCM(){
            return View();
        }
        
        public IActionResult InsertionQCM ([FromBody]List<QuestionModel> data){
            int idPoste = 1;
            Connexion c = new Connexion();
            Console.WriteLine(data[0].reponses);
            for(int i =0; i<data.Count; i++){
                List<Reponse> reps = new List<Reponse>();
                QuestionModel q = new  QuestionModel(data[i].question,data[i].reponses);
                q.Insert(c);
                QuestionModel qm = q.LastEnter();
                Quiz z = new Quiz(idPoste,qm.idQuestion);
                z.insert(c);
                Console.WriteLine(qm.idQuestion);
                for(int j = 0; j<q.reponses.Count;j++){
                    Reponse res = new Reponse(q.reponses[j].reponse,qm.idQuestion,q.reponses[j].coefficient);
                    Console.WriteLine(data[i].reponses[j].coefficient + ":"+j);
                    res.Insert(c);
                }
            }
            return Json(new { success = true, message = "Données ajoutées avec succès " });
        }

        public IActionResult InsertionPosteEffectif(){
            Connexion con = new Connexion();
            int idDemande = 3;
            int idposte = int.Parse(Request.Form["idPoste"].ToString());
            int effectif = int.Parse(Request.Form["effectif"].ToString());
            DateTime finpostule = Convert.ToDateTime(Request.Form["datefinpostule"].ToString());
            PosteEffectif poste = new PosteEffectif(idDemande, effectif, idposte, finpostule);
            poste.insertionPosteEffectif(con); 

            // Retourner une réponse JSON indiquant le succès
            return Json(new { success = true });
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
            Poste[] poste = new Poste().selectPosteDepartement(con, 3);
            ViewBag.postes = poste;
            ViewBag.nombre= nombre;
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