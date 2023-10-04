using ProjetRh.Models;
using System.Data.SqlClient;

namespace Rh.Models;
public class CursusNiveau{
    int idCursusNiveau;
    int idCursus;
    double niveau;
    double coefficient;
    public void insertionCursusNiveau(Connexion c){
        SqlConnection con =  c.connexion();
        con.Open();
        string requete = "INSERT INTO CursusNiveau(idCursus,niveau,coefficient) VALUES (@idCursus, @niveau, @coefficient)";
        SqlCommand cmd = new SqlCommand(requete, con);
        cmd.Parameters.AddWithValue("@idCursus", IdCursus);
        cmd.Parameters.AddWithValue("@niveau", Niveau);
        cmd.Parameters.AddWithValue("@coefficient", Coefficient);
        cmd.ExecuteNonQuery();
        con.Close();
    }

}