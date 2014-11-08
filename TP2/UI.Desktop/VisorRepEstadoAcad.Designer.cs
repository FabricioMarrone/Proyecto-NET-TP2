namespace UI.Desktop
{
    partial class VisorRepEstadoAcad
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InscripcionAlumnoExtendentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvEstadoAcademico = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionAlumnoExtendentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InscripcionAlumnoExtendentBindingSource
            // 
            this.InscripcionAlumnoExtendentBindingSource.DataSource = typeof(Business.Logic.InscripcionAlumnoLogic.InscripcionAlumnoExtendent);
            // 
            // rvEstadoAcademico
            // 
            this.rvEstadoAcademico.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Materias";
            reportDataSource1.Value = this.InscripcionAlumnoExtendentBindingSource;
            this.rvEstadoAcademico.LocalReport.DataSources.Add(reportDataSource1);
            this.rvEstadoAcademico.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.RepEstadoAcademico.rdlc";
            this.rvEstadoAcademico.Location = new System.Drawing.Point(0, 0);
            this.rvEstadoAcademico.Name = "rvEstadoAcademico";
            this.rvEstadoAcademico.Size = new System.Drawing.Size(715, 395);
            this.rvEstadoAcademico.TabIndex = 0;
            // 
            // VisorRepEstadoAcad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 395);
            this.Controls.Add(this.rvEstadoAcademico);
            this.Name = "VisorRepEstadoAcad";
            this.Text = "VisorRepEstadoAcad";
            this.Load += new System.EventHandler(this.VisorRepEstadoAcad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionAlumnoExtendentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEstadoAcademico;
        private System.Windows.Forms.BindingSource InscripcionAlumnoExtendentBindingSource;
    }
}