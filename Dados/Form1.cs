using System.Net;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

const string var99 = "aaa";
namespace Dados
{
    public partial class Form1 : Form
    {
        [DllImportAttribute("user32.dll")]public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);

        [DllImportAttribute("user32.dll")]public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void move_window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(move_window);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            GetMACAddress();


            Dominio.Text = Environment.UserDomainName;
            UserName.Text = Environment.UserName;
            HostName.Text = Environment.MachineName;

            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            String aux;
            String v1 = "10.171.";
            String v2 = "192.168.0.";
            String v3 = "192.168.2.";
            String v4 = "192.168.3.";
            String v5 = "192.168.4.";
            String v6 = "192.168.5.";
            String v7 = "192.168.10.";
            String v8 = "192.168.20.";
            String v9 = "192.168.21.";
            String v10 = "172.20.";
            String v11 = "172.26.";
            String v12 = "182.10.";
            String v13 = "182.20.";
            String v14 = "182.30.";
            String v15 = "182.40.";
            String v16 = "182.50.";


            for (int i = 0; i < addr.Length; i++)
            {
                aux = addr[i].ToString();
                if (aux.Contains(v1) || aux.Contains(v2) || aux.Contains(v3) || aux.Contains(v4) || aux.Contains(v5) || aux.Contains(v6) || aux.Contains(v7) || aux.Contains(v8) || aux.Contains(v9) || aux.Contains(v10) || aux.Contains(v11) || aux.Contains(v12) || aux.Contains(v13) || aux.Contains(v14) || aux.Contains(v15) || aux.Contains(v16))
                {
                    IP.Text = aux;
                }
            }
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            String result = string.Empty;
            String R1, R2, R3, R4, R5 = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    R1 = sMacAddress.Insert(2,":");
                    R2 = R1.Insert(5,":");
                    R3 = R2.Insert(8,":");
                    R4 = R3.Insert(11,":");
                    R5 = R4.Insert(14, ":");
                }
            }
            Mac.Text = R5;
        }

        private void HostName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("   O nome do seu computador ", HostName);
        }

        private void IP_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("   Endereço IP do seu computador ", IP);
        }

        private void UserName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("   Nome do seu usuário ", UserName);
        }

        private void Mac_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("   Endereço MAC do seu computador ", Mac);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(HostName.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(IP.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Mac.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("   Sair ", button4);
        }
    }
}