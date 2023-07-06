using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
public static class BD {
    
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can) {

    }
    public static void EliminarCandidato(int IdCandidato) {

    }
    public static Partido VerInfoPartido(int IdPartido) {
        Partido MiPartido = new Partido();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
            MiPartido = db.QueryFirstOrDefault<Partido>(sql, new {pIdPartido = IdPartido });
        }
        return MiPartido;
    }
     public static Candidato VerInfoCandidato(int IdCandidato) {
        Candidato MiCandidato = new Candidato();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @pIdCandidato";
            MiCandidato = db.QueryFirstOrDefault<Candidato>(sql, new {pIdCandidato = IdCandidato });
        }
        return MiCandidato;
    }
    public static List<Candidato> VerInfoCandidatos(int Idpartido) {
        List<Candidato> MisCandidatos= new List<Candidato>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @pIdCandidato";
            MisCandidatos = db.Query<Candidato>(sql, new {pIdCandidato = Idpartido }).ToList();
        }
        return MisCandidatos;
    }
    public static List<Partido> ListarPartidos() {
        List<Partido> MisPartidos = new List<Partido>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Partido";
            MisPartidos = db.Query<Partido>(sql).ToList();
        }
        foreach(var partido in MisPartidos) {
            using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @pIdPartido AND Postulacion = 'Presidente'";
            partido.Presidente = db.QueryFirstOrDefault<Candidato>(sql, new {pIdPartido = partido.IdPartido });
            sql = "SELECT * FROM Candidato WHERE IdPartido = @pIdPartido AND Postulacion = 'VicePresidente'";
            partido.Vice = db.QueryFirstOrDefault<Candidato>(sql, new {pIdPartido = partido.IdPartido });
        }
        }
        return MisPartidos;
    }
    public static List<Candidato> ListarCandidatos(int IdPartido) {
        List<Candidato> MisCandidatos = new List<Candidato>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = " + IdPartido;
            MisCandidatos = db.Query<Candidato>(sql).ToList();
        }
        return MisCandidatos;
    }
}