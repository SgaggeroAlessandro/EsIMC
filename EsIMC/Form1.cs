using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        string output; //riga che verrà inserita nella listbox
        double imc; 

        bool selezione = false; //per verificare se è stato selezionato un radiobutton

        List<object> persona = new List<object>();

        public Form1()
        {
            InitializeComponent();
            pictureBoxBMI.BackgroundImage = Image.FromFile(@"C:\Users\alesg\OneDrive\Desktop\imc.png");
            pictureBoxBMI.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            nome = textBoxCN.Text;

          
            bool pesook = int.TryParse(textBoxP.Text, out int ris); //verifica se il valore inserito nel textbox del peso è valido, in quel caso restituisce vero e inizializza una variabile ris con il valore letto

            if (pesook == true) // se il valore è valido
            {
                peso = ris;
            }

            bool altezzaok = int.TryParse(textBoxA.Text, out int ris2);

            if (altezzaok == true)
            {
                altezza = ris2;
              
            }

            persona.Add(nome); //aggiunge alla lista persona
            persona.Add(altezza.ToString()); //converte in testo e aggiunge alla lista
            persona.Add(peso.ToString());

            output = $"{nome}, {altezza} cm, {peso} kg"; //riga nella list box
            listBoxPersone.Items.Add(output);

            textBoxCN.Clear(); //elimina tutto ciò che era stato inserito precedentemente
            textBoxP.Clear();
            textBoxA.Clear();
        }

        private void textBoxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)//verifica se il valore è valido
            {
                e.KeyChar = (char)0; //altrimenti non lo legge

            }
        }

        private void btnEsegui_Click(object sender, EventArgs e)
        {
            if (selezione == true)
            {
                if (rdBIMCS.Checked == true) //se è stato selezionato il radio button del calcolo dell'IMC
                {
                    if (listBoxPersone.SelectedItem == null) //se non è stata selezionata nessuna persona
                    {
                        MessageBox.Show("Seleziona una persona dalla lista");
                        return;
                    }

                    for (int i = 0; i < persona.Count; i += 3) //+3 perché ogni persona è formata da 3 parametri. nome, peso, altezza
                    {
                        string p = $"{persona[i]}, {persona[i + 1]} cm, {persona[i + 2]} kg"; //crea una stringa con i dati della persona alla posizione i, i+1 e i+2 (nome, altezza, peso)

                        if (listBoxPersone.SelectedItem.ToString() == p)
                        {
                            MessageBox.Show("Persona selezionata: " + persona[i].ToString());
                            altezza = int.Parse(persona[i + 1].ToString()); //dalla posizione i aggiunge 1 per leggere l'altezza e converte in intero, stessa cosa per il peso
                            peso = int.Parse(persona[i + 2].ToString());
                            break; // si ferma perché ha trovato laa persona
                        }
                    }

                    double aM = altezza / 100.0; //converte l'altezza in metri
                    imc = peso / (aM * aM);
                    MessageBox.Show("IMC: " + imc.ToString()); //stampa il risultato
                }
                else if (Media.Checked == true)
                {
                    if (persona.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<double> listaIMC = CalcolaIMCTutti(); //chiama la funzione che calcola l'IMC di tutte le persone e restituisce una lista con i risultati
                    double somma = 0;

                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        somma += listaIMC[i];
                    }

                    double media = somma / listaIMC.Count;
                    MessageBox.Show("Media IMC: " + media.ToString());
                }
                else if (rdBModa.Checked == true)
                {
                    if (persona.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<double> listaIMC = CalcolaIMCTutti();

                   
                    List<int> imcArrotondati = new List<int>();
                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        imcArrotondati.Add((int)Math.Round(listaIMC[i])); //arrotonda l'IMC al numero intero più vicino e lo aggiunge alla lista imcArrotondati, altrimenti sarebbe praticamente impossibile trovare una moda
                    }

                    int moda = 0;
                    int maxFrequenza = 0;

                    for (int i = 0; i < imcArrotondati.Count; i++)
                    {
                        int frequenza = 0;
                        for (int j = 0; j < imcArrotondati.Count; j++)
                        {
                            if (imcArrotondati[j] == imcArrotondati[i]) //conta quante volte appare l'IMC arrotondato alla posizione i nella lista 
                            {
                                frequenza++;
                            }
                        }

                        if (frequenza > maxFrequenza) //se ha una frequenza maggiore della frequenza massima finora trovata, aggiorna la moda e la frequenza massima
                        {
                            maxFrequenza = frequenza;
                            moda = imcArrotondati[i];
                        }
                    }

                    MessageBox.Show("Moda IMC: " + moda.ToString() + " (frequenza: " + maxFrequenza + ")");
                }
                else if (rdBMediana.Checked == true)
                {
                    if (persona.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<double> listaIMC = CalcolaIMCTutti();
                    List<double> listaOrdinata = new List<double>(); 


                    List<double> listaCopia = new List<double>(); //Copia tutti gli elementi dalla lista listaIMC in una nuova lista listaCopia, per non modificare la lista originale
                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        listaCopia.Add(listaIMC[i]);
                    }

                    while (listaCopia.Count > 0)
                    {
                        
                        double minimo = listaCopia[0];
                        int indiceMinimoPos = 0;

                        for (int i = 1; i < listaCopia.Count; i++)
                        {
                            if (listaCopia[i] < minimo)
                            {
                                minimo = listaCopia[i]; //trova il minimo nella lista
                                indiceMinimoPos = i; //salva la posizione del minimo trovato
                            }
                        }

                   
                        listaOrdinata.Add(minimo);//Aggiunge il valore minimo alla fine della lista ordinata


                        listaCopia.RemoveAt(indiceMinimoPos);//Rimuove l'elemento alla posizione indiceMinimoPos dalla lista copia, per non trovare più volte lo stesso valore
                    }

                    
                    double mediana;
                    int n = listaOrdinata.Count;

                    if (n % 2 == 1) // se la lista ha un numero dispari di elementi, la mediana è l'elemento centrale
                    {
                        mediana = listaOrdinata[n / 2];
                    }
                    else //altrimenti è la media dei due elementi centrali
                    {
                        mediana = (listaOrdinata[n / 2 - 1] + listaOrdinata[n / 2]) / 2.0;
                    }

                    MessageBox.Show("Mediana IMC: " + mediana.ToString());
                }
                else if (rdbVarianza.Checked == true)
                {
                    if (persona.Count == 0)
                    {
                        MessageBox.Show("Nessuna persona nella lista");
                        return;
                    }

                    List<double> listaIMC = CalcolaIMCTutti();

                   
                    double somma = 0;
                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        somma += listaIMC[i];
                    }
                    double media = somma / listaIMC.Count;

                   
                    double sommaScartiQuadrati = 0;
                    for (int i = 0; i < listaIMC.Count; i++)
                    {
                        double scarto = listaIMC[i] - media;
                        sommaScartiQuadrati += scarto * scarto;
                    }

                    double varianza = sommaScartiQuadrati / listaIMC.Count;
                    MessageBox.Show("Varianza IMC: " + varianza.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleziona un calcolo da eseguire");
            }
        }

       
        private List<double> CalcolaIMCTutti()
        {
            List<double> listaIMC = new List<double>();

            for (int i = 0; i < persona.Count; i += 3)
            {
                int alt = int.Parse(persona[i + 1].ToString());
                int pes = int.Parse(persona[i + 2].ToString());

                double altMetri = alt / 100.0;
                double imcCalcolato = pes / (altMetri * altMetri);
                listaIMC.Add(imcCalcolato); //aggiunge il valore alla lista
            }

            return listaIMC;
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = (char)0;
            }
        }

        private void rdBIMCS_CheckedChanged(object sender, EventArgs e) //se è stato selezionato, imposta selezione a vero
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