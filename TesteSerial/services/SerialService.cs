using System;
using System.IO.Ports;

namespace TesteSerial.services;

public class SerialService
{
    private SerialPort _serialPort = new SerialPort();
    private int _operation = 0;
    public string txtRecebeLyout = "";

    public bool OpenSerialPort(
        string portName,
        int baudRate,
        int dataBits,
        string parity,
        string stopBits,
        string handshake
        )
    {
        Thread readThread = new Thread(Read);

        if (_serialPort.IsOpen)
        {
            try
            {
                _serialPort.Close();

                readThread.Abort();

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            try
            {
                _serialPort.PortName = portName;
                _serialPort.BaudRate = baudRate;
                _serialPort.DataBits = dataBits;


                if (parity == "None")
                    _serialPort.Parity = Parity.None;
                else if (parity == "Odd")
                    _serialPort.Parity = Parity.Odd;
                else if (parity == "Even")
                    _serialPort.Parity = Parity.Even;
                else if (parity == "Mark")
                    _serialPort.Parity = Parity.Mark;
                else if (parity == "Space")
                    _serialPort.Parity = Parity.Space;

                if (stopBits == "None")
                    _serialPort.StopBits = StopBits.None;
                else if (stopBits == "One")
                    _serialPort.StopBits = StopBits.One;
                else if (stopBits == "Two")
                    _serialPort.StopBits = StopBits.Two;
                else if (stopBits == "OnePointFive")
                    _serialPort.StopBits = StopBits.OnePointFive;

                if (handshake == "None")
                    _serialPort.Handshake = Handshake.None;
                else if (handshake == "XOnXOff")
                    _serialPort.Handshake = Handshake.XOnXOff;
                else if (handshake == "RequestToSend")
                    _serialPort.Handshake = Handshake.RequestToSend;
                else if (handshake == "RequestToSendXOnXOff")
                    _serialPort.Handshake = Handshake.RequestToSendXOnXOff;

                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;

                _serialPort.Open();
                readThread.Start();

                OperatingSystem os = Environment.OSVersion;
                Version ver = os.Version;
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

                _serialPort.WriteLine($"Porta {portName}, Baud Rate {baudRate}, {dataBits} {parity} {stopBits} {handshake}, desenvolvido em C# .NET 6.0");
                _serialPort.WriteLine($"\r");
                _serialPort.WriteLine($"Conectado ao {os.VersionString}\r");
                Menu();

                return _serialPort.IsOpen;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    private void Menu()
    {
        _serialPort.WriteLine($"\r");
        _serialPort.WriteLine($"+----------------------------------------------------------------------------+\r");
        _serialPort.WriteLine($"|                                  M E N U                                   |\r");
        _serialPort.WriteLine($"| Escolha uma opcao:                                                         |\r");
        _serialPort.WriteLine($"|                                                                            |\r");
        _serialPort.WriteLine($"|  (1) - Acessar Sistema Operacional                                         |\r");
        _serialPort.WriteLine($"|  (2) - Chat com o Administrador                                            |\r");
        _serialPort.WriteLine($"|  (3) - Consultar CEP nos Correios                                          |\r");
        _serialPort.WriteLine($"|  (4) - Bolsa de Valores                                                    |\r");
        _serialPort.WriteLine($"|  (5) - Sair                                                                |\r");
        _serialPort.WriteLine($"|                                                                            |\r");
        _serialPort.WriteLine($"+----------------------------------------------------------------------------+\r");
        _serialPort.WriteLine($"                                    Flavio Henrique Madureira Bergamini - 2023\r");
        _serialPort.WriteLine("Digite QUIT para voltar ao Menu\r");
        _serialPort.WriteLine($"\r");
        _serialPort.Write("Opcao: ");

        _operation = 6;
    }

    public void SerialReturn(string txtEnviar) => _serialPort.WriteLine($"{txtEnviar}\r\n");

    private void Read()
    {
        string receive;
        string data;
        int cont = 0;

        ProcessCmd processCmd = new ProcessCmd();
        processCmd.LoadCmd();

        while (true)
        {
            try
            {
                switch (_operation)
                {
                    case 1:
                        if (cont == 0)
                        {
                            _serialPort.Write("\r\nC > ");

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

                            if (!receive.Contains("cls") && !receive.Contains("clear") && !receive.Contains("QUIT"))
                            {
                                var output = processCmd.WhiteLine(receive);
                                output = output.Replace(output.Substring(output.LastIndexOf(":") - 1, (output.Length - output.LastIndexOf(":") + 1)), "");
                                output = output + "\n";
                                output = output.Replace(output.Substring(0, (output.IndexOf(receive))), "");
                                output = output.Replace(receive, "");

                                _serialPort.WriteLine(output);
                            }
                            else if (receive.Contains("QUIT"))
                            {
                                cont = 0;
                                Menu();
                                break;
                            }
                            else
                            {
                                for (int i = 0; i <= 1920; i++)
                                    _serialPort.Write(" ");
                            }

                            _serialPort.Write("C > ");
                        }
                        break;

                    case 2:
                        receive = _serialPort.ReadExisting();

                        if (receive != "" && receive != null)
                        {
                            _serialPort.Write($"{receive}");
                            txtRecebeLyout += $"{receive}";

                            if (receive.Contains("\r"))
                            {
                                _serialPort.WriteLine("");
                                //this.txtRecebe.Text += "\n";
                            }

                            if (receive.Contains("\b"))
                            {
                                //this.txtRecebe.Text += "\b";
                            }
                        }

                        break;

                    case 6:
                        List<int> menu = new List<int>() { 1, 2, 3, 4, 5 };

                        receive = _serialPort.ReadExisting();

                        if (receive != "" && receive != null)
                        {
                            _serialPort.WriteLine($"{receive}");
                           
                            try
                            {
                                if (menu.Contains(int.Parse(receive)))
                                {
                                    _operation = int.Parse(receive);
                                    break;
                                }
                                else
                                {
                                    _serialPort.WriteLine("Opcao invalida!\r\n");
                                    _serialPort.Write("Opcao: ");
                                    _operation = 0;
                                }
                            }
                            catch
                            {
                                _serialPort.WriteLine("Opcao invalida!\r\n");
                                _serialPort.Write("Opcao: ");
                                _operation = 0;
                            }
                            //this.txtRecebe.Text += $"{receive}";

                            if (receive.Contains("\r"))
                            {
                                _serialPort.WriteLine("");
                                //this.txtRecebe.Text += "\n";
                            }

                            if (receive.Contains("\b"))
                            {
                                //this.txtRecebe.Text += "\b";
                            }
                        }
                        break;

                        //default:
                        //  Menu();
                        //break;
                }
                //else
                //{
                /*receive = _serialPort.ReadExisting();

                if (receive != "" && receive != null)
                {
                    _serialPort.Write($"{receive}");
                    //this.txtRecebe.Text += $"{receive}";

                    if (receive.Contains("\r"))
                    {
                        _serialPort.WriteLine("");
                        //this.txtRecebe.Text += "\n";
                    }

                    if (receive.Contains("\b"))
                    {
                        //this.txtRecebe.Text += "\b";
                    }
                }   */

            }
            catch (TimeoutException)
            {
            }
        }

    }
}
