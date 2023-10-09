using System.Data.SqlClient;
using ProjetRh.Models;

namespace Rh.Models;
class Reponse{
    public int idReponse {get;set;}
    public string? reponse {get;set;}
    public int valeur {get;set;}

    public Reponse(){}
    public Reponse (int idReponse, string? reponse, int valeur){
        this.idReponse = idReponse;
        this.reponse = reponse;
        this.valeur = valeur;
    }
        public void Insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Reponse (reponse, valeur) VALUES (@reponse, @valeur)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@reponse", reponse );
        cmd.Parameters.AddWithValue("@valeur", valeur );
        Console.WriteLine(sql);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}