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
				comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D  where E.Id = P.IdTipo AND D.Id = P.IdDebilidad And P.Activo = 1 ";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

                while (lector.Read())
                {
					Pokemon aux = new Pokemon();
					aux.Id = (int)lector["Id"];
					aux.Numero = (int)lector["Numero"];
					aux.Nombre = (string)lector["Nombre"];
					aux.Descripcion = (string)lector["Descripcion"];

					/*Si lo que esta dentro del lector esta null o no*/
					/*! negado si no es null, lo leo*/
					/*Si la columna admite nulos no es necesario*/
					/*if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))*/
					
					if(!(lector["UrlImagen"] is DBNull))
						aux.urlImagen = (string)lector["UrlImagen"];


					/*Incoveniente cuando nace tipo no tiene instancia crear tipo = new elemento()*/
					/*Enlace de datos erroneo tipo objeto - modificar return*/
					aux.Tipo = new Elementos();
					aux.Tipo.ID = (int)lector["IdTipo"];
					aux.Tipo.Descripcion = (string)lector["Tipo"];
					aux.Debilidad = new Elementos();
					aux.Debilidad.ID = (int)lector["IdDebilidad"];
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
				datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + " ,' " + nuevo.Nombre + " ',' " + nuevo.Descripcion + " ', 1, @idTipo, @idDebilidad, @urlImagen)");
				/*Parametro de seteo de cagar en acceso a datos -onda declararlo para store procedure-*/
				datos.setearParametro("@idTipo", nuevo.Tipo.ID);
				datos.setearParametro("@idDebilidad", nuevo.Debilidad.ID);
				datos.setearParametro("@urlImagen", nuevo.urlImagen);
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

		public void modificar(Pokemon poke)
        {
			AccesoDatos datos = new AccesoDatos();

            try
            {
				datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc , UrlImagen = @img , IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @id ");
				datos.setearParametro("@numero", poke.Numero);
				datos.setearParametro("@nombre", poke.Nombre);
				datos.setearParametro("@desc", poke.Descripcion);
				datos.setearParametro("@img", poke.urlImagen);
				datos.setearParametro("@idTipo", poke.Tipo.ID);
				datos.setearParametro("@idDebilidad", poke.Debilidad.ID);
				datos.setearParametro("@id", poke.Id);

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
	
		public void eliminarLogico (int id)
        {
            try
            {
				AccesoDatos datos = new AccesoDatos();
				datos.setearConsulta(" update POKEMONS set Activo = 0 where id = @id ");
				datos.setearParametro("@id", id);
				datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
			List<Pokemon> lista = new List<Pokemon>();
			AccesoDatos datos = new AccesoDatos();

            try
            {
				string consulta = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D  where E.Id = P.IdTipo AND D.Id = P.IdDebilidad And P.Activo = 1 And ";
				if(campo == "Numero")
                {
                    switch(criterio)
					{
						case "Mayor a":
							consulta += "Numero > " + filtro;
							break;
						case "Menor a":
							consulta += "Numero < " + filtro;
							break;
						default:
							consulta += "Numero =" + filtro;
							break;
					
					}
                }
				else if(campo == "Nombre")
				{
                    switch (criterio)
                    {
						case "Comienza con":
							consulta += "Nombre like '" + filtro + "%' ";
							break;
						case "Termina con":
							consulta += "Nombre like '%" + filtro + "'";
							break;
						default:
							consulta += "Nombre like '%" + filtro + "%'";
							break;
					}

                }
                else
                {
                    switch (criterio)
                    {
						case "Comienza con":
							consulta += "P.Descripcion like '" + filtro + "%' ";
							break;
						case "Termina con":
							consulta += "P.Descripcion like '%" + filtro + "'";
							break;
						default:
							consulta += "P.Descripcion like '%" + filtro + "%'";
							break;

					}

                }

				datos.setearConsulta(consulta);
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Pokemon aux = new Pokemon();
					aux.Id = (int)datos.Lector["Id"];
					aux.Numero = (int)datos.Lector["Numero"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];


					if (!(datos.Lector["UrlImagen"] is DBNull))
						aux.urlImagen = (string)datos.Lector["UrlImagen"];


					
					aux.Tipo = new Elementos();
					aux.Tipo.ID = (int)datos.Lector["IdTipo"];
					aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
					aux.Debilidad = new Elementos();
					aux.Debilidad.ID = (int)datos.Lector["IdDebilidad"];
					aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

					lista.Add(aux);
				}


				return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


}
