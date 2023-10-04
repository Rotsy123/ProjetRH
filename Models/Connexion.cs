using System.Data.SqlClient;
namespace ProjetRh.Models;
public class Connexion {
    private SqlConnection connection;
    public Connexion(){
        string connectionString ="Server=STEALTH;Database=rh;Trusted_Connection=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        this.connection = connection;
    }
    public SqlConnection connexion()
    {
        return this.connection;
    }
}