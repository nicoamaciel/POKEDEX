using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using negocio;
 
namespace ConexionDBAPOKEDEX
{
    public class PokemonNegocio
    {
		
		public List<Pokemon> listar()
		{
			List<Pokemon> lista = new List<Pokemon>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;



			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D  where E.Id = P.IdTipo AND D.Id = P.IdDebilidad";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

                while (lector.Read())
                {
					Pokemon aux = new Pokemon();
					aux.Numero = (int)lector["Numero"];
					aux.Nombre = (string)lector["Nombre"];
					aux.Descripcion = (string)lector["Descripcion"];
					aux.urlImagen = (string)lector["UrlImagen"];
					/*Incoveniente cuando nace tipo no tiene instancia crear tipo = new elemento()*/
					/*Enlace de datos erroneo tipo objeto - modificar return*/
					aux.Tipo = new Elementos();
					aux.Tipo.Descripcion = (string)lector["Tipo"];
					aux.Debilidad = new Elementos();
					aux.Debilidad.Descripcion = (string)lector["Debilidad"];

					lista.Add(aux);
				}

				conexion.Close();
				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}


		}

		public void agregar(Pokemon nuevo)
        {
			AccesoDatos datos = new AccesoDatos();
            try
            {
				datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo)values(" + nuevo.Numero + ",' " + nuevo.Nombre + " ',' " + nuevo.Descripcion + " ', 1); ");
				datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
				datos.cerrarConexion();
            }

        }

		
	}
}
