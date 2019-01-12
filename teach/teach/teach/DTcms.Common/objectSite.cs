using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace DTcms.Common
{
    public static class objectSite
    {
        /// <summary>
        /// 下拉按钮绑定
        /// </summary>
        /// <param name="args">值集合，用回车隔开</param>
        /// <param name="obj">下拉控件</param>
        /// <param name="full">第一项</param>
        public static void DDLbind(string args,DropDownList obj,string full)
        {
            try
            {
                obj.Items.Clear();
                if (!string.IsNullOrEmpty(full))
                {
                    obj.Items.Add(new ListItem(full, ""));
                }
                args = args.Replace("'", "").Replace("\n", ",");
                foreach (string item in args.Split(','))
                {
                    if (string.IsNullOrEmpty(item) || obj.Items.FindByValue(item) != null)
                    {
                        continue;
                    }
                    obj.Items.Add(new ListItem(item, item));
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public static string GetChkListValue(CheckBoxList obj)
        {
            StringBuilder strtemp = new StringBuilder();
            strtemp.Append(",");
            foreach (ListItem item in obj.Items)
            {
                if (item.Selected) 
                {
                    strtemp.Append(item.Value+",");
                }
            }
            return strtemp.ToString();
        }

        public static void SetChkListValue(CheckBoxList obj,string strtemp)
        {
            foreach (ListItem item in obj.Items)
            {
                if (strtemp.IndexOf(item.Value)>-1) 
                {
                    item.Selected = true;
                }
            }
        }
    }
}
