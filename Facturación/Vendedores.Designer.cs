namespace Facturación
{
    partial class Vendedores
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
            this.lab1 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.textboxRFC = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.lab4 = new System.Windows.Forms.Label();
            this.sexo = new System.Windows.Forms.ComboBox();
            this.vendedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eFacturDataSet = new Facturación.eFacturDataSet();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sueldoBase = new System.Windows.Forms.TextBox();
            this.comision = new System.Windows.Forms.TextBox();
            this.vendedorTableAdapter = new Facturación.eFacturDataSetTableAdapters.VendedorTableAdapter();
            this.regresar = new System.Windows.Forms.Button();
            this.lab3 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.eFacturDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendedorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Cambio = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vendedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFacturDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFacturDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendedorBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(12, 66);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(27, 13);
            this.lab1.TabIndex = 0;
            this.lab1.Text = "lab1";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(12, 129);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(27, 13);
            this.lab2.TabIndex = 1;
            this.lab2.Text = "lab2";
            // 
            // textboxRFC
            // 
            this.textboxRFC.Location = new System.Drawing.Point(152, 66);
            this.textboxRFC.Name = "textboxRFC";
            this.textboxRFC.Size = new System.Drawing.Size(200, 20);
            this.textboxRFC.TabIndex = 2;
            this.textboxRFC.TextChanged += new System.EventHandler(this.textboxRFC_TextChanged);
            this.textboxRFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxRFC_KeyPress);
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(152, 126);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(200, 20);
            this.Nombre.TabIndex = 3;
            this.Nombre.TextChanged += new System.EventHandler(this.Nombre_TextChanged);
            this.Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nombre_KeyPress);
            // 
            // lab4
            // 
            this.lab4.AutoSize = true;
            this.lab4.Location = new System.Drawing.Point(12, 191);
            this.lab4.Name = "lab4";
            this.lab4.Size = new System.Drawing.Size(27, 13);
            this.lab4.TabIndex = 6;
            this.lab4.Text = "lab4";
            // 
            // sexo
            // 
            this.sexo.FormattingEnabled = true;
            this.sexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.sexo.Location = new System.Drawing.Point(152, 183);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(128, 21);
            this.sexo.TabIndex = 7;
            this.sexo.SelectedIndexChanged += new System.EventHandler(this.sexo_SelectedIndexChanged);
            this.sexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sexo_KeyPress);
            // 
            // vendedorBindingSource
            // 
            this.vendedorBindingSource.DataMember = "Vendedor";
            this.vendedorBindingSource.DataSource = this.eFacturDataSet;
            // 
            // eFacturDataSet
            // 
            this.eFacturDataSet.DataSetName = "eFacturDataSet";
            this.eFacturDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "label6";
            // 
            // sueldoBase
            // 
            this.sueldoBase.Location = new System.Drawing.Point(152, 308);
            this.sueldoBase.Name = "sueldoBase";
            this.sueldoBase.Size = new System.Drawing.Size(128, 20);
            this.sueldoBase.TabIndex = 10;
            this.sueldoBase.TextChanged += new System.EventHandler(this.sueldoBase_TextChanged);
            this.sueldoBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sueldoBase_KeyPress);
            // 
            // comision
            // 
            this.comision.Location = new System.Drawing.Point(152, 378);
            this.comision.Name = "comision";
            this.comision.Size = new System.Drawing.Size(128, 20);
            this.comision.TabIndex = 11;
            this.comision.TextChanged += new System.EventHandler(this.comision_TextChanged);
            this.comision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comision_KeyPress);
            // 
            // vendedorTableAdapter
            // 
            this.vendedorTableAdapter.ClearBeforeFill = true;
            // 
            // regresar
            // 
            this.regresar.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regresar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.regresar.Location = new System.Drawing.Point(224, 413);
            this.regresar.Name = "regresar";
            this.regresar.Size = new System.Drawing.Size(128, 42);
            this.regresar.TabIndex = 13;
            this.regresar.Text = "Regresar";
            this.regresar.UseVisualStyleBackColor = true;
            this.regresar.Click += new System.EventHandler(this.button2_Click);
            // 
            // lab3
            // 
            this.lab3.AutoSize = true;
            this.lab3.Location = new System.Drawing.Point(12, 246);
            this.lab3.Name = "lab3";
            this.lab3.Size = new System.Drawing.Size(27, 13);
            this.lab3.TabIndex = 14;
            this.lab3.Text = "lab3";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.fechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaNacimiento.Location = new System.Drawing.Point(152, 240);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaNacimiento.TabIndex = 15;
            // 
            // eFacturDataSetBindingSource
            // 
            this.eFacturDataSetBindingSource.DataSource = this.eFacturDataSet;
            this.eFacturDataSetBindingSource.Position = 0;
            // 
            // vendedorBindingSource1
            // 
            this.vendedorBindingSource1.DataMember = "Vendedor";
            this.vendedorBindingSource1.DataSource = this.eFacturDataSet;
            // 
            // Cambio
            // 
            this.Cambio.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cambio.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Cambio.Location = new System.Drawing.Point(32, 413);
            this.Cambio.Name = "Cambio";
            this.Cambio.Size = new System.Drawing.Size(128, 42);
            this.Cambio.TabIndex = 16;
            this.Cambio.UseVisualStyleBackColor = true;
            this.Cambio.Click += new System.EventHandler(this.Cambio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Vendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(368, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cambio);
            this.Controls.Add(this.fechaNacimiento);
            this.Controls.Add(this.lab3);
            this.Controls.Add(this.regresar);
            this.Controls.Add(this.comision);
            this.Controls.Add(this.sueldoBase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sexo);
            this.Controls.Add(this.lab4);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.textboxRFC);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this.lab1);
            this.Name = "Vendedores";
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.Vendedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFacturDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFacturDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendedorBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private eFacturDataSet eFacturDataSet;
        private System.Windows.Forms.BindingSource vendedorBindingSource;
        private eFacturDataSetTableAdapters.VendedorTableAdapter vendedorTableAdapter;
        private System.Windows.Forms.BindingSource eFacturDataSetBindingSource;
        private System.Windows.Forms.BindingSource vendedorBindingSource1;
        private System.Windows.Forms.Button Cambio;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.TextBox textboxRFC;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label lab4;
        private System.Windows.Forms.ComboBox sexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sueldoBase;
        private System.Windows.Forms.TextBox comision;
        private System.Windows.Forms.Button regresar;
        private System.Windows.Forms.Label lab3;
        private System.Windows.Forms.DateTimePicker fechaNacimiento;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}