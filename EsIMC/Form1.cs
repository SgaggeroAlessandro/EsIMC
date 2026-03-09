using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EsIMC 
{

    public struct Persona
    {
        public string Nome;
        public int Altezza;
        public int Peso;
        private string esito;

        public Persona(string nome, int altezza, int peso)
        {
            Nome = nome;
            Altezza = altezza;
            Peso = peso;

            
            double altezzaMetri = altezza / 100.0;
            double imc = peso / (altezzaMetri * altezzaMetri);

            if (imc < 18.5)
            {
                esito = "Sottopeso";
            }
            else if (imc >= 18.5 && imc < 25)
            {
                esito = "Normopeso";
            }
            else
            {
                esito = "Sovrappeso";
            }
        }

        public double CalcolaIMC()
        {
            double altezzaMetri = Altezza / 100.0;
            return Peso / (altezzaMetri * altezzaMetri);
        }

        public string GetEsito()
        {
            return esito;
        }

        public override string ToString()
        {
            return $"{Nome}, {Altezza} cm, {Peso} kg, Esito: {esito}";
        }
    }

    public partial class Form1 : Form
    {
        bool selezione = false;

        List<Persona> listaPersone = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
            pictureBoxBMI.BackgroundImage = Image.FromFile(@"C:\Users\alesg\OneDrive\Desktop\imc.png");
            pictureBoxBMI.BackgroundImageLayout = ImageLayout.Stretch;
            
            
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            string nome = textBoxCN.Text;

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Inserisci un nome valido");
                return;
            }

            bool pesook = int.TryParse(textBoxP.Text, out int peso);
            bool altezzaok = int.TryParse(textBoxA.Text, out int altezza);

            if (pesook == false || altezzaok == false)
            {
                MessageBox.Show("Inserisci peso e altezza validi");
                return;
            }

            Persona nPersona = new Persona(nome, altezza, peso);
            listaPersone.Add(nPersona);
            listBoxPersone.Items.Add(nPersona.ToString());
            string percorso = @"C:\Users\alesg\OneDrive\Desktop\persone.txt";
            string[] righe = { $"{nPersona.Nome};{nPersona.Altezza};{nPersona.Peso}" };
            File.AppendAllLines(percorso, righe);
           

            textBoxCN.Clear();
            textBoxP.Clear();
            textBoxA.Clear();
        }

        private void textBoxCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ' ')
            {
                e.KeyChar = (char)0; //carattere impostato a null, non prende il valore
            }
        }

        private void textBoxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }   
        }

        private void btnEsegui_Click(object sender, EventArgs e)
        {
            if (selezione == true)
            {
                if (rdBIMCS.Checked == true)
                {
                    if (listBoxPersone.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleziona una persona dalla lista");
                        return;
                    }

                    int indice = listBoxPersone.SelectedIndex;
                    Persona pSelezionata = listaPersone[indice];
                    double imc = pSelezionata.CalcolaIMC();

                    MessageBox.Show($"Persona: {pSelezionata.Nome}\nIMC: {imc.ToString()}");
                }
                else if (Media.Checked == true)
                {
                    if (listaPersone.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    double somma = 0;
                    for (int i = 0; i < listaPersone.Count; i++)
                    {
                        somma += listaPersone[i].CalcolaIMC();
                    }

                    double media = somma / listaPersone.Count;
                    MessageBox.Show("Media IMC: " + media.ToString());
                }
                else if (rdBModa.Checked == true)
                {
                    if (listaPersone.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<int> imcArrotondati = new List<int>();
                    for (int i = 0; i < listaPersone.Count; i++)
                    {
                        imcArrotondati.Add((int)Math.Round(listaPersone[i].CalcolaIMC()));
                    }

                    int moda = 0;
                    int maxFrequenza = 0;

                    for (int i = 0; i < imcArrotondati.Count; i++)
                    {
                        int frequenza = 0;
                        for (int j = 0; j < imcArrotondati.Count; j++)
                        {
                            if (imcArrotondati[j] == imcArrotondati[i])
                            {
                                frequenza++;
                            }
                        }

                        if (frequenza > maxFrequenza)
                        {
                            maxFrequenza = frequenza;
                            moda = imcArrotondati[i];
                        }
                    }

                    MessageBox.Show("Moda IMC: " + moda.ToString() + " (frequenza: " + maxFrequenza + ")");
                }
                else if (rdBMediana.Checked == true)
                {
                    if (listaPersone.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<double> listaIMC = new List<double>();
                    for (int i = 0; i < listaPersone.Count; i++)
                    {
                        listaIMC.Add(listaPersone[i].CalcolaIMC());
                    }

                    List<double> lC = new List<double>();
                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        lC.Add(listaIMC[i]);
                    }

                    List<double> lO = new List<double>();
                    while (lC.Count > 0)
                    {
                        double minimo = lC[0];
                        int indMin = 0;

                        for (int i = 1; i < lC.Count; i++)
                        {
                            if (lC[i] < minimo)
                            {
                                minimo = lC[i];
                                indMin = i;
                            }
                        }

                        lO.Add(minimo);
                        lC.RemoveAt(indMin);
                    }

                    double mediana;
                    int n = lO.Count;

                    if (n % 2 == 1)
                    {
                        mediana = lO[n / 2];
                    }
                    else
                    {
                        mediana = (lO[n / 2 - 1] + lO[n / 2]) / 2.0;
                    }

                    MessageBox.Show("Mediana IMC: " + mediana.ToString());
                }
                else if (rdbVarianza.Checked == true)
                {
                    if (listaPersone.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    double somma = 0;
                    for (int i = 0; i < listaPersone.Count; i++)
                    {
                        somma += listaPersone[i].CalcolaIMC();
                    }
                    double media = somma / listaPersone.Count;

                    double sScarti = 0;
                    for (int i = 0; i < listaPersone.Count; i++)
                    {
                        double scarto = listaPersone[i].CalcolaIMC() - media;
                        sScarti += scarto * scarto;
                    }

                    double varianza = sScarti / listaPersone.Count;
                    MessageBox.Show("Varianza IMC: " + varianza.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleziona un calcolo da eseguire");
            }
        }

        private void rdBIMCS_CheckedChanged(object sender, EventArgs e)
        {
            selezione = true;
        }

        private void Media_CheckedChanged(object sender, EventArgs e)
        {
            selezione = true;
        }

        private void rdBModa_CheckedChanged(object sender, EventArgs e)
        {
            selezione = true;
        }

        private void rdBMediana_CheckedChanged(object sender, EventArgs e)
        {
            selezione = true;
        }

        private void rdbVarianza_CheckedChanged(object sender, EventArgs e)
        {
            selezione = true;
        }

        
    }
}