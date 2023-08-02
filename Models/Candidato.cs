public class Candidato {
    public int IdCandidato { set;  get;}
    public int IdPartido { set;  get;}
    public string Nombre { set;  get;}
    public string Apellido { set;  get;}
    public DateTime FechaNacimiento { set;  get;}
    public string Foto { set;  get;}
    public string Postulacion { set;  get;}
    public string WikiPedia {set; get;}
   
   // constructor
    public Candidato() {
        Nombre = "";
        Apellido = "";
        Foto = "";
        Postulacion = "";
        WikiPedia = "";
    }
    public Candidato(string nombre, string apellido, DateTime fechaNacimiento, string foto, string postulacion, string wikiPedia) {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Foto = foto;
        Postulacion = postulacion;
        WikiPedia = wikiPedia;
    }
    public Candidato(int idPartido,string nombre, string apellido, DateTime fechaNacimiento, string foto, string postulacion, string wikiPedia) {
        IdPartido = idPartido;
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Foto = foto;
        Postulacion = postulacion;
        WikiPedia = wikiPedia;
    }
}