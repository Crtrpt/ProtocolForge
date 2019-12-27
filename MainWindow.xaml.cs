using System.Windows;
using ProtocolForge.windows;

namespace ProtocolForge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.WindowStartupLocation= WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_TCP_SERVER(object sender, RoutedEventArgs e)
        {
            TcpServer TcpServer = new TcpServer();
            TcpServer.ShowDialog();
        }

        private void Button_Click_TCP_CLIENT(object sender, RoutedEventArgs e)
        {
            TcpClient TcpClient = new TcpClient();
            TcpClient.ShowDialog();
        }


        private void Button_Click_UDP_SERVER(object sender, RoutedEventArgs e)
        {
            UdpServer udpServer = new UdpServer();
            udpServer.ShowDialog();
        }

        private void Button_Click_UDP_CLIENT(object sender, RoutedEventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.ShowDialog();
        }

        private void Button_Help(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("跳转TCPIP的帮助论坛");
        }

        private void Border_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }
    }
}
