using ProjetRh.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Rh.Models;
public class Employes{
    int idEmpt;
    int idPoste;
    int idDept;
    double salaire;
    public Employes[] GetDonnee(Connexion c)
    {
        List<Employes> Employess = new List<Employes>();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Employes";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            Employes temp = new Employes(data.GetInt32(0), data.GetInt32(1), data.GetInt32(2),data.GetDouble(3));
            Employess.Add(temp);
        }
        con.Close();
        return Employess.ToArray();
    }
    public Employes(int idEmpt,int idPoste,int idDept,double salaire){
        IdEmpt = idEmpt;
        IdPoste = idPoste;
        IdDept = idDept;
        Salaire = salaire;
    }

    public double Salaire { get => salaire; set => salaire = value; }
    public int IdDept { get => idDept; set => idDept = value; }
    public int IdPoste { get => idPoste; set => idPoste = value; }
    public int IdEmpt { get => idEmpt; set => idEmpt = value; }
}