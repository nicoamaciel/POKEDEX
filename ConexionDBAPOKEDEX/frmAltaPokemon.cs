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
using negocio;
namespace ConexionDBAPOKEDEX
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;

        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        /*Duplicar para modificar pokemon*/
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon poke = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();


            try
            {
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.urlImagen = txtUrlImagen.Text;
                poke.Tipo = (Elementos)cboTipo.SelectedItem;
                poke.Debilidad = (Elementos)cboTipo.SelectedItem;

                negocio.agregar(poke);
                MessageBox.Show("Agregado con exito");
                Close();
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementosNegocio elementosNegocio = new ElementosNegocio();
            try
            {
                cboTipo.DataSource = elementosNegocio.listar();
                cboDebilidad.DataSource = elementosNegocio.listar();
                /*Si el pokemo es != de null entonces es un modificado*/
                if(pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.urlImagen;
                    cargarImagen(pokemon.urlImagen);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
         }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            /*voy navegando con tab y se tiene que mostrar imagen, leer de url*/
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {

                pbPokemos.Load(imagen);
            }
            catch (Exception ex)
            {

                pbPokemos.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png");

            }

        }


    }
}
