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
    public IActionResult AgregarPartido() {
        return View("FormPartidos");
    }
    [HttpPost] public IActionResult GuardarCandidato(int IdPartido, string Nombre, string Apellido, DateTime FechaNacimiento, string Foto, string Postulacion, string WikiPedia) {
        Candidato can = new Candidato(IdPartido,Nombre,Apellido,FechaNacimiento,Foto,Postulacion,WikiPedia);
        BD.AgregarCandidato(can);
        return RedirectToAction("VerDetallePartido", new { IdPartido = IdPartido});
        
    }
     [HttpPost] public IActionResult GuardarPartido(string Nombre, string Logo, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores, string SitioWeb) {
        Partido par = new Partido(Nombre, Logo, FechaFundacion, CantidadDiputados, CantidadSenadores, SitioWeb);
        BD.AgregarPartido(par);
       return RedirectToAction("Index");
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
