using System.Diagnostics;
using System.IO.Ports;
using TesteSerial.services;

namespace TesteSerial
{
    public partial class TerminalBurrro : Form
    {
        SerialService serialService = new SerialService();

        public TerminalBurrro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            this.cboPortas.Sorted = true;

            foreach (string port in ports)
            {
                this.cboPortas.Items.Add(port);
            }

            if (this.cboPortas.Items.Count > 0)
            {
                this.cboPortas.SelectedIndex = 0;
            }

            this.cboBaud.Items.Add(300);
            this.cboBaud.Items.Add(1200);
            this.cboBaud.Items.Add(4800);
            this.cboBaud.Items.Add(9600);
            this.cboBaud.Items.Add(14400);
            this.cboBaud.Items.Add(19200);
            this.cboBaud.Items.Add(28800);
            this.cboBaud.Items.Add(38400);
            this.cboBaud.Items.Add(57600);
            this.cboBaud.Items.Add(115200);

            this.cboBaud.SelectedIndex = 5;


            this.cboDataBits.Items.Add(7);
            this.cboDataBits.Items.Add(8);

            this.cboDataBits.SelectedIndex = 1;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                this.cboParidade.Items.Add(s);
            }

            this.cboParidade.SelectedIndex = 0;

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                this.cboStopBits.Items.Add(s);
            }

            this.cboStopBits.SelectedIndex = 1;

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                this.cboHandshake.Items.Add(s);
            }

            this.cboHandshake.SelectedIndex = 1;
        }

        private void btnAbrirPorta_Click(object sender, EventArgs e)
        {
            string portName;
            int baudRate;
            int dataBits;
            string parity;
            string stopBits;
            string handshake;

            try
            {
                portName = cboPortas.Text;
                baudRate = int.Parse(this.cboBaud.Text);
                dataBits = int.Parse(this.cboDataBits.Text);
                parity = cboParidade.Text;
                stopBits = cboStopBits.Text;
                handshake = cboHandshake.Text;

                var verifySerialPort = serialService.OpenSerialPort(portName, baudRate, dataBits, parity, stopBits, handshake);

                btnEnviar.Enabled = verifySerialPort;

                if (verifySerialPort)
                    btnAbrirPorta.Text = "Desconectar";
                else
                    btnAbrirPorta.Text = "Conectar";
            }
            catch (Exception) { }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            serialService.SerialReturn(this.txtEnviar.Text); // Quera de linha na serial "Enter" 
            this.txtRecebe.Text += $"{this.txtEnviar.Text}\r\n";
            this.txtEnviar.Clear();
        }
    }
}