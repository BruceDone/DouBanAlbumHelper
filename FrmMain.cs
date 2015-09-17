using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DouBanDownLoad
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

        }



        Task t1;
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (t1 == null || t1.Status == TaskStatus.RanToCompletion)
            {
                t1 = new Task(DoDownLoad);
            }

            if (t1.Status == TaskStatus.Created)
            {
                t1.Start();
            }
        }

        private void DoDownLoad()
        {

            btnstart.Invoke((EventHandler)delegate { btnstart.Enabled = false; });

            DownLoadHelper dhelper = new DownLoadHelper();

            if (string.IsNullOrWhiteSpace(txturl.Text))
            {
                MessageBox.Show("error,please input the url info!");
                return;
            }

            int pagecount = dhelper.GetThePageCount(txturl.Text);
            int tempstart = 0;
            this.Invoke((EventHandler)delegate
                         {
                             lvstate.Items.Insert(0, string.Format("======We Have {0} Pages to be downloaded ,enjoy~======", pagecount));
                         }
                       );

            for (int i = 0; i < pagecount; i++)
            {
                this.Invoke((EventHandler)delegate
                   {
                       lvstate.Items.Insert(0, string.Format("======We are now downloading the page: {0}======", i + 1));
                   }
                );
                //this because the doulist page list like this http://www.douban.com/photos/album/62113919/?start=18
                tempstart = i * 18;
                List<ImgInfo> list = GetList(tempstart);
                for (int j = 0; j < list.Count; j++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);
                    dhelper.DownLoadFile(list[j].Downloadurl, list[j].ImgName);
                }
            }
            this.Invoke(
                (EventHandler)delegate
                     {
                         lvstate.Items.Insert(0, string.Format("====== {0} Pages are successfully downloaded ,enjoy^_^======", pagecount));
                         btnstart.Enabled = true;
                     }
                  );
        }




        public List<ImgInfo> GetList(int pagestart)
        {
            ImgInfo img = new ImgInfo();
            img.Localpath = label1.Text;
            string url = txturl.Text;

            if (url.Contains("?"))
            {
                url = url.Split('?')[0];
            }
            url = url + "?start=" + pagestart.ToString();
            //string urlinfo = string.Format("http://www.douban.com/photos/album/62113919/?start={0}", pagestart.ToString());
            return img.GetListByXpath(url, ImgType.Medium);
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            //验证是否选择路径
            if (!label1.Text.Contains("未选择"))
            {
                btnstart.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnstart.Enabled = false;
        }

        //选中路径
        private void btnpath_Click(object sender, EventArgs e)
        {
            fbpath.ShowDialog();
            label1.Text = fbpath.SelectedPath;
        }

        private void txturl_TextChanged(object sender, EventArgs e)
        {
            //this is changed ,then valadati this url info if it is the right parten of douban ablums 
            btnstart.Enabled = ToolKit.CheckUrl(txturl.Text) ? true : false;
        }
    }
}
