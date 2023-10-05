using System.Data.SqlClient;
using ProjetRh.Models;

namespace ProjetRH.Models;
class PosteEffectif{
    public int idPosteEffectif;
    public int idDemande;
    public int effectif;
    public DateTime datefinpostule;

    public PosteEffectif[] selectPosteEffectif(Connexion c){
        SqlConnection con = c.connexion();
        List<PosteEffectif> postes = new List<PosteEffectif>();
        string requete = "SELECT * FROM posteeffectif";
        SqlCommand cmd = new SqlCommand(requete, con);
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
            postes.Add(new PosteEffectif{
                idPosteEffectif = reader.GetInt32(0),
                idDemande = reader.GetInt32(1),
                effectif = reader.GetInt32(2),
                datefinpostule = reader.GetDateTime(4)
            });
        }
        con.Close();
        return postes.ToArray();
    }
    public void insertionPosteEffectif(Connexion c){
        SqlConnection con =  c.connexion();
        con.Open();
        string requete = "INSERT INTO posteeffectif VALUES (@idDemande, @effectif, @datefinpostule)";
        SqlCommand cmd = new SqlCommand(requete, con);
        cmd.Parameters.AddWithValue("@idDemande", idDemande);
        cmd.Parameters.AddWithValue("@effectif", effectif);
        cmd.Parameters.AddWithValue("@datefinpostule", datefinpostule);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public PosteEffectif(int idPosteEffectif, int idDemande, int effectif, DateTime datefinpostule){
        IdPosteEffectif = idPosteEffectif;
        IdDemande = idDemande;
        Effectif = effectif;
        Datefinpostule = datefinpostule;
    }
    public PosteEffectif(){}

    public int IdPosteEffectif{get => idPosteEffectif ;set => idPosteEffectif = value;}
    public int IdDemande{get => idDemande ;set => idDemande = value;}
    public int Effectif{get => effectif ;set => effectif = value;}
    public DateTime Datefinpostule{get => datefinpostule ;set => datefinpostule = value;}
}

