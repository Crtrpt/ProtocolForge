using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Interop;
using Newtonsoft.Json;
using ProtocolForge.Model;

namespace ProtocolForge.Repository
{
    public class ConnectRepository :IConnectRepository
    {
        public ConnectRepository()
        {
            //从磁盘读取连接配置
        }

        // public List<Connect>  ConnectList= new List<Connect>();
        public ObservableCollection<Connect> ConnectList=new ObservableCollection<Connect>();
        
        public void  Save<TC> ( TC connect,Object ctx=null) where TC:Connect
        {
            if (connect.Name.Trim().Equals(""))
            {
                MessageBox.Show("连接名称不能为空");
                return;
            }

            var res = from c in ConnectList
                where c.Name.Equals(connect.Name)
                select c;
            
            if (res.Any())
            {
                MessageBox.Show("连接名称不能重名");
                return;
            }

            ConnectList.Add(connect);
            this.Flush();
            if (ctx is Window)
            {
                ((Window)ctx).Close();
            }
        }

        public void Delete<C>(C connect) where C : Connect
        {
            ConnectList.Remove(connect);
            Flush();
        }

        public void Invoke()
        {
            try
            {
                this.ConnectList=JsonConvert.DeserializeObject<ConnectRepository>(File.ReadAllText(@"connect.json")).ConnectList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.ConnectList = new ObservableCollection<Connect>();
                this.Flush();
            }
         
        }

        public void Flush()
        {
            File.WriteAllText(@"connect.json", JsonConvert.SerializeObject(this));
        }

        public void Copy<C>(C connect) where C : Connect
        {
            Connect copyConnnet = (Connect)connect.Clone();
            copyConnnet.Name += "copy_1";
            Save(copyConnnet);
        }
    }
}