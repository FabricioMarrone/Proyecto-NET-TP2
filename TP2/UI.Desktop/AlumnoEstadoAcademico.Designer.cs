namespace UI.Desktop
{
    partial class AlumnoEstadoAcademico
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
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tblEstadoAcademico = new System.Windows.Forms.TableLayoutPanel();
            this.btnEstadoAcad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            this.tblEstadoAcademico.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            this.dgvInscripciones.AllowUserToResizeColumns = false;
            this.dgvInscripciones.AllowUserToResizeRows = false;
            this.dgvInscripciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEstadoAcademico.SetColumnSpan(this.dgvInscripciones, 2);
            this.dgvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 23);
            this.dgvInscripciones.MultiSelect = false;
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.RowHeadersVisible = false;
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(473, 275);
            this.dgvInscripciones.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(401, 304);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estdado Académico:";
            // 
            // tblEstadoAcademico
            // 
            this.tblEstadoAcademico.ColumnCount = 2;
            this.tblEstadoAcademico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEstadoAcademico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEstadoAcademico.Controls.Add(this.dgvInscripciones, 0, 1);
            this.tblEstadoAcademico.Controls.Add(this.label1, 0, 0);
            this.tblEstadoAcademico.Controls.Add(this.btnSalir, 1, 2);
            this.tblEstadoAcademico.Controls.Add(this.btnEstadoAcad, 0, 2);
            this.tblEstadoAcademico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEstadoAcademico.Location = new System.Drawing.Point(0, 0);
            this.tblEstadoAcademico.Name = "tblEstadoAcademico";
            this.tblEstadoAcademico.RowCount = 3;
            this.tblEstadoAcademico.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEstadoAcademico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEstadoAcademico.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEstadoAcademico.Size = new System.Drawing.Size(479, 330);
            this.tblEstadoAcademico.TabIndex = 3;
            // 
            // btnEstadoAcad
            // 
            this.btnEstadoAcad.Location = new System.Drawing.Point(3, 304);
            this.btnEstadoAcad.Name = "btnEstadoAcad";
            this.btnEstadoAcad.Size = new System.Drawing.Size(133, 23);
            this.btnEstadoAcad.TabIndex = 3;
            this.btnEstadoAcad.Text = "Emitir Estado Academico";
            this.btnEstadoAcad.UseVisualStyleBackColor = true;
            this.btnEstadoAcad.Click += new System.EventHandler(this.btnEstadoAcad_Click);
            // 
            // AlumnoEstadoAcademico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(479, 330);
            this.Controls.Add(this.tblEstadoAcademico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlumnoEstadoAcademico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado Academico";
            this.Load += new System.EventHandler(this.AlumnoEstadoAcademico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            this.tblEstadoAcademico.ResumeLayout(false);
            this.tblEstadoAcademico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tblEstadoAcademico;
        private System.Windows.Forms.Button btnEstadoAcad;
    }
}