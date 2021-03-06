﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ProtocolForge.Model;
using ProtocolForge.Protocol.Tcp.impl;
using ProtocolForge.Protocol.Tcp.page;
using ProtocolForge.Repository;
using ProtocolForge.View.Startup;
using ProtocolForge.windows;
using Application = System.Windows.Application;
using ContextMenu = System.Windows.Controls.ContextMenu;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;
using TcpClient = ProtocolForge.windows.TcpClient;

namespace ProtocolForge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public IList<Connect> connectList;

        NotifyIcon nIcon = new NotifyIcon();

        public void exit() {
            App.Current.Shutdown();
        }
        public void icon() {
            this.nIcon.Icon = new Icon("./Resources/tray.ico");
            this.nIcon.Visible = true;
            nIcon.Click += iconClick;

            System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();

            System.Windows.Forms.MenuItem closeItem = new System.Windows.Forms.MenuItem();
            closeItem.Text = "Close";
            closeItem.Click += new EventHandler(delegate {
                exit();
            });

            System.Windows.Forms.MenuItem addItem = new System.Windows.Forms.MenuItem();
            addItem.Text = "Menu";

            menu.MenuItems.Add(addItem);
            menu.MenuItems.Add(closeItem);

            nIcon.ContextMenu = menu;
        }

        

        private void iconClick(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }



        internal void gotoPage(string v)
        {
            this.MainPage.Navigate(new Uri(v, UriKind.Relative));
        }


        public MainWindow()
        {
            this.InitializeComponent();
            this.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            this.icon();
            this.TreeView1.ItemsSource = App.ConnectRepository.ConnectList;
            
            
            this.TreeView1.MouseDoubleClick += ((s, e) =>
            {
                new Thread(c => (c as Connect).Dispatch(c)).Start(TreeView1.SelectedItem);
            });

            Startup p = new Startup();
            p.parentWindows = this;
            this.MainPage.Content = p;
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
            System.Windows.MessageBox.Show("跳转TCPIP的帮助论坛");
        }

        private void Border_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void RibbonWindow_Closed(object sender, EventArgs e)
        {
            
          
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 是否开启最小化到托盘
            // this.WindowState = WindowState.Minimized;
            // e.Cancel = true;
        }

        private void right_click(object sender, MouseButtonEventArgs e)
        {
           
           
            ContextMenu menu = new ContextMenu();
            
            MenuItem closeItem = new MenuItem();
            
            closeItem.Header = "关闭";
            closeItem.DataContext = (sender as TextBlock).DataContext;
            closeItem.Click += ((e1, s1) =>
            {
                var as1 = (MenuItem) e1;
                MessageBox.Show((as1.DataContext as Connect).ConType.ToString()+(as1.DataContext as Connect).Name.ToString());
            });
            
            MenuItem deleteItem = new MenuItem();
            
            deleteItem.Header = "删除";
            deleteItem.DataContext = (sender as TextBlock).DataContext;
            deleteItem.Click += ((e1, s1) =>
            {
                App.ConnectRepository.Delete( ((MenuItem) e1).DataContext as Connect);
            });
        
            MenuItem copyItem = new MenuItem();
            
            copyItem.Header = "复制";
            copyItem.DataContext = (sender as TextBlock).DataContext;
            copyItem.Click += ((e1, s1) =>
            {
                App.ConnectRepository.Copy( ((MenuItem) e1).DataContext as Connect);
            });
            
            menu.Items.Add(copyItem);
            menu.Items.Add(closeItem);
            menu.Items.Add(deleteItem);
            (sender as TextBlock).ContextMenu = menu;

        }
    }
}
