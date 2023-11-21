using System.Diagnostics;

namespace TesteSerial.services;

public class ProcessCmd
{
    Process processCmd = new Process();

    public void LoadCmd()
    {
        // Configure as propriedades do processo
        processCmd.StartInfo.FileName = "cmd.exe"; // Executar o CMD
        processCmd.StartInfo.RedirectStandardInput = true; // Redirecionar entrada padrão
        processCmd.StartInfo.RedirectStandardOutput = true; // Redirecionar saída padrão
        processCmd.StartInfo.UseShellExecute = false; // Não use o shell para iniciar o processo
        processCmd.StartInfo.CreateNoWindow = true; // Não crie uma janela do CMD
    }

    public string WhiteLine(string receive)
    {
        processCmd.Start();
        processCmd.StandardInput.WriteLine(receive);
        processCmd.StandardInput.Flush();
        processCmd.StandardInput.Close();
        processCmd.WaitForExit();

        var output = processCmd.StandardOutput.ReadToEnd();

        processCmd.Close();

        return output;
    }
}