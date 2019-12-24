using System.Windows;

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
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("创建TCP服务器");
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("创建TCP客户端");
        }
    }
}
