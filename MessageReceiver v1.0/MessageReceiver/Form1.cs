using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MessageReceiver
{
    public partial class Form1 : Form
    {
        public int port, messageCount = 1; //panellerin dinleceği port numarasını tutar
        public IPAddress ipAddress; //bilgisayarın ip adresini tutar
        public IPAddress hostIp; //panelin ip adresinin tutuar
        public Socket serverAutomationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public string errorPath = "Error_Log\\"; //hataların tutulacağı log'un yolu
        public string fileName = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";

        public Form1()
        {
            InitializeComponent();
            listBox1.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            buttonListen.NormalColor = System.Drawing.Color.FromArgb(180, 180, 180);
            buttonListen.NormalBorderColor = System.Drawing.Color.FromArgb(150, 150, 150);
            comboBoxIP.BackgroundColor = System.Drawing.Color.FromArgb(110, 110, 110);
            comboBoxIP.ArrowColor = System.Drawing.Color.FromArgb(180, 180, 180);
            comboBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            textBoxPort.BackColor = System.Drawing.Color.FromArgb(110, 110, 110);
            //sistemdeki ip adreslerini combobox'a ekler
            try
            {
                foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (adres.AddressFamily == AddressFamily.InterNetwork)
                        comboBoxIP.Items.Add(adres);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "IP Hatası");
                WriteToFile(errorPath + fileName, "IP Hatası:  " + "ex.message: " + ex.Message + " stackTrace: " + ex.Message + " Olay Zamanı: " + DateTime.Now);
            }
            //Log için klasör oluşturma
            try
            {
                if (!Directory.Exists(errorPath))
                    Directory.CreateDirectory(errorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.Message + " Olay Zamanı: " + DateTime.Now, "Klasör Oluşturma Hatası");
                WriteToFile(errorPath + fileName, "Klasör Oluşturma Hatası:  " + "ex.message: " + ex.Message + " stackTrace: " + ex.Message + " Olay Zamanı: " + DateTime.Now);
            }
        }
        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }
        private async void buttonListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxIP.SelectedIndex != -1 && textBoxPort.Text != null)
                {
                    buttonListen.Enabled = false;
                    port = int.Parse(textBoxPort.Text);
                    ipAddress = IPAddress.Parse(comboBoxIP.SelectedItem.ToString());
                    this.Text += " - Bağlantı Bekleniyor...";
                    await StartListening(ipAddress, port);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                WriteToFile(errorPath + fileName + ".txt", "ButtonListen hatası: " + "ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
            }
        }
        public async Task StartListening(IPAddress ipAddress, int port)
        {
            await Task.Run(() =>
            {
                try
                {
                    IPEndPoint localEndpoint = new IPEndPoint(ipAddress, port);
                    Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    listener.Bind(localEndpoint);
                    listener.Listen(1000);
                    while (true)
                    {
                        allDone.Reset();
                        listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                        allDone.WaitOne();
                    }

                }
                catch (SocketException se)
                {
                    MessageBox.Show("se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now, "StartListening Socket Hatası");
                    WriteToFile(errorPath + fileName, "StartListening Socket Hatası:  " + "se.message:" + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "StartListening Hatası");
                    WriteToFile(errorPath + fileName, "StartListening:  " + "ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
            });
        }
        public async void AcceptCallback(IAsyncResult ar)
        {
            await Task.Run(() =>
            {
                try
                {
                    allDone.Set();
                    Socket listener = (Socket)ar.AsyncState;
                    Socket handler = listener.EndAccept(ar);
                    StateObject state = new StateObject();
                    state.workSocket = handler;
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
                catch (SocketException se)
                {
                    MessageBox.Show("se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now, "AcceptCallback Socket  Hatası");
                    WriteToFile(errorPath + fileName, "AcceptCallback Socket  Hatası:  " + "se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "AcceptCallback Hatası");
                    WriteToFile(errorPath + fileName, "AcceptCallback Hatası:  " + "ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
            });
        }
        public async void ReadCallback(IAsyncResult ar)
        {
            await Task.Run(() =>
            {
                try
                {
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket handler = state.workSocket;
                    int bytesRead = handler.EndReceive(ar);
                    hostIp = IPAddress.Parse(handler.RemoteEndPoint.ToString().Substring(0, handler.RemoteEndPoint.ToString().IndexOf(":")));
                    if (bytesRead > 0)
                    {
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        listBox1.Items.Add("Gelen Veri: " + state.sb.ToString());
                        labelTotalMessageCount.Text = "Alınan Mesaj Sayısı: " + messageCount++;
                        SendACK(handler, state.sb.ToString().ToUpper());
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show("se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now, "ReadCallback Socket Hatası");
                    WriteToFile(errorPath + fileName, "ReadCallback Socket Hatası:  " + "se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "ReadCallback Hatası");
                    WriteToFile(errorPath + fileName, "ReadCallback Hatası:  " + "ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
            });
        }
        public async void SendACK(Socket handler, string data)
        {
            await Task.Run(() =>
            {
                try
                {
                    byte[] byteData = Encoding.ASCII.GetBytes(data);
                    handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(result => SendACKCallback(result, data)), handler);
                }
                catch (SocketException se)
                {
                    MessageBox.Show("se.message: " + se.Message + " stacktrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now, "SendACK Socket Hatası");
                    WriteToFile(errorPath + fileName, " SendACK Socket Hatası:  " + "se.message: " + se.Message + " stacktrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SendACK hatası");
                    WriteToFile(errorPath + fileName, "SendACK hatası: " + "ex.message:  " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
            });
        }
        public async void SendACKCallback(IAsyncResult ar, string data)
        {
            await Task.Run(() =>
            {
                try
                {
                    Socket handler = (Socket)ar.AsyncState;
                    int bytesSent = handler.EndSend(ar);
                    if (bytesSent > 0)
                        listBox1.Items.Add("Giden Veri: " + data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                catch (SocketException se)
                {
                    MessageBox.Show("se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now, "SendACKCallback Socket Hatası");
                    WriteToFile(errorPath + fileName, "SendACKCallback Socket Hatası:  " + "se.message: " + se.Message + " stackTrace: " + se.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SendACKCallback Hatası");
                    WriteToFile(errorPath + fileName, "SendACKCallback Hatası:  " + "ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                }
            });
        }
        public async void WriteToFile(string path, string data)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (path.IndexOf(".txt") != -1 && (data != null || data != ""))
                    {
                        using (FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        using (StreamWriter streamWriter = new StreamWriter((Stream)fileStream))
                        {
                            streamWriter.WriteLine(data);
                            streamWriter.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "WriteToFile Hatası");
                }
            });
        }
        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string port_text = textBoxPort.Text;
                if (textBoxPort.Text.Length <= 5)
                {
                    for (int i = 0; i < port_text.Length; i++)
                    {
                        char a = Convert.ToChar(port_text.Substring(i, 1));
                        if (!char.IsNumber(a))
                            port_text = port_text.Remove(i, 1);
                    }
                    textBoxPort.Text = port_text;
                }
                else
                    textBoxPort.Text = textBoxPort.Text.Remove(5, 1);
                textBoxPort.Select(textBoxPort.Text.Length, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "textBoxPortChanged hatası");
                WriteToFile(errorPath + fileName + ".txt", "textBoxChanged hatası: " + "ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
            }
        }
        private void textBoxPort_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPort.Text == "" || textBoxPort.Text == null)
                {
                    MessageBox.Show("Port Numarası Boş Olamaz!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stackTrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
                WriteToFile(errorPath + fileName + ".txt", "textBoxChanged hatası: " + "ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now);
            }
        }
    }
}
