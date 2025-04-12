using miForumulario.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miForumulario
{
    public partial class Form1 : Form
    {

        Crud Micrud = new Crud();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSaludar_Click(object sender, EventArgs e)
        {
            String saludo = $"Hola {textBoxNombre.Text} te saludo desde el formulario";
            MessageBox.Show(saludo,"Un Saludo ✌️✌️");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            string nombre = textBoxNombre.Text;
            string seccion = textBoxSeccion.Text;
            string email =  textBoxCorreo.Text;
            int resultado = Micrud.AgregarAlumno(carnet, nombre, seccion, email);
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
