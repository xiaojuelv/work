using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace combineImg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path1 = "C:\\Users\\ding.jk\\Desktop\\微信截图_20180911104205.png";
            var path2 = "C:\\Users\\ding.jk\\Desktop\\IMG_2552.PNG";
            this.pictureBox1.Image = CombinImage(path1, path2);
        }
        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        /// </summary>
        /// <param name="sourceImg">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        public static Image CombinImage(string sourceImg, string destImg)
        {
            Image imgBack = System.Drawing.Image.FromFile(sourceImg);     //相框图片 
            Image img = System.Drawing.Image.FromFile(destImg);        //照片图片
            //从指定的System.Drawing.Image创建新的System.Drawing.Graphics       
            Graphics g = Graphics.FromImage(imgBack);
            //g.DrawImage(imgBack, 0, 0, 148, 124);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);
            g.FillRectangle(System.Drawing.Brushes.Black, 130, 130, (int)150, ((int)150));//相片四周刷一层黑色边框，这里没有，需要调尺寸
            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(img, 130, 130, 150, 150);
            GC.Collect();
            var headPath = "/UploadImage/" + DateTime.Now.ToString("yyyyMM");
            string AbsoluteFilePath = Application.StartupPath+ headPath;
            if (!Directory.Exists(AbsoluteFilePath))
            {
                Directory.CreateDirectory(AbsoluteFilePath);
            }
            string saveImagePath = AbsoluteFilePath + "/" + DateTime.Now.ToString("yyyyMMddHHmm") + Guid.NewGuid().ToString() + ".jpg";
            //save new image to file system.
            imgBack.Save(saveImagePath, ImageFormat.Png);
            return imgBack;
        }
    }
}
