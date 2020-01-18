using Fluent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProtocolForge.Repository;

namespace ProtocolForge
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
           // this.MainWindow.WindowState = WindowState.Minimized;
           
        }

        public static  ConnectRepository ConnectRepository=new ConnectRepository();
        protected override void OnStartup(StartupEventArgs e)
        {
            ConnectRepository.Invoke();
            //ThemeManager.ChangeTheme(Application.Current, "Light,Blue");
            base.OnStartup(e);
        }
    }
}
