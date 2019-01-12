using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;

namespace DTcms.Web.tools
{
    /// <summary>
    /// 下载链接处理
    /// </summary>
    public class download : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
        public void ProcessRequest(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            //获得下载ID
            if (id < 1)
            {
                context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，参数传值不正确哦！"));
                return;
            }
            //检查下载记录是否存在
            BLL.download bll = new BLL.download();
            if (!bll.AttachExists(id))
            {
                context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，您要下载的文件不存在或已经被删除啦！"));
                return;
            }
            //下载次数+1
            bll.UpdateAttachField(id, "down_num=down_num+1");
            //取得文件绝对路径
            Model.download_attach model = bll.GetAttachModel(id);
            //检查文件本地还是远程
            if (model.file_path.ToLower().StartsWith("http://"))
            {
                context.Response.Redirect(model.file_path);
                return;
            }
            else
            {
                //取得文件物理路径
                string fullFileName = Utils.GetMapPath(model.file_path);
                if (!File.Exists(fullFileName))
                {
                    context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，您要下载的文件不存在或已经被删除啦！"));
                    return;
                }
                FileInfo file = new FileInfo(fullFileName);//路径
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(model.title)); //解决中文文件名乱码    
                context.Response.AddHeader("Content-length", file.Length.ToString());
                context.Response.ContentType = "application/pdf";
                context.Response.WriteFile(file.FullName);
                context.Response.End();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}