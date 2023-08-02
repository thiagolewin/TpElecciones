public class Partido {
    public int IdPartido { set;  get;}
    public string Nombre { set;  get;}
    public string Logo { set;  get;}
    public string SitioWeb { set;  get;}
    public DateTime FechaFundacion { set;  get;}
     public int CantidadDiputados { set;  get;}
    public int CantidadSenadores { set;  get;}
    public Candidato Presidente { set;  get;}
    public Candidato Vice { set;  get;}
    public Partido() {
        Nombre = "";
        Logo = "";
        SitioWeb = "";
    }
    public Partido(string nombre, string logo, DateTime fechaFundacion, int cantidadDiputados, int cantidadSenadores, string sitioWeb) {
        Candidato Presi = new Candidato("Sin definir","Sin definir",DateTime.Now,"","Presidente","");
        Candidato Vice = new Candidato("Sin definir","Sin definir",DateTime.Now,"","VicePresidente","");
        Nombre = nombre;
        Logo = logo;
        FechaFundacion = fechaFundacion;
        CantidadDiputados = cantidadDiputados;
        CantidadSenadores = cantidadSenadores;
        SitioWeb = sitioWeb;
        Presidente = Presi;
        Vice = Vice;
    }
}
