using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsIMC //IMC = Peso (kg) / [Altezza (m)]² 
{
    public partial class Form1 : Form
    {
        string nome;
        int peso, altezza;
        double imc;
        public Form1()
        {
            InitializeComponent();
            pictureBoxBMI.BackgroundImage = Image.FromFile(@"C:\Users\alesg\OneDrive\Desktop\imc.png");
            pictureBoxBMI.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEsegui_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            nome = textBoxCN.Text;

            MessageBox.Show(nome);
        }
    }
}
//if(!Char.isNumber(e.KeyChar) && e.keychar != ...

//e.keychar = (char)0;