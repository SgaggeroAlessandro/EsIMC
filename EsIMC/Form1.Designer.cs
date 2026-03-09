namespace EsIMC
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxCN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.listBoxPersone = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEsegui = new System.Windows.Forms.Button();
            this.rdbVarianza = new System.Windows.Forms.RadioButton();
            this.btnSalva = new System.Windows.Forms.Button();
            this.rdBMediana = new System.Windows.Forms.RadioButton();
            this.rdBModa = new System.Windows.Forms.RadioButton();
            this.Media = new System.Windows.Forms.RadioButton();
            this.rdBIMCS = new System.Windows.Forms.RadioButton();
            this.pictureBoxBMI = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBMI)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCN
            // 
            this.textBoxCN.Location = new System.Drawing.Point(12, 38);
            this.textBoxCN.Name = "textBoxCN";
            this.textBoxCN.Size = new System.Drawing.Size(154, 22);
            this.textBoxCN.TabIndex = 0;
            this.textBoxCN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCN_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cognome e Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Peso (in kg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(662, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Altezza (in cm)";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(666, 38);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(100, 22);
            this.textBoxA.TabIndex = 4;
            this.textBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxA_KeyPress);
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(214, 38);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(100, 22);
            this.textBoxP.TabIndex = 5;
            this.textBoxP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxP_KeyPress);
            // 
            // listBoxPersone
            // 
            this.listBoxPersone.FormattingEnabled = true;
            this.listBoxPersone.ItemHeight = 16;
            this.listBoxPersone.Location = new System.Drawing.Point(16, 81);
            this.listBoxPersone.Name = "listBoxPersone";
            this.listBoxPersone.Size = new System.Drawing.Size(772, 276);
            this.listBoxPersone.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEsegui);
            this.panel1.Controls.Add(this.rdbVarianza);
            this.panel1.Controls.Add(this.btnSalva);
            this.panel1.Controls.Add(this.rdBMediana);
            this.panel1.Controls.Add(this.rdBModa);
            this.panel1.Controls.Add(this.Media);
            this.panel1.Controls.Add(this.rdBIMCS);
            this.panel1.Location = new System.Drawing.Point(17, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 135);
            this.panel1.TabIndex = 8;
            // 
            // btnEsegui
            // 
            this.btnEsegui.Location = new System.Drawing.Point(562, 87);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(124, 23);
            this.btnEsegui.TabIndex = 10;
            this.btnEsegui.Text = "CALCOLA";
            this.btnEsegui.UseVisualStyleBackColor = true;
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // rdbVarianza
            // 
            this.rdbVarianza.AutoSize = true;
            this.rdbVarianza.Location = new System.Drawing.Point(694, 38);
            this.rdbVarianza.Name = "rdbVarianza";
            this.rdbVarianza.Size = new System.Drawing.Size(121, 20);
            this.rdbVarianza.TabIndex = 4;
            this.rdbVarianza.TabStop = true;
            this.rdbVarianza.Text = "VARIANZA IMC";
            this.rdbVarianza.UseVisualStyleBackColor = true;
            this.rdbVarianza.CheckedChanged += new System.EventHandler(this.rdbVarianza_CheckedChanged);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(197, 87);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(149, 23);
            this.btnSalva.TabIndex = 9;
            this.btnSalva.Text = "SALVA PERSONA";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // rdBMediana
            // 
            this.rdBMediana.AutoSize = true;
            this.rdBMediana.Location = new System.Drawing.Point(562, 38);
            this.rdBMediana.Name = "rdBMediana";
            this.rdBMediana.Size = new System.Drawing.Size(115, 20);
            this.rdBMediana.TabIndex = 3;
            this.rdBMediana.TabStop = true;
            this.rdBMediana.Text = "MEDIANA IMC";
            this.rdBMediana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdBMediana.UseVisualStyleBackColor = true;
            this.rdBMediana.CheckedChanged += new System.EventHandler(this.rdBMediana_CheckedChanged);
            // 
            // rdBModa
            // 
            this.rdBModa.AutoSize = true;
            this.rdBModa.Location = new System.Drawing.Point(406, 38);
            this.rdBModa.Name = "rdBModa";
            this.rdBModa.Size = new System.Drawing.Size(94, 20);
            this.rdBModa.TabIndex = 2;
            this.rdBModa.TabStop = true;
            this.rdBModa.Text = "MODA IMC";
            this.rdBModa.UseVisualStyleBackColor = true;
            this.rdBModa.CheckedChanged += new System.EventHandler(this.rdBModa_CheckedChanged);
            // 
            // Media
            // 
            this.Media.AutoSize = true;
            this.Media.Location = new System.Drawing.Point(250, 38);
            this.Media.Name = "Media";
            this.Media.Size = new System.Drawing.Size(96, 20);
            this.Media.TabIndex = 1;
            this.Media.TabStop = true;
            this.Media.Text = "MEDIA IMC";
            this.Media.UseVisualStyleBackColor = true;
            this.Media.CheckedChanged += new System.EventHandler(this.Media_CheckedChanged);
            // 
            // rdBIMCS
            // 
            this.rdBIMCS.AutoSize = true;
            this.rdBIMCS.Location = new System.Drawing.Point(14, 38);
            this.rdBIMCS.Name = "rdBIMCS";
            this.rdBIMCS.Size = new System.Drawing.Size(177, 20);
            this.rdBIMCS.TabIndex = 0;
            this.rdBIMCS.TabStop = true;
            this.rdBIMCS.Text = "CALCOLO IMC SINGOLO";
            this.rdBIMCS.UseVisualStyleBackColor = true;
            this.rdBIMCS.CheckedChanged += new System.EventHandler(this.rdBIMCS_CheckedChanged);
            // 
            // pictureBoxBMI
            // 
            this.pictureBoxBMI.Location = new System.Drawing.Point(340, 9);
            this.pictureBoxBMI.Name = "pictureBoxBMI";
            this.pictureBoxBMI.Size = new System.Drawing.Size(225, 66);
            this.pictureBoxBMI.TabIndex = 7;
            this.pictureBoxBMI.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxBMI);
            this.Controls.Add(this.listBoxPersone);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBMI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.ListBox listBoxPersone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdBMediana;
        private System.Windows.Forms.RadioButton rdBModa;
        private System.Windows.Forms.RadioButton Media;
        private System.Windows.Forms.RadioButton rdBIMCS;
        private System.Windows.Forms.RadioButton rdbVarianza;
        private System.Windows.Forms.Button btnEsegui;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.PictureBox pictureBoxBMI;
    }
}

