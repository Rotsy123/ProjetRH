using ProjetRh.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rh.Models;
public class Demande
{
    int idDemande;
    DateTime dateDemande;
    double heureTravaux;
    double hommeJour;
    int idDepartement;

    public int EmployeARetruter(double heureTravaux, double hommejour){
        double employe = heureTravaux/hommeJour;
        int emp = (int)employe;
        if(employe > emp){
            emp = emp + 1;
        }
        return emp;
    }
    public void Insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Demande (dateDemande, heureTravaux,hommeJour, idDepartement) VALUES (@dateD, @heureTr, @hommeJour, @idDepartement)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@dateD",DateDemande );
        cmd.Parameters.AddWithValue("@heureTr",HeureTravaux );
        cmd.Parameters.AddWithValue("@hommeJour", HommeJour);
        cmd.Parameters.AddWithValue("@idDepartement",IdDepartement);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public Demande(DateTime dateD,double heureTr,double hommeJour,int idDepartement){
        DateDemande = dateD;
        HeureTravaux = heureTr;
        HommeJour = hommeJour;
        IdDepartement = idDepartement;
    } 
    public int IdDepartement { get => idDepartement; set => idDepartement = value; }
    public double HommeJour { get => hommeJour; set => hommeJour = value; }
    public double HeureTravaux { get => heureTravaux; set => heureTravaux = value; }
    public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
    public int IdDemande { get => idDemande; set => idDemande = value; }
}