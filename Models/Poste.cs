using System.Data.SqlClient;
using ProjetRh.Models;

namespace Rh.Models;
class Poste{
    public int idPoste;
    public string nomPoste;
    public int effectif;
    public int idDemande;
    public DateTime dateFinPostule;

    public Poste[] selectPoste(Connexion c){
        SqlConnection con = c.connexion();
        con.Open();
        List<Poste> postes = new List<Poste>();
        string requete = "SELECT * FROM poste";
        SqlCommand cmd = new SqlCommand(requete, con);
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
            postes.Add(new Poste{
                idPoste = reader.GetInt32(0),
                nomPoste = reader.GetString(1),
                effectif = reader.GetInt32(2),
                idDemande = reader.GetInt32(3),
                dateFinPostule = reader.GetDateTime(4)
            });
        }
        con.Close();
        return postes.ToArray();
    }

    public Poste() {}

    public Poste(int idPoste, string nomPoste, int effectif,int idDemande, DateTime dateFinPostule){
        IdPoste = idPoste;
        NomPoste = nomPoste;
        Effectif = effectif;
        IdDemande = idDemande;
        DateFinPostule = dateFinPostule;
    }

    public int IdPoste { get => idPoste ;set => idPoste = value;}
    public string NomPoste { get => nomPoste ;set => nomPoste = value;}
    public int Effectif { get => effectif ;set => effectif = value;}
    public int IdDemande { get => idDemande ;set => idDemande = value;}
    public DateTime DateFinPostule { get => dateFinPostule ;set => dateFinPostule = value;}

}