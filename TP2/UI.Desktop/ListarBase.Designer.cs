namespace UI.Desktop
{
    partial class ListarBase
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
            this.tcListar = new System.Windows.Forms.ToolStripContainer();
            this.tlListar = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsListar = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcListar.ContentPanel.SuspendLayout();
            this.tcListar.TopToolStripPanel.SuspendLayout();
            this.tcListar.SuspendLayout();
            this.tlListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.tsListar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcListar
            // 
            // 
            // tcListar.ContentPanel
            // 
            this.tcListar.ContentPanel.Controls.Add(this.tlListar);
            this.tcListar.ContentPanel.Size = new System.Drawing.Size(482, 240);
            this.tcListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcListar.Location = new System.Drawing.Point(0, 0);
            this.tcListar.Name = "tcListar";
            this.tcListar.Size = new System.Drawing.Size(482, 265);
            this.tcListar.TabIndex = 0;
            this.tcListar.Text = "toolStripContainer1";
            // 
            // tcListar.TopToolStripPanel
            // 
            this.tcListar.TopToolStripPanel.Controls.Add(this.tsListar);
            // 
            // tlListar
            // 
            this.tlListar.ColumnCount = 2;
            this.tlListar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlListar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlListar.Controls.Add(this.btnActualizar, 0, 1);
            this.tlListar.Controls.Add(this.dgvListar, 0, 0);
            this.tlListar.Controls.Add(this.btnSalir, 1, 1);
            this.tlListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlListar.Location = new System.Drawing.Point(0, 0);
            this.tlListar.Name = "tlListar";
            this.tlListar.RowCount = 2;
            this.tlListar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlListar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlListar.Size = new System.Drawing.Size(482, 240);
            this.tlListar.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(323, 214);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.AllowUserToResizeColumns = false;
            this.dgvListar.AllowUserToResizeRows = false;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tlListar.SetColumnSpan(this.dgvListar, 2);
            this.dgvListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListar.Location = new System.Drawing.Point(3, 3);
            this.dgvListar.MultiSelect = false;
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersVisible = false;
            this.dgvListar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListar.Size = new System.Drawing.Size(476, 205);
            this.dgvListar.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(404, 214);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsListar
            // 
            this.tsListar.Dock = System.Windows.Forms.DockStyle.None;
            this.tsListar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsListar.Location = new System.Drawing.Point(3, 0);
            this.tsListar.Name = "tsListar";
            this.tsListar.Size = new System.Drawing.Size(112, 25);
            this.tsListar.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.nuevo_small;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.pencil_small1;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton1";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.trash_small1;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ListarBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 265);
            this.Controls.Add(this.tcListar);
            this.Name = "ListarBase";
            this.Text = "Listar";
            this.Load += new System.EventHandler(this.ListarBase_Load);
            this.tcListar.ContentPanel.ResumeLayout(false);
            this.tcListar.TopToolStripPanel.ResumeLayout(false);
            this.tcListar.TopToolStripPanel.PerformLayout();
            this.tcListar.ResumeLayout(false);
            this.tcListar.PerformLayout();
            this.tlListar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.tsListar.ResumeLayout(false);
            this.tsListar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcListar;
        private System.Windows.Forms.TableLayoutPanel tlListar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        protected System.Windows.Forms.DataGridView dgvListar;
        protected System.Windows.Forms.ToolStripButton tsbNuevo;
        protected System.Windows.Forms.ToolStripButton tsbEditar;
        protected System.Windows.Forms.ToolStripButton tsbEliminar;
        protected System.Windows.Forms.ToolStrip tsListar;
    }
}