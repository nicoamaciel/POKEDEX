using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;



namespace ConexionDBAPOKEDEX
{

    
    public partial class frmPokemon : Form
    {
        private List<Pokemon> listaPokemon;

        public frmPokemon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvPOKEMONS_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPOKEMONS.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.urlImagen);
        }

        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                listaPokemon = negocio.listar();
                dgvPOKEMONS.DataSource = listaPokemon;
                dgvPOKEMONS.Columns["UrlImagen"].Visible = false;
                /*Ocultar columna url imagen para mejorar visualizacion y evitar scroll*/
                cargarImagen(listaPokemon[0].urlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void cargarImagen(string imagen)
        {
            try
            {

                pbPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pbPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png");

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            /*Actualizar carga para ver apenas se agrega*/
            /*Llamar al metodo cargar*/
            cargar();

        }

        private void dgvPOKEMONS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            /*Pasar pokemon a modificar*/
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPOKEMONS.CurrentRow.DataBoundItem;
            /*Se lo pasa como parametro al constructor de la clase, por eso de duplicar */
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}
