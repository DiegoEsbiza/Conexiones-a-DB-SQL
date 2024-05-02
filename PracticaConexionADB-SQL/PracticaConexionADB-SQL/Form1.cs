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

namespace PracticaConexionADB_SQL
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
            listaPokemon = negocio.Listar();
            DGVPokemons.DataSource = listaPokemon;
            DGVPokemons.Columns["UrlImagen"].Visible = false;
            pbPokemon.Load(listaPokemon[0].UrlImagen);
        }

        private void DGVPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)DGVPokemons.CurrentRow.DataBoundItem;
            pbPokemon.Load(seleccionado.UrlImagen);
        }
    }
}
