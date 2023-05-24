using System;
using System.Collections.Generic;
using System.Windows.Forms;



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
            cbxCampo.Items.Add("Numero");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Descripcion");
        }

        private void dgvPOKEMONS_SelectionChanged(object sender, EventArgs e)
        {

            /*Se rompe si quiere transformar el null(la nada) es un pokemon*/
            if(dgvPOKEMONS.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPOKEMONS.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.urlImagen);

            }

        }

        private void cargar()
        {
            ///Carga imagen
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                listaPokemon = negocio.listar();
                dgvPOKEMONS.DataSource = listaPokemon;
                ocultarColumnas();
                /*Ocultar columna url imagen para mejorar visualizacion y evitar scroll*/
                cargarImagen(listaPokemon[0].urlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvPOKEMONS.Columns["UrlImagen"].Visible = false;
            dgvPOKEMONS.Columns["Id"].Visible = false;
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

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("De verdad desea eliminar el registro?");
                if (respuesta == DialogResult.OK)
                {
                    seleccionado = (Pokemon)dgvPOKEMONS.CurrentRow.DataBoundItem;
                    negocio.eliminarLogico(seleccionado.Id);
                    cargar();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            /*Crear lista filtrada de pokemos - propia de la clase*/

            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;

            if( filtro != "")
            {
            /*lisataPokemon tipo list -tipo coleccion- */
            /*x => x.Nombre --> lamda ciclo contra la lista - como un foreach*/
            /*ToUpper pasa todo a miniscula - cambiar ambos para que busque en miniscula*/
            /*contains cadena que compara contenido y devuelve true para buscar coincidencia*/
            listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listaFiltrada = listaPokemon;
            }


            dgvPOKEMONS.DataSource = null;
            dgvPOKEMONS.DataSource = listaFiltrada;
            ocultarColumnas();


        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxCampo.SelectedItem.ToString();
            if (opcion == "Numero")
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Mayor a");
                cbxCriterio.Items.Add("Menor a");
                cbxCriterio.Items.Add("Igual a");
            }
            else
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Comienza con");
                cbxCriterio.Items.Add("Termina con");
                cbxCriterio.Items.Add("Contiene");
            }
             
        }

        private void Buscar2_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dgvPOKEMONS.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
