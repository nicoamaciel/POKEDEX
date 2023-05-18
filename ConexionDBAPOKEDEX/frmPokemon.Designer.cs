
namespace ConexionDBAPOKEDEX
{
    partial class frmPokemon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPOKEMONS = new System.Windows.Forms.DataGridView();
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOKEMONS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPOKEMONS
            // 
            this.dgvPOKEMONS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.dgvPOKEMONS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPOKEMONS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOKEMONS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dgvPOKEMONS.Location = new System.Drawing.Point(12, 29);
            this.dgvPOKEMONS.Name = "dgvPOKEMONS";
            this.dgvPOKEMONS.Size = new System.Drawing.Size(558, 250);
            this.dgvPOKEMONS.TabIndex = 0;
            this.dgvPOKEMONS.SelectionChanged += new System.EventHandler(this.dgvPOKEMONS_SelectionChanged);
            // 
            // pbPokemon
            // 
            this.pbPokemon.Location = new System.Drawing.Point(586, 29);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(275, 250);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPokemon.TabIndex = 1;
            this.pbPokemon.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 294);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(873, 339);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbPokemon);
            this.Controls.Add(this.dgvPOKEMONS);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOKEMONS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPOKEMONS;
        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.Button btnAgregar;
    }
}

