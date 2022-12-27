using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MikroDenetleyicilerProjeOdevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private string data;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataRecived);
        }

        private void SerialPort_DataRecived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displaydata));
        }

        private void displaydata(object sender, EventArgs e)
        {
            string[] value = data.Split('/');
            progressBar1.Value = Convert.ToInt32(value[0]);
            label2.Text = "Nem:" + value[0];
            label1.Text = "Sıcaklık:" + value[1];
            progressBar2.Value = Convert.ToInt32(value[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Enabled = false;
                button2.Enabled = true;
                label4.Text = "Bağlantı Açık";
                label4.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,("Hata:"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                button1.Enabled = true;
                button2.Enabled = false;
                label4.Text = "Bağlantı Kapalı";
                label4.ForeColor = Color.Red;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ("Hata:"));

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
    }
}
