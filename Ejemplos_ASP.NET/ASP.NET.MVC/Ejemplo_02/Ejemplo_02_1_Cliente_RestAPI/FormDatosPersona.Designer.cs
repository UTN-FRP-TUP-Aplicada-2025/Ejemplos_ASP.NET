namespace Ejemplo_02_1_Cliente_RestAPI
{
    partial class FormDatosPersona
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
            tbId = new TextBox();
            tbNombre = new TextBox();
            tbDNI = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpFechcaNacimiento = new DateTimePicker();
            label4 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // tbId
            // 
            tbId.Location = new Point(200, 26);
            tbId.Margin = new Padding(4);
            tbId.Name = "tbId";
            tbId.Size = new Size(287, 29);
            tbId.TabIndex = 0;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(200, 133);
            tbNombre.Margin = new Padding(4);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(287, 29);
            tbNombre.TabIndex = 1;
            // 
            // tbDNI
            // 
            tbDNI.Location = new Point(200, 78);
            tbDNI.Margin = new Padding(4);
            tbDNI.Name = "tbDNI";
            tbDNI.Size = new Size(287, 29);
            tbDNI.TabIndex = 2;
            tbDNI.TextChanged += tbDNI_TextChanged;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(93, 257);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(96, 32);
            button1.TabIndex = 3;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(23, 21);
            label1.TabIndex = 4;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 136);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 86);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 6;
            label3.Text = "DNI";
            // 
            // dtpFechcaNacimiento
            // 
            dtpFechcaNacimiento.Location = new Point(200, 194);
            dtpFechcaNacimiento.Margin = new Padding(4);
            dtpFechcaNacimiento.Name = "dtpFechcaNacimiento";
            dtpFechcaNacimiento.Size = new Size(287, 29);
            dtpFechcaNacimiento.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 194);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(152, 21);
            label4.TabIndex = 8;
            label4.Text = "Fecha de nacimiento";
            label4.Click += label4_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(315, 257);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(96, 32);
            button2.TabIndex = 9;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormDatosPersona
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 314);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(dtpFechcaNacimiento);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(tbDNI);
            Controls.Add(tbNombre);
            Controls.Add(tbId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormDatosPersona";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormDatosPersona";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public TextBox tbId;
        public TextBox tbNombre;
        public DateTimePicker dtpFechcaNacimiento;
        public TextBox tbDNI;
        private Button button2;
    }
}