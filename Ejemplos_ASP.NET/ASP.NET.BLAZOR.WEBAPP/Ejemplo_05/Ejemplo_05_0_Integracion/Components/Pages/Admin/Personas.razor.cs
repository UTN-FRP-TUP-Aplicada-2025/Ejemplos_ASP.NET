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
    [Inject] PersonasService _personasService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        Model ??= new PersonaModel() { };

        //aquí no me funcionó
        //s1
        personas = await _personasService.GetAll();

        isLoading = false;
        StateHasChanged();
    }

    async protected Task onShowFormEditRegistro(int? id)
    {
        isVisibleFormCreateRegistro = false;
        isVisibleFormEditRegistro = true;
        isVisibleFormDetailRegistro = false;
        Model = await _personasService.GetById(id??0);

       // StateHasChanged();
    }

    async protected Task onShowFormDetailRegistro(int? id)
    {
        isVisibleFormCreateRegistro = false;
        isVisibleFormEditRegistro = false;
        isVisibleFormDetailRegistro = true;
        Model = await _personasService.GetById(id??0);
    }

    protected void onShowFormCreateRegistro()
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
        await onShowFormDetailRegistro(Model.Id);
    }

    private async Task onEditPersona()
    {
        try
        {
            await _personasService.Actualizar(Model);

            await onShowFormDetailRegistro(Model.Id);
        }
        catch (Exception e)
        {

        }
    }

    async private Task onDeletePersona(int? id)
    {
        await _personasService.Eliminar(id??0);
        personas = await _personasService.GetAll();
    }
    
}
