namespace Cups.Forms.Validar
{
    partial class FormValidar
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
            this.lblEmbarque = new System.Windows.Forms.Label();
            this.txbEmbarque = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboxAndenes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmbarque
            // 
            this.lblEmbarque.AutoSize = true;
            this.lblEmbarque.Location = new System.Drawing.Point(106, 96);
            this.lblEmbarque.Name = "lblEmbarque";
            this.lblEmbarque.Size = new System.Drawing.Size(103, 20);
            this.lblEmbarque.TabIndex = 0;
            this.lblEmbarque.Text = "N.-Embarque";
            // 
            // txbEmbarque
            // 
            this.txbEmbarque.Location = new System.Drawing.Point(110, 136);
            this.txbEmbarque.Name = "txbEmbarque";
            this.txbEmbarque.Size = new System.Drawing.Size(264, 26);
            this.txbEmbarque.TabIndex = 1;
            this.txbEmbarque.Text = "19100165";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(110, 169);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(264, 32);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(444, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(735, 608);
            this.dataGridView1.TabIndex = 3;
            // 
            // cboxAndenes
            // 
            this.cboxAndenes.FormattingEnabled = true;
            this.cboxAndenes.Location = new System.Drawing.Point(110, 228);
            this.cboxAndenes.Name = "cboxAndenes";
            this.cboxAndenes.Size = new System.Drawing.Size(264, 28);
            this.cboxAndenes.TabIndex = 4;
            this.cboxAndenes.Visible = false;
            // 
            // FormValidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 844);
            this.Controls.Add(this.cboxAndenes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txbEmbarque);
            this.Controls.Add(this.lblEmbarque);
            this.Name = "FormValidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormValidar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmbarque;
        private System.Windows.Forms.TextBox txbEmbarque;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboxAndenes;
    }
}