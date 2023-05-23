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
            Text = "Modificar Pokemon";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                if(pokemon == null)
                    pokemon = new Pokemon();
                
                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.urlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elementos)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elementos)cboTipo.SelectedItem;

                /*Si el id es distinto de cero estoy modificando*/
                if(pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado con exito");

                }

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
                /*Trabajar con clave y valor*/
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementosNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                /*Si el pokemo es != de null entonces es un modificado*/
                if(pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.urlImagen;
                    cargarImagen(pokemon.urlImagen);
                    /*Preseleccion tipo y debilidad en modificar*/
                    cboTipo.SelectedValue = pokemon.Tipo.ID;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.ID;
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
