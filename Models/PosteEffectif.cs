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
    public PosteEffectif(){}
    public int Idposte{get => idposte ;set => idposte = value;}

    public int IdPosteEffectif{get => idPosteEffectif ;set => idPosteEffectif = value;}
    public int IdDemande{get => idDemande ;set => idDemande = value;}
    public int Effectif{get => effectif ;set => effectif = value;}
    public DateTime Datefinpostule{get => datefinpostule ;set => datefinpostule = value;}
}

