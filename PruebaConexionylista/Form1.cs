using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaConexionylista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocioart = new ArticuloNegocio();

            dgvMarcas.Visible = false;
            dgvArticulos.DataSource = negocioart.listarart();
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "c";
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvMarcas.Visible=true;
            MarcaNegocio negocio = new MarcaNegocio();

            dgvMarcas.DataSource = negocio.listar();
        }
    }
}
