using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace u8
{
   
    public partial class u8main : Form
    {
        private string xml = Application.StartupPath + @"\channel.xml";
        private string xmlNode = "games";

        private XmlDocument doc;
        private XmlNodeList nodeList;

        public u8main()
        {
            InitializeComponent();

            Console.WriteLine(xml);

            game_choose.Items.Clear();

            doc = new XmlDocument();
            //加载指定文件
            doc.Load(xml);
            //获取指定节点
            nodeList = doc.SelectSingleNode(xmlNode).ChildNodes;
            //在指定节点中查找节点
            foreach (XmlNode node in nodeList)
            {
                if (node.Name == "path")
                {
                    //获取"path"节点的值
                    path_string.Text = node.InnerText;
                }
             
                if (node.Name == "game") 
                {
                    ComboboxItem cbb = new ComboboxItem
                    {
                        Name = node.Attributes["name"].Value,
                        Id = node.Attributes["id"].Value,
                        Key = node.Attributes["key"].Value
                    };
                    game_choose.Items.Add(cbb);          
                }

            }

            game_choose.SelectedIndex = 0;

        }

        private void Path_Click(object sender, EventArgs e)
        {
            //选择文件目录
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path_string.Text = fbd.SelectedPath;
            }
        }

        
        private void Path_string_TextChanged(object sender, EventArgs e)
        {
           
            foreach (XmlNode node in nodeList)
            {
                if (node.Name == "path")
                {
                    //修改"path"节点的值
                    node.InnerText = path_string.Text;
                }

            }

            doc.Save(xml);
        }

        private void Game_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            channel_choose.Items.Clear();

            foreach (XmlNode node in nodeList)
            {
                if (node.Name == "game")
                {
                    string key = (game_choose.SelectedItem as ComboboxItem).Key.ToString();

                    if (node.Attributes["key"].Value.Equals(key))
                    {                     
                        foreach (XmlNode childNode in node)
                        {
                            ComboboxItem cbb = new ComboboxItem
                            {
                                Name = childNode.Attributes["name"].Value,
                                Id = childNode.Attributes["id"].Value
                            };
                            channel_choose.Items.Add(cbb);
                        }                       
                    }                  
                }
            }

            channel_choose.SelectedIndex = 0;
        }

        private void Run_Click(object sender, EventArgs e)
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

        private void Open_apk_Click(object sender, EventArgs e)
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
