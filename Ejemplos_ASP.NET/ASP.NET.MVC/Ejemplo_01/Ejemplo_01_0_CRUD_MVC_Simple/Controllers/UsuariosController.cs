using Ejemplo_01_0_CRUD_MVC_Simple.Models;
using Ejemplo_01_0_CRUD_MVC_Simple.Services;
using Ejemplo_01_CRUD_MVC_Simple.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_01_CRUD_MVC_Simple.Controllers;

public class UsuariosController : Controller
{
    private readonly CuentasService _cuentasService;

    public UsuariosController(CuentasService cuentasService)
    {
        _cuentasService = cuentasService;
    }

    async public Task<IActionResult> Index(string? id=null)
    {
        var viewModel = new UsuarioViewModel
        {
            Usuarios = await _cuentasService.GetAll(),
            Usuario = id!=null ? await _cuentasService.GetByNombre(id) : new UsuarioModel()
        };
        return View(viewModel);
    }

    [HttpPost]
    async public Task<IActionResult> Create(UsuarioViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _cuentasService.CrearNuevo(viewModel.Usuario);
            return RedirectToAction("Index");
        }

        viewModel.Usuarios = await _cuentasService.GetAll();
        return View("Index", viewModel);
    }

    [HttpPost]
    async public Task<IActionResult> Actualizar(UsuarioViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _cuentasService.Actualizar(viewModel.Usuario);
            return RedirectToAction("Index");
        }

        viewModel.Usuarios = await _cuentasService.GetAll();
        return View("Index", viewModel);
    }



    async public Task<IActionResult> Eliminar(string nombre)
    {
        await _cuentasService.Eliminar(nombre);
        return RedirectToAction("Index");
    }

    public IActionResult Ver(string nombre)
    {
        var usuario = _cuentasService.GetByNombre(nombre);
        return View(usuario); 
    }
}