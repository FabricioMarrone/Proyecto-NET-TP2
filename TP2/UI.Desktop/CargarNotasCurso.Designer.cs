namespace UI.Desktop
{
    partial class CargarNotasCurso
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApellidoDocente = new System.Windows.Forms.Label();
            this.dgvAlumnosDelCurso = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosDelCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alumnos en el curso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profesor:";
            // 
            // lblApellidoDocente
            // 
            this.lblApellidoDocente.AutoSize = true;
            this.lblApellidoDocente.Location = new System.Drawing.Point(447, 19);
            this.lblApellidoDocente.Name = "lblApellidoDocente";
            this.lblApellidoDocente.Size = new System.Drawing.Size(43, 13);
            this.lblApellidoDocente.TabIndex = 2;
            this.lblApellidoDocente.Text = "apellido";
            // 
            // dgvAlumnosDelCurso
            // 
            this.dgvAlumnosDelCurso.AllowUserToAddRows = false;
            this.dgvAlumnosDelCurso.AllowUserToDeleteRows = false;
            this.dgvAlumnosDelCurso.AllowUserToResizeColumns = false;
            this.dgvAlumnosDelCurso.AllowUserToResizeRows = false;
            this.dgvAlumnosDelCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosDelCurso.Location = new System.Drawing.Point(17, 54);
            this.dgvAlumnosDelCurso.Name = "dgvAlumnosDelCurso";
            this.dgvAlumnosDelCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnosDelCurso.Size = new System.Drawing.Size(503, 170);
            this.dgvAlumnosDelCurso.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(17, 255);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(444, 254);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CargarNotasCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 296);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvAlumnosDelCurso);
            this.Controls.Add(this.lblApellidoDocente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CargarNotasCurso";
            this.Text = "CargarNotasCurso";
            this.Load += new System.EventHandler(this.CargarNotasCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosDelCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApellidoDocente;
        private System.Windows.Forms.DataGridView dgvAlumnosDelCurso;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
    }
}