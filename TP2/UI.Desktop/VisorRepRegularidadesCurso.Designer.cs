namespace UI.Desktop
{
    partial class VisorRepRegularidadesCur
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InscripcionAlumnoExtendentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonaExtendedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvReportesAcademia = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionAlumnoExtendentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaExtendedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InscripcionAlumnoExtendentBindingSource
            // 
            this.InscripcionAlumnoExtendentBindingSource.DataSource = typeof(Business.Logic.InscripcionAlumnoLogic.InscripcionAlumnoExtendent);
            // 
            // PersonaExtendedBindingSource
            // 
            this.PersonaExtendedBindingSource.DataSource = typeof(Business.Logic.PersonaLogic.PersonaExtended);
            // 
            // rvReportesAcademia
            // 
            this.rvReportesAcademia.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Alumnos_Inscriptos";
            reportDataSource1.Value = this.InscripcionAlumnoExtendentBindingSource;
            reportDataSource2.Name = "Docente_Datos";
            reportDataSource2.Value = this.PersonaExtendedBindingSource;
            this.rvReportesAcademia.LocalReport.DataSources.Add(reportDataSource1);
            this.rvReportesAcademia.LocalReport.DataSources.Add(reportDataSource2);
            this.rvReportesAcademia.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.RepRegulidadesDeCurso.rdlc";
            this.rvReportesAcademia.Location = new System.Drawing.Point(0, 0);
            this.rvReportesAcademia.Name = "rvReportesAcademia";
            this.rvReportesAcademia.Size = new System.Drawing.Size(704, 265);
            this.rvReportesAcademia.TabIndex = 0;
            // 
            // VisorRepRegularidadesCur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 265);
            this.Controls.Add(this.rvReportesAcademia);
            this.Name = "VisorRepRegularidadesCur";
            this.Text = "Listado de Regularidades";
            this.Load += new System.EventHandler(this.VisorRepRegularidadesCur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionAlumnoExtendentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaExtendedBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReportesAcademia;
        private System.Windows.Forms.BindingSource InscripcionAlumnoExtendentBindingSource;
        private System.Windows.Forms.BindingSource PersonaExtendedBindingSource;
    }
}