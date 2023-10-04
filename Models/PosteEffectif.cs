using System.Data.SqlClient;
using ProjetRh.Models;

namespace ProjetRH.Models;
class PosteEffectif{
    public int idPosteEffectif;
    public int idDenande;
    public int effectif;
    public DateTime datefinpostule;


    public void insertionPosteEffectif(Connexion c){
        SqlConnection con =  c.connexion();
        con.Open();
        string requete = "INSERT INTO posteeffectif VALUES (@idDemande, @effectif, @datefinpostule)";
        SqlCommand cmd = new SqlCommand(requete, con);
        cmd.Parameters.AddWithValue("@idDemande", idDemande);
        cmd.Parameters.AddWithValue("@effectif", effectif);
        cmd.Parameters.AddWithValue("@datefinpostule", datefinpostule);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public PosteEffectif(int idPosteEffectif, int idDenande, int effectif, DateTime datefinpostule){
        IdPosteEffectif = idPosteEffectif;
        IdDenande = idDenande;
        Effectif = effectif;
        Datefinpostule = datefinpostule;
    }
    public PosteEffectif(){}

    public int IdPosteEffectif{get => idPosteEffectif ;set => idPosteEffectif = value;}
    public int IdDenande{get => idDenande ;set => idDenande = value;}
    public int Effectif{get => effectif ;set => effectif = value;}
    public DateTime Datefinpostule{get => datefinpostule ;set => datefinpostule = value;}
}

