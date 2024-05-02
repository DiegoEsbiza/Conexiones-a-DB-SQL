using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using dominio;

namespace negocio
{ 
    public class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader Lector;

            try 
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database = POKEDEX_DB; integrated security = true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE E.Id = P.IdTipo AND D.Id = P.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();
                Lector = comando.ExecuteReader();     

                while (Lector.Read()) 
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = Lector.GetInt32(0);
                    aux.Nombre = (string)Lector["Nombre"];
                    aux.Descripcion = (string)Lector["Descripcion"];
                    aux.UrlImagen = (string)Lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)Lector["Debilidad"];

                    lista.Add(aux);
                }
                return lista; 
            } 
            catch (Exception ex) 
            { 
                throw ex;
            }
            finally 
            {
                conexion.Close();            
            }
        }
    }
}
