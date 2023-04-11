using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HP4.Models;
using HP4.Services;

namespace HP4.Controllers;

public class MovieController : Controller
{
    public MovieController()
    {
      
    }

//Aca de muestran los dos menus, index y privacy
//Revisa una vista que coincida con el nombre de la accion
// Llamamos a todos los elementos de la lista
    public IActionResult Index()
    {
        var model = new List<Movie>();
        model = MovieService.GetAll();
        return View(model);
    }

    public IActionResult Detail(string id)
    {
        var model = MovieService.Get(id);

        return View(model);
    }

    // Este es get
    public IActionResult Create()
    {
        return View();
    }

    //Este sirve como Post: crear nueva pelicula
    [HttpPost]
    public IActionResult Create(Movie movie){
        if(!ModelState.IsValid){
            RedirectToAction("Create");
        }

        MovieService.Add(movie);
        return RedirectToAction("Index"); 
    }


    [HttpPost]
    public IActionResult Delete(string Code)
    {
        if(Code != null){
            MovieService.Delete(Code);
        }

      return RedirectToAction("Index");

    }

}
