using Ejemplo_05_0_Integracion.Models;
using Ejemplo_05_0_Integracion.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;

namespace Ejemplo_05_0_Integracion.Components.Pages.Admin;

public partial class Personas:ComponentBase
{
    private bool isLoading = true;

    [SupplyParameterFromForm]
    private PersonaModel? Model { get; set; }

    private List<PersonaModel>? personas { get; set; } = new();

    private bool isVisibleFormDetailRegistro;
    private bool isVisibleFormCreateRegistro;
    private bool isVisibleFormEditRegistro;

    //private PersonasService _personasService = new();
    // [Inject]
    // PersonasService _personasService;


    protected override async Task OnInitializedAsync()
    {
        Model ??= new PersonaModel() { };

        //aquí no me funcionó
        //s1
        personas = await _personasService.GetAll();

        isLoading = false;
        StateHasChanged();
    }

    // protected override async Task OnAfterRenderAsync(bool firstRender)
    // {
    //   //  isLoading = false;
    // }
    // //s1 agregue este evento
    // protected override async Task OnAfterRenderAsync(bool firstRender)
    // {
    //     if (firstRender && !_isLoaded)
    //     {
    //         personas = await _personasService.GetAll();
    //         _isLoaded = true;
    //         StateHasChanged(); // Notifica al componente que debe volver a renderizarse
    //     }
    // }

    async protected Task viewFormEditRegistro(int? id)
    {
        isVisibleFormCreateRegistro = false;
        isVisibleFormEditRegistro = true;
        isVisibleFormDetailRegistro = false;
        Model = await _personasService.GetById((int)id);
    }

    async protected Task viewFormDetailRegistro(int? id)
    {
        isVisibleFormCreateRegistro = false;
        isVisibleFormEditRegistro = false;
        isVisibleFormDetailRegistro = true;
        Model = await _personasService.GetById((int)id);
    }

    protected void viewFormCreateRegistro()
    {
        isVisibleFormCreateRegistro = true;
        isVisibleFormEditRegistro = false;
        isVisibleFormDetailRegistro = false;
        Model = new();
    }


    private async Task onCreatePersona()
    {
        Model.FechaNacimiento = DateTime.Now;
        await _personasService.CrearNuevo(Model);
        personas.Add(Model);
        await viewFormDetailRegistro(Model.Id);
    }

    private async Task onEditPersona()
    {
        try
        {
            await _personasService.Actualizar(Model);

            await viewFormDetailRegistro(Model.Id);
        }
        catch (Exception e)
        {

        }
    }

    async private Task onEliminarPersona(int? id)
    {
        await _personasService.Eliminar((int)id);
        personas = await _personasService.GetAll();
    }



    
}
