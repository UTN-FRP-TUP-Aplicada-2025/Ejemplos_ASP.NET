using Ejemplo_02_1_Cliente_RestAPI.ClientServices;

namespace Ejemplo_02_Cliente_RestAPI
{
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
                dataGridView1.Rows.Add(new object[] { p.DNI, p.Nombre });
            }
        }
    }
}
