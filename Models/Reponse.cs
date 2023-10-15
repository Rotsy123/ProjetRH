using System.Data.SqlClient;
using ProjetRh.Models;

namespace Rh.Models;
public class Reponse{
    public int idReponse {get;set;}
    public int idQuestion {get;set;}
    public string? reponse {get;set;}
    public int coefficient {get;set;}

    public Reponse(){}
    public Reponse(string? reponse,int idQuestion,int coefficient){
        this.idQuestion = idQuestion;
        this.reponse = reponse;
        this.coefficient = coefficient;
    }
    public Reponse (int idReponse, string? reponse, int coefficient){
        this.idReponse = idReponse;
        this.reponse = reponse;
        this.coefficient = coefficient;
    }
    public void Insert(Connexion c){
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Reponse (idquestion,reponse,valeur) VALUES (@idquestion,@reponse,@coefficient)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@idquestion", idQuestion);
        cmd.Parameters.AddWithValue("@reponse", reponse);
        cmd.Parameters.AddWithValue("@coefficient", coefficient );
        Console.WriteLine(cmd.CommandText);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public  Reponse LastEnter (){
        Connexion c = new Connexion();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Reponse order by idQuestion desc";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
         Reponse temp = null;
        if (data.Read()){
            temp = new  Reponse(data.GetInt32(0),data.GetString(1),data.GetInt32(2)) ;
        }
        con.Close();
        return temp;
    }
}