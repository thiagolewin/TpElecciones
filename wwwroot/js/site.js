// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function vercandidato(idCandidato)
{
    window.location.href = "/Home/VerDetalleCandidato/"+ idCandidato;
    
}


const main = document.querySelector("#DetallePartido")
const Diputados = document.querySelector(".diputados")
main.style.height = Diputados.offsetHeight + 200 + "px"