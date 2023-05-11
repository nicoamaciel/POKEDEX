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

    
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();
            dgvPOKEMONS.DataSource = listaPokemon;
            cargarImagen(listaPokemon[0].urlImagen);




        }

        private void dgvPOKEMONS_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPOKEMONS.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.urlImagen);
        }


        private void cargarImagen(string imagen)
        {
            try
            {

                pbPokemon.Load(imagen);
            }
            catch (Exception)
            {

                pbPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png");

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();

            alta.ShowDialog();
        }
    }
}
