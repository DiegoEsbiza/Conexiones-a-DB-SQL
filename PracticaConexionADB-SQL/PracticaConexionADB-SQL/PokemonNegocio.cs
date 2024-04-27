using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace PracticaConexionADB_SQL
{ 
    internal class PokemonNegocio
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
                comando.CommandText = "SELECT Numero, Nombre, Descripcion FROM POKEMONS";
                comando.Connection = conexion;

                conexion.Open();
                Lector = comando.ExecuteReader();     

                while (Lector.Read()) 
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = Lector.GetInt32(0);
                    aux.Nombre = (string)Lector["Nombre"];
                    aux.Descripcion = (string)Lector["Descripcion"];

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
