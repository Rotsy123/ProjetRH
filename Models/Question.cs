using System.Data.SqlClient;
using ProjetRh.Models;

namespace Rh.Models;
class Question{
    public int idQuestion {get;set;}
    public string? question {get;set;}
    public List<Reponse> reponse {get;set;}

    public Question (int idQuestion, string? question, List<Reponse> reponse){
        this.idQuestion = idQuestion;
        this.question = question;
        this.reponse = reponse;
    }
    public Question(int idQuestion, string? question){
        this.idQuestion = idQuestion;
        this.question = question;
    }
    public Question(){}
    
    public Question LastEnter (){
        Connexion c = new Connexion();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Question order by idQuestion desc";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        Question temp = null;
        if (data.Read())
        {
            temp = new Question(data.GetInt32(0),data.GetString(1)) ;
        }
        con.Close();
        return temp;
    }
    public void InsertQuestionReponse(Connexion c){
        Question quest = new Question().LastEnter();
        SqlConnection con = c.connexion();
        con.Open();
        for(int i=0; i<reponse.Count(); i++){
            string sql = "INSERT INTO QuestionReponse (idquestion, idReponse, valeur) VALUES (@idquestion, @idReponse, @valeur)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idquestion", quest.idQuestion);
            cmd.Parameters.AddWithValue("@idReponse", reponse[i].idReponse);
            cmd.Parameters.AddWithValue("@valeur", reponse[i].valeur); 
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