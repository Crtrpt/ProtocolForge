using Fluent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

        protected override void OnStartup(StartupEventArgs e)
        {
            //ThemeManager.ChangeTheme(Application.Current, "Light,Blue");
            base.OnStartup(e);
        }
    }
}
