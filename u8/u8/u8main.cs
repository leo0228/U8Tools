using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace u8
{
   
    public partial class u8main : Form
    {

        string xml = Application.StartupPath + "/channel.xml";
        string xmlNode = "/games";

        public u8main()
        {
            InitializeComponent();

            game_choose.Items.Clear();
            
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            //获取指定节点
            XmlNode rootNode = doc.SelectSingleNode(xmlNode);
            //在指定节点中查找节点
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "path")
                {
                    //获取"path"节点中"name"的值
                    string path = node.Attributes["name"].Value;
                    path_string.Text = path;
                }
             
                if (node.Name == "game") 
                {
                    ComboboxItem cbb = new ComboboxItem();
                    cbb.Name = node.Attributes["name"].Value;
                    cbb.Id = node.Attributes["id"].Value;
                    cbb.Key = node.Attributes["key"].Value;
                    game_choose.Items.Add(cbb);          
                }

            }

            game_choose.SelectedIndex = 0;
        }

        private void path_Click(object sender, EventArgs e)
        {
            //选择文件目录
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string file = fbd.SelectedPath;
                path_string.Text = file;
            }
        }

        private void path_string_TextChanged(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNode rootNode = doc.SelectSingleNode(xmlNode);

            //XmlElement game = doc.CreateElement("game");//创建
            //game.SetAttribute("name", "");
            //XmlElement channel = doc.CreateElement("channel");
            //channel.SetAttribute("name", "");
            //game.AppendChild(channel);
            //rootNode.AppendChild(game);
            //doc.Save(xml);


            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "path")
                {
                    //修改"path"节点中"name"的值
                    XmlElement element = (XmlElement)node;
                    element.SetAttribute("name", path_string.Text);                    
                }

                //if (node.Name == "game")
                //{
                //    if (node.Attributes["id"].Value.Equals("3"))
                //    {
                //        XmlElement el = (XmlElement)node;
                //        el.RemoveAll();//删除
                //    }

                //    XmlNodeList nodeList = node.ChildNodes;
                //    foreach (XmlNode childNode in nodeList)
                //    {
                //        if (childNode.Attributes["id"].Value == "anzhi")
                //        {
                //            XmlElement el = (XmlElement)node;
                //            XmlElement childEl = (XmlElement)childNode;
                //            el.RemoveChild(childEl);
                //        }
                //    }
                //}

            }
            doc.Save(xml);
        }

        private void game_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            channel_choose.Items.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            //获取指定节点
            XmlNode rootNode = doc.SelectSingleNode(xmlNode);
            //在节点中查找节点
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "game")
                {
                    string key = (game_choose.SelectedItem as ComboboxItem).Key.ToString();

                    if (node.Attributes["key"].Value.Equals(key))
                    {                     
                        foreach (XmlNode childNode in node)
                        {
                            ComboboxItem cbb = new ComboboxItem();
                            cbb.Name = childNode.Attributes["name"].Value;
                            cbb.Id = childNode.Attributes["id"].Value;
                            channel_choose.Items.Add(cbb);
                        }                       
                    }                  
                }
            }

            channel_choose.SelectedIndex = 0;
        }

        private void run_Click(object sender, EventArgs e)
        {
            string gamename = (game_choose.SelectedItem as ComboboxItem).Name.ToString();
            string channelname = (channel_choose.SelectedItem as ComboboxItem).Name.ToString();

            DialogResult dr = MessageBox.Show("已选择游戏 '" + gamename + "',渠道'" + channelname + "'",
                "u8打包确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)
            {   
                string appname = (game_choose.SelectedItem as ComboboxItem).Key.ToString();
                string channelid = (channel_choose.SelectedItem as ComboboxItem).Id.ToString();
                
                Process process = new Process();
                process.StartInfo.WorkingDirectory = path_string.Text;//执行文件所在目录
                process.StartInfo.FileName = "package.bat";//执行文件名

                string batpath = path_string.Text + @"\package.bat";
                Console.WriteLine(batpath);
                if (!File.Exists(batpath)) {
                    MessageBox.Show("脚本文件不存在，请重新选择路径！");
                    return;
                }
          
                process.StartInfo.Arguments = string.Format("-g {0} -c {1}", appname, channelid);//参数
                //process.StartInfo.CreateNoWindow = true;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                process.Start();
                //process.WaitForExit(); //运行时界面锁死,等待退出
                process.Close();
            }
            else
            {
                return;
            }
        }

        private void open_apk_Click(object sender, EventArgs e)
        {
            string gameKey = (game_choose.SelectedItem as ComboboxItem).Key.ToString();
            string channelId = (channel_choose.SelectedItem as ComboboxItem).Id.ToString();
            string path = path_string.Text + @"\output\" + gameKey + @"\" + channelId;
            Console.WriteLine(path);
            if (!Directory.Exists(path)) {
                MessageBox.Show("目录不存在，请先打包！");
                return;
            }
            System.Diagnostics.Process.Start(path);
        }
    }

    public class ComboboxItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }

        public ComboboxItem(){
        }

        //重写ComboBox的ToString方法，否则下拉框显示数据无法显示
        public override string ToString()
        {
            return Name;
        }
    }

}
