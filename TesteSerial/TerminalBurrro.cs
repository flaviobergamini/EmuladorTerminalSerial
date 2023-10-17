using System.Diagnostics;
using System.IO.Ports;

namespace TesteSerial
{
    public partial class TerminalBurrro : Form
    {
        static SerialPort _serialPort = new SerialPort();
        private bool OperationSystem = false;
        Process processoCmd = new Process();

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

            // Configure as propriedades do processo
            processoCmd.StartInfo.FileName = "cmd.exe"; // Executar o CMD
            processoCmd.StartInfo.RedirectStandardInput = true; // Redirecionar entrada padrão
            processoCmd.StartInfo.RedirectStandardOutput = true; // Redirecionar saída padrão
            processoCmd.StartInfo.UseShellExecute = false; // Não use o shell para iniciar o processo
            processoCmd.StartInfo.CreateNoWindow = true; // Não crie uma janela do CMD

            // Iniciar o processo
            processoCmd.Start();

        }

        private void btnAbrirPorta_Click(object sender, EventArgs e)
        {
            Thread readThread = new Thread(Read);

            if (_serialPort.IsOpen)
            {
                try
                {
                    btnAbrirPorta.Text = "Conectar";
                    _serialPort.Close();
                    readThread.Abort();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    _serialPort.PortName = this.cboPortas.Text;
                    _serialPort.BaudRate = int.Parse(this.cboBaud.Text);
                    _serialPort.DataBits = int.Parse(this.cboDataBits.Text);

                    if (this.cboParidade.Text == "None")
                        _serialPort.Parity = Parity.None;
                    else if (this.cboParidade.Text == "Odd")
                        _serialPort.Parity = Parity.Odd;
                    else if (this.cboParidade.Text == "Even")
                        _serialPort.Parity = Parity.Even;
                    else if (this.cboParidade.Text == "Mark")
                        _serialPort.Parity = Parity.Mark;
                    else if (this.cboParidade.Text == "Space")
                        _serialPort.Parity = Parity.Space;

                    if (this.cboStopBits.Text == "None")
                        _serialPort.StopBits = StopBits.None;
                    else if (this.cboStopBits.Text == "One")
                        _serialPort.StopBits = StopBits.One;
                    else if (this.cboStopBits.Text == "Two")
                        _serialPort.StopBits = StopBits.Two;
                    else if (this.cboStopBits.Text == "OnePointFive")
                        _serialPort.StopBits = StopBits.OnePointFive;

                    if (this.cboHandshake.Text == "None")
                        _serialPort.Handshake = Handshake.None;
                    else if (this.cboHandshake.Text == "XOnXOff")
                        _serialPort.Handshake = Handshake.XOnXOff;
                    else if (this.cboHandshake.Text == "RequestToSend")
                        _serialPort.Handshake = Handshake.RequestToSend;
                    else if (this.cboHandshake.Text == "RequestToSendXOnXOff")
                        _serialPort.Handshake = Handshake.RequestToSendXOnXOff;

                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

                    _serialPort.Open();
                    readThread.Start();

                    OperatingSystem os = Environment.OSVersion;
                    Version ver = os.Version;
                    StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

                    btnAbrirPorta.Text = "Desconectar";

                    _serialPort.WriteLine($"Porta {this.cboPortas.Text}, Baud Rate {this.cboBaud.Text}, {this.cboDataBits.Text} {this.cboParidade.Text} {this.cboStopBits.Text} {this.cboHandshake.Text}, desenvolvido em C# .NET 6.0\r");
                    _serialPort.WriteLine($"Flavio Henrique Madureira Bergamini - 02/2023\r\n");
                    _serialPort.WriteLine($"Conectado ao {os.VersionString}\r");
                    _serialPort.WriteLine($"------------------------------------------------------------------------------\r");
                    _serialPort.WriteLine("Digite QUIT para sair\r\n");

                    this.btnEnviar.Enabled = this.txtEnviar.Enabled = _serialPort.IsOpen;
                }
                catch (Exception) { }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine($"{this.txtEnviar.Text}\r\n");
            this.txtRecebe.Text += $"{this.txtEnviar.Text}\r\n";
            this.txtEnviar.Clear();
        }

        public void Read()
        {
            string receive;
            string data;
            int cont = 0;

            while (true)
            {
                try
                {
                    if (OperationSystem == true)
                    {
                        processoCmd.Start();

                        if (cont == 0)
                        {
                            _serialPort.Write("C > ");
                            cont = 1;
                        }

                        receive = _serialPort.ReadExisting();

                        if (receive != "" && receive != null)
                        {
                            _serialPort.Write(receive);
                            while (!receive.Contains("\r"))
                            {
                                data = _serialPort.ReadExisting();
                                receive += data;
                                _serialPort.Write(data);
                            }
                            _serialPort.WriteLine("");
                            if (!receive.Contains("cls") && !receive.Contains("clear"))
                            {
                                processoCmd.StandardInput.WriteLine(receive);
                                processoCmd.StandardInput.Flush();
                                processoCmd.StandardInput.Close();
                                processoCmd.WaitForExit();

                                var output = processoCmd.StandardOutput.ReadToEnd();
                                output = output.Replace(output.Substring(output.LastIndexOf(":") - 1, (output.Length - output.LastIndexOf(":") + 1)), "");
                                output = output + "\n";
                                output = output.Replace(output.Substring(0, (output.IndexOf(receive))), "");
                                output = output.Replace(receive, "");

                                _serialPort.WriteLine(output);
                            }
                            else
                            {
                                for (int i = 0; i <=1920; i++)
                                {
                                    _serialPort.Write(" ");
                                }
                            }
                            processoCmd.Close();
                            _serialPort.Write("C > ");
                        }
                    }
                    else
                    {
                        receive = _serialPort.ReadExisting();
                        
                        if (receive != "" && receive != null)
                        {
                            _serialPort.Write($"{receive}");
                            this.txtRecebe.Text += $"{receive}";

                            if (receive.Contains("\r"))
                            {
                                _serialPort.WriteLine("");
                                this.txtRecebe.Text += "\n";
                            }

                            if (receive.Contains("\b"))
                            {
                                this.txtRecebe.Text += "\b";
                            }
                        }
                    }
                }
                catch (TimeoutException) 
                { 
                }
            }
        }

        private void btnSO_Click(object sender, EventArgs e)
        {
            OperationSystem = !OperationSystem;
        }
    }
}