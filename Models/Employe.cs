using ProjetRh.Models;
using System.Data.SqlClient;

namespace Rh.Models;
public class Employes{
    public int idEmpt; 
    public string nom;
    public string prenom;
    public DateOnly dtn;
    public int idDept;
    public int idPoste;
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
            Employes temp = new Employes(data.GetInt32(0),data.GetString(1), data.GetString(2),DateOnly.FromDateTime(data.GetDateTime(3)), data.GetInt32(4), data.GetInt32(5),data.GetDouble(6));
            Employess.Add(temp);
        }
        con.Close();
        return Employess.ToArray();
    }
    public Employes(int idEmpt,string nom, string prenom,DateOnly dtn,int idPoste,int idDept,double salaire){
        IdEmpt = idEmpt;
        Nom = nom;
        Prenom = prenom;
        Dtn = dtn;
        IdPoste = idPoste;
        IdDept = idDept;
        Salaire = salaire;
    }

    public Employes() {}

    public double Salaire { get => salaire; set => salaire = value; }
    public int IdDept { get => idDept; set => idDept = value; }
    public int IdPoste { get => idPoste; set => idPoste = value; }
    public int IdEmpt { get => idEmpt; set => idEmpt = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prenom {get =>  prenom;  set => prenom = value;}
    public DateOnly Dtn {get => dtn; set => dtn = value;}

}