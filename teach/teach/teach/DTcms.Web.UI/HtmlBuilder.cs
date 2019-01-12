using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using DTcms.Common;

namespace DTcms.Web.UI
{
    public class HtmlBuilder
    {
        public HtmlBuilder()
        {
            //构造函数
        }
        //生成首页静态
        public static void CreateIndexHtml()
        {
            Model.siteconfig config = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
            string urlPath = string.Format("{0}{1}/{2}", config.webpath, DTKeys.DIRECTORY_REWRITE_ASPX, "index.aspx"); //文件相对路径
            string htmlPath = string.Format("{0}{1}/{2}", config.webpath, DTKeys.DIRECTORY_REWRITE_HTML, "index." + config.staticextension); //保存相对路径
            //检查文件是否存在
            if (!File.Exists(Utils.GetMapPath(urlPath)))
            {

            }
            Stopwatch watch = new Stopwatch(); //测量时间
            watch.Start();
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(urlPath, sw);
            File.WriteAllText(Utils.GetMapPath(htmlPath), sw.ToString(), Encoding.UTF8);
            watch.Stop();
            //watch.Elapsed
            sw.Close();
            sw.Dispose();
        }
    }
}
