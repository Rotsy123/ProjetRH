using ProjetRh.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rh.Models;
class PosteEffectif{
    public int idPosteEffectif;
    public int idDemande;
    public int effectif;
    public int idposte;
    public DateTime datefinpostule;

    public PosteEffectif(){}
    public  PosteEffectif[] selectPosteEffectif(Connexion c){
        SqlConnection con = c.connexion();
        con.Open();
        List<PosteEffectif> postes = new List<PosteEffectif>();
        string requete = "SELECT * FROM posteeffectif";
        SqlCommand cmd = new SqlCommand(requete, con);
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
            PosteEffectif po = new PosteEffectif( reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2),reader.GetDateTime(3));
            postes.Add(po);
        }
        con.Close();
        return postes.ToArray();
    }
    public void insertionPosteEffectif(Connexion c){
        SqlConnection con =  c.connexion();
        con.Open();
        string requete = "INSERT INTO posteeffectif (iddemande, effectif, idposte, datefinpostule) VALUES (@idDemande, @effectif, @idposte, @datefinpostule)";
        SqlCommand cmd = new SqlCommand(requete, con);
        cmd.Parameters.AddWithValue("@idDemande", idDemande);
        cmd.Parameters.AddWithValue("@effectif", effectif);
        cmd.Parameters.AddWithValue("@idposte", idposte);
        cmd.Parameters.AddWithValue("@datefinpostule", datefinpostule);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public PosteEffectif( int idDemande, int effectif,int idposte, DateTime datefinpostule){
        IdDemande = idDemande;
        Effectif = effectif;
        Idposte = idposte;
        Datefinpostule = datefinpostule;
    }
    public PosteEffectif(int idPosteEffectif, int idDemande, int effectif,int idposte, DateTime datefinpostule){
        IdPosteEffectif = idPosteEffectif;
        IdDemande = idDemande;
        Effectif = effectif;
        Idposte = idposte;
        Datefinpostule = datefinpostule;
    }
    public int Idposte{get => idposte ;set => idposte = value;}


    public int IdPosteEffectif{get => idPosteEffectif ;set => idPosteEffectif = value;}
    public int IdDemande{get => idDemande ;set => idDemande = value;}
    public int Effectif{get => effectif ;set => effectif = value;}
    public DateTime Datefinpostule{get => datefinpostule ;set => datefinpostule = value;}
}

