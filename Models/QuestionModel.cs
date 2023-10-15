using System.Data.SqlClient;
using ProjetRh.Models;

namespace Rh.Models;
public class QuestionModel{
    public int idQuestion {get;set;}
    public string? question {get;set;}
    public List<Reponse> reponses {get;set;}

    public  QuestionModel (int idQuestion, string? question, List<Reponse> reponse){
        this.idQuestion = idQuestion;
        this.question = question;
        this.reponses = reponse;
    }
     public  QuestionModel (string? question, List<Reponse> reponse){
        this.question = question;
        this.reponses = reponse;
    }
    public  QuestionModel(int idQuestion, string? question){
        this.idQuestion = idQuestion;
        this.question = question;
    }
    public  QuestionModel(){}
    
    public  QuestionModel LastEnter (){
        Connexion c = new Connexion();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Question order by idQuestion desc";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
         QuestionModel temp = null;
        if (data.Read())
        {
            temp = new  QuestionModel(data.GetInt32(0),data.GetString(1)) ;
        }
        con.Close();
        return temp;
    }
    public void InsertQuestionReponse(Connexion c){
         QuestionModel quest = new  QuestionModel().LastEnter();
        SqlConnection con = c.connexion();
        con.Open();
        for(int i=0; i<reponses.Count(); i++){
            string sql = "INSERT INTO QuestionReponse (idquestion, idReponse, valeur) VALUES (@idquestion, @idReponse, @valeur)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idquestion", quest.idQuestion);
            cmd.Parameters.AddWithValue("@idReponse", reponses[i].idReponse);
            cmd.Parameters.AddWithValue("@valeur", reponses[i].coefficient); 
        Console.WriteLine(sql);
        cmd.ExecuteNonQuery();
        }

        con.Close();
    }
    public void Insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Question (question) VALUES (@question)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@question", question); 
        Console.WriteLine(sql);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}