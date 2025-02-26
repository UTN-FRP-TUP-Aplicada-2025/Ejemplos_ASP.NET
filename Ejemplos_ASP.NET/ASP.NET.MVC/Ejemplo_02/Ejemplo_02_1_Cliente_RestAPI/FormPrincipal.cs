using Ejemplo_02_1_Cliente_RestAPI;
using Ejemplo_02_1_Cliente_RestAPI.ClientServices;
using Ejemplo_02_1_Cliente_RestAPI.Models;

namespace Ejemplo_02_Cliente_RestAPI;

public partial class FormPrincipal : Form
{
    PersonaClientService _clientesService = new PersonaClientService();

    public FormPrincipal()
    {
        InitializeComponent();
    }

    async private void btnListar_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.Clear();
        foreach (var p in await _clientesService.GetAll())
        {
            dataGridView1.Rows.Add(new object[] {p.Id, p.DNI, p.Nombre, p.FechaNacimiento });
        }
    }

    async private void button1_Click(object sender, EventArgs e)
    {
        var fDatos = new FormDatosPersona();
        if (fDatos.ShowDialog() == DialogResult.OK)
        {
          
            int dni = Convert.ToInt32(fDatos.tbDNI.Text);
            string nombre = fDatos.tbNombre.Text;
            DateTime fechaNacimiento = fDatos.dtpFechcaNacimiento.Value;

            var nueva = new PersonaDTO { Id=0, DNI = dni, Nombre = nombre, FechaNacimiento = fechaNacimiento };

            await _clientesService.Insert2(nueva);
        }
    }

    async private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            var fDatos = new FormDatosPersona();

            

            var selected=dataGridView1.SelectedRows[0].Cells[0];

            int id = 2;// Convert.ToInt32(selected.Value);
            var persona = await _clientesService.GetById(id);

            fDatos.tbId.Text = Convert.ToString(persona.Id);
            fDatos.tbDNI.Text = Convert.ToString(persona.DNI);
            fDatos.tbNombre.Text = persona.Nombre;
            fDatos.dtpFechcaNacimiento.Value = persona.FechaNacimiento;

            if (fDatos.ShowDialog() == DialogResult.OK)
            {
                int id1 = Convert.ToInt32(fDatos.tbId.Text);
                int dni = Convert.ToInt32(fDatos.tbDNI.Text);
                string nombre = fDatos.tbNombre.Text;
                DateTime fechaNacimiento = fDatos.dtpFechcaNacimiento.Value;

                var nueva = new PersonaDTO {Id=id1, DNI = dni, Nombre = nombre, FechaNacimiento = fechaNacimiento };

                await _clientesService.Actualizar(nueva);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message+"|"+ex.StackTrace,"Error en la consulta");
        }
    }
}
