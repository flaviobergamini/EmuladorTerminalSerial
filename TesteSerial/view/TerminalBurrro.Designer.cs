namespace TesteSerial
{
    partial class TerminalBurrro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            cboPortas = new ComboBox();
            btnAbrirPorta = new Button();
            label2 = new Label();
            cboBaud = new ComboBox();
            label3 = new Label();
            cboDataBits = new ComboBox();
            cboParidade = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cboStopBits = new ComboBox();
            label6 = new Label();
            cboHandshake = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtRecebe = new TextBox();
            btnEnviar = new Button();
            txtEnviar = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 52);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 0;
            label1.Text = "Porta COM:";
            // 
            // cboPortas
            // 
            cboPortas.BackColor = SystemColors.ScrollBar;
            cboPortas.FormattingEnabled = true;
            cboPortas.Location = new Point(160, 47);
            cboPortas.Margin = new Padding(4, 5, 4, 5);
            cboPortas.Name = "cboPortas";
            cboPortas.Size = new Size(171, 33);
            cboPortas.TabIndex = 1;
            // 
            // btnAbrirPorta
            // 
            btnAbrirPorta.Location = new Point(141, 419);
            btnAbrirPorta.Margin = new Padding(4, 5, 4, 5);
            btnAbrirPorta.Name = "btnAbrirPorta";
            btnAbrirPorta.Size = new Size(107, 38);
            btnAbrirPorta.TabIndex = 2;
            btnAbrirPorta.Text = "Conectar";
            btnAbrirPorta.UseVisualStyleBackColor = true;
            btnAbrirPorta.Click += btnAbrirPorta_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 108);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 3;
            label2.Text = "Baud Rate:";
            // 
            // cboBaud
            // 
            cboBaud.BackColor = SystemColors.ScrollBar;
            cboBaud.FormattingEnabled = true;
            cboBaud.Location = new Point(160, 103);
            cboBaud.Margin = new Padding(4, 5, 4, 5);
            cboBaud.Name = "cboBaud";
            cboBaud.Size = new Size(171, 33);
            cboBaud.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 168);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 5;
            label3.Text = "Data Bits:";
            // 
            // cboDataBits
            // 
            cboDataBits.BackColor = SystemColors.ScrollBar;
            cboDataBits.FormattingEnabled = true;
            cboDataBits.Location = new Point(160, 163);
            cboDataBits.Margin = new Padding(4, 5, 4, 5);
            cboDataBits.Name = "cboDataBits";
            cboDataBits.Size = new Size(171, 33);
            cboDataBits.TabIndex = 6;
            // 
            // cboParidade
            // 
            cboParidade.BackColor = SystemColors.ScrollBar;
            cboParidade.FormattingEnabled = true;
            cboParidade.Location = new Point(160, 227);
            cboParidade.Margin = new Padding(4, 5, 4, 5);
            cboParidade.Name = "cboParidade";
            cboParidade.Size = new Size(171, 33);
            cboParidade.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 232);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 8;
            label4.Text = "Paridade:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 293);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 9;
            label5.Text = "Stop Bits:";
            // 
            // cboStopBits
            // 
            cboStopBits.BackColor = SystemColors.ScrollBar;
            cboStopBits.FormattingEnabled = true;
            cboStopBits.Location = new Point(160, 288);
            cboStopBits.Margin = new Padding(4, 5, 4, 5);
            cboStopBits.Name = "cboStopBits";
            cboStopBits.Size = new Size(171, 33);
            cboStopBits.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 353);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(104, 25);
            label6.TabIndex = 11;
            label6.Text = "Handshake:";
            // 
            // cboHandshake
            // 
            cboHandshake.BackColor = SystemColors.ScrollBar;
            cboHandshake.FormattingEnabled = true;
            cboHandshake.Location = new Point(160, 348);
            cboHandshake.Margin = new Padding(4, 5, 4, 5);
            cboHandshake.Name = "cboHandshake";
            cboHandshake.Size = new Size(171, 33);
            cboHandshake.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboBaud);
            groupBox1.Controls.Add(cboHandshake);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboPortas);
            groupBox1.Controls.Add(cboStopBits);
            groupBox1.Controls.Add(btnAbrirPorta);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboParidade);
            groupBox1.Controls.Add(cboDataBits);
            groupBox1.Location = new Point(17, 20);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(410, 480);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtRecebe);
            groupBox2.Controls.Add(btnEnviar);
            groupBox2.Controls.Add(txtEnviar);
            groupBox2.Location = new Point(449, 20);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(727, 710);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Terminal";
            // 
            // txtRecebe
            // 
            txtRecebe.BackColor = SystemColors.InactiveCaptionText;
            txtRecebe.ForeColor = Color.Lime;
            txtRecebe.Location = new Point(10, 32);
            txtRecebe.Margin = new Padding(4, 5, 4, 5);
            txtRecebe.Multiline = true;
            txtRecebe.Name = "txtRecebe";
            txtRecebe.Size = new Size(707, 611);
            txtRecebe.TabIndex = 2;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(593, 660);
            btnEnviar.Margin = new Padding(4, 5, 4, 5);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(107, 38);
            btnEnviar.TabIndex = 1;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtEnviar
            // 
            txtEnviar.BackColor = SystemColors.Window;
            txtEnviar.Location = new Point(9, 662);
            txtEnviar.Margin = new Padding(4, 5, 4, 5);
            txtEnviar.Name = "txtEnviar";
            txtEnviar.Size = new Size(574, 31);
            txtEnviar.TabIndex = 0;
            // 
            // TerminalBurrro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1193, 750);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "TerminalBurrro";
            Text = "Terminal Burrro";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cboPortas;
        private Button btnAbrirPorta;
        private Label label2;
        private ComboBox cboBaud;
        private Label label3;
        private ComboBox cboDataBits;
        private ComboBox cboParidade;
        private Label label4;
        private Label label5;
        private ComboBox cboStopBits;
        private Label label6;
        private ComboBox cboHandshake;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtRecebe;
        private Button btnEnviar;
        private TextBox txtEnviar;
        private System.Windows.Forms.Timer timer1;
        //private Label label7;
    }
}