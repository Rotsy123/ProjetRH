using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProjetRh.Models;

namespace ProjetRH.Models
{
    public class Quiz
    {
        int idQuiz;
        int idPoste;
        int idQuestion;
        public void insert(Connexion c){
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "INSERT INTO Quiz (idposte,idquestion) VALUES (@idposte,@idquestion)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idquestion", idQuestion);
            cmd.Parameters.AddWithValue("@idposte", idPoste);
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Quiz(int idPoste, int idQuestion){
            this.idPoste = idPoste;
            this.idQuestion = idQuestion;
        }

        public int IdQuestion { get => idQuestion; set => idQuestion = value; }
        public int IdPoste { get => idPoste; set => idPoste = value; }
        public int IdQuiz { get => idQuiz; set => idQuiz = value; }
    }
}