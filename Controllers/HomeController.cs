using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpElecciones.Models;

namespace tpElecciones.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Partidos = BD.ListarPartidos(); 
        return View();
    }
    public IActionResult VerDetallePartido(int IdPartido) {
        ViewBag.Partido = BD.VerInfoPartido(IdPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(IdPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int id) {
        ViewBag.Candidato = BD.VerInfoCandidato(id);
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int IdPartido) {
        ViewBag.IdPartido = IdPartido;
        return View("FormCandidatos");
    }
    [HttpPost] IActionResult GuardarCandidato(int IdPartido, string Nombre, string Apellido, string FechaNacimiento, string foto, string postulacion, string WikiPedia) {
        Candidato can = new Candidato();
        can.IdPartido = IdPartido;
        can.Nombre = Nombre;
        can.Apellido = Apellido;
        can.FechaNacimiento = DateTime.Parse(FechaNacimiento);
        can.foto = foto;
        can.postulacion = postulacion;
        can.WikiPedia = WikiPedia;
        BD.AgregarCandidato(can);
        ViewBag.Partido = BD.VerInfoPartido(can.IdPartido);
        return View("DetallePartido");
    }
    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido) {
        BD.EliminarCandidato(IdCandidato);
        ViewBag.Partido = BD.VerInfoPartido(IdPartido);
        return View("DetallePartido");
    }
    public IActionResult Elecciones() {
        return View("Elecciones");
    }
    public IActionResult Creditos() {
        return View("Creditos");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
