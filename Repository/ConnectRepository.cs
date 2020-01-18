using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        public List<Connect>  ConnectList= new List<Connect>();
        
        public void Save(Connect connect)
        {
            ConnectList.Add(connect);
            this.Flush();
        }

        public void Delete(Connect connect)
        {
            throw new System.NotImplementedException();
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
                this.ConnectList = new List<Connect>();
                this.Flush();
            }
         
        }

        public void Flush()
        {
            MessageBox.Show("保存");
            File.WriteAllText(@"connect.json", JsonConvert.SerializeObject(this));
        }
    }
}