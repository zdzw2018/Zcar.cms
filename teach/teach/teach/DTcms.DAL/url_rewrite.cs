using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DTcms.Common;

namespace DTcms.DAL
{
    public class url_rewrite
    {
        #region 增、删、改操作=================================================
        /// <summary>
        /// 增加节点
        /// </summary>
        public bool Add(Model.url_rewrite model)
        {
            try
            {
                string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode("urls");
                XmlElement xe = doc.CreateElement("rewrite");
                xe.SetAttribute("name", model.name);
                xe.SetAttribute("path", model.path);
                xe.SetAttribute("pattern", model.pattern);
                xe.SetAttribute("page", model.page);
                xe.SetAttribute("querystring", model.querystring);
                xe.SetAttribute("templet", model.templet);
                xe.SetAttribute("channel", model.channel.ToString());
                xe.SetAttribute("type", model.type);
                xe.SetAttribute("inherit", model.inherit);
                xn.AppendChild(xe);
                doc.Save(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        public bool Edit(Model.url_rewrite model)
        {
            string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode xn = doc.SelectSingleNode("urls");
            XmlNodeList xnList = xn.ChildNodes;
            if (xnList.Count > 0)
            {
                foreach (XmlElement xe in xnList)
                {
                    if (xe.Attributes["name"].Value.ToLower() == model.name.ToLower())
                    {
                        xe.Attributes["path"].Value = model.path;
                        xe.Attributes["pattern"].Value = model.pattern;
                        xe.Attributes["page"].Value = model.page;
                        xe.Attributes["querystring"].Value = model.querystring;
                        xe.Attributes["templet"].Value = model.templet;
                        xe.Attributes["channel"].Value = model.channel.ToString();
                        xe.Attributes["type"].Value = model.type;
                        xe.Attributes["inherit"].Value = model.inherit;
                        doc.Save(filePath);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        public bool Remove(string attrName, string attrValue)
        {
            string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode xn = doc.SelectSingleNode("urls");
            XmlNodeList xnList = xn.ChildNodes;
            if (xnList.Count > 0)
            {
                for (int i = xnList.Count - 1; i >= 0; i--)
                {
                    XmlElement xe = (XmlElement)xnList.Item(i);
                    if (xe.Attributes[attrName].Value.ToLower() == attrValue.ToLower())
                    {
                        xn.RemoveChild(xe);
                    }
                }
                doc.Save(filePath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 批量删除节点
        /// </summary>
        public bool Remove(XmlNodeList xnList)
        {
            try
            {
                string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode("urls");
                foreach (XmlElement xe in xnList)
                {
                    for (int i = xn.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        XmlElement xe2 = (XmlElement)xn.ChildNodes.Item(i);
                        if (xe2.Attributes["name"].Value.ToLower() == xe.Attributes["name"].Value.ToLower())
                        {
                            xn.RemoveChild(xe2);
                        }
                    }
                }
                doc.Save(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 导入节点
        /// </summary>
        public bool Import(XmlNodeList xnList)
        {
            try
            {
                string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode("urls");
                foreach (XmlElement xe in xnList)
                {
                    if (xe.NodeType != XmlNodeType.Comment && xe.Name.ToLower() == "rewrite")
                    {
                        if (xe.Attributes["name"] != null && xe.Attributes["path"] != null && xe.Attributes["pattern"] != null &&
                            xe.Attributes["page"] != null && xe.Attributes["querystring"] != null && xe.Attributes["templet"] != null &&
                            xe.Attributes["channel"] != null && xe.Attributes["type"] != null && xe.Attributes["inherit"] != null)
                        {
                            XmlNode n = doc.ImportNode(xe, true);
                            xn.AppendChild(n);
                        }
                    }
                }
                doc.Save(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 扩展方法=====================================================
        /// <summary>
        /// 取得节点配制信息
        /// </summary>
        public Model.url_rewrite GetInfo(string attrValue)
        {
            Model.url_rewrite model = new Model.url_rewrite();
            string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode xn = doc.SelectSingleNode("urls");
            XmlNodeList xnList = xn.ChildNodes;
            if (xnList.Count > 0)
            {
                foreach (XmlElement xe in xnList)
                {
                    if (xe.Attributes["name"].Value.ToLower() == attrValue.ToLower())
                    {
                        model.name = xe.Attributes["name"].Value;
                        model.path = xe.Attributes["path"].Value;
                        model.pattern = xe.Attributes["pattern"].Value;
                        model.page = xe.Attributes["page"].Value;
                        model.querystring = xe.Attributes["querystring"].Value;
                        model.templet = xe.Attributes["templet"].Value;
                        model.channel = xe.Attributes["channel"].Value;
                        model.type = xe.Attributes["type"].Value;
                        model.inherit = xe.Attributes["inherit"].Value;
                        return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 取得URL配制列表
        /// </summary>
        public Hashtable GetList()
        {
            Hashtable ht = new Hashtable();
            List<Model.url_rewrite> ls = GetList("");
            foreach (Model.url_rewrite model in ls)
            {
                if (!ht.Contains(model.name))
                {
                    model.page = model.page.Replace("^", "&");
                    model.querystring = model.querystring.Replace("^", "&");
                    ht.Add(model.name, model);
                }
            }
            return ht;
        }

        /// <summary>
        /// 取得URL配制列表
        /// </summary>
        public List<Model.url_rewrite> GetList(string channel)
        {
            List<Model.url_rewrite> ls = new List<Model.url_rewrite>();
            string filePath = Utils.GetXmlMapPath(DTKeys.FILE_URL_XML_CONFING);
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode xn = doc.SelectSingleNode("urls");
            foreach (XmlElement xe in xn.ChildNodes)
            {
                if (xe.NodeType != XmlNodeType.Comment && xe.Name.ToLower() == "rewrite")
                {
                    if (xe.Attributes["name"] != null && xe.Attributes["path"] != null && xe.Attributes["pattern"] != null &&
                            xe.Attributes["page"] != null && xe.Attributes["querystring"] != null && xe.Attributes["templet"] != null &&
                            xe.Attributes["channel"] != null && xe.Attributes["type"] != null && xe.Attributes["inherit"] != null)
                    {
                        if (!string.IsNullOrEmpty(channel))
                        {
                            if (channel.ToLower() == xe.Attributes["channel"].Value.ToLower())
                            {
                                ls.Add(new Model.url_rewrite
                                {
                                    name = xe.Attributes["name"].Value,
                                    path = xe.Attributes["path"].Value,
                                    pattern = xe.Attributes["pattern"].Value,
                                    page = xe.Attributes["page"].Value,
                                    querystring = xe.Attributes["querystring"].Value,
                                    templet = xe.Attributes["templet"].Value,
                                    channel = xe.Attributes["channel"].Value,
                                    type = xe.Attributes["type"].Value,
                                    inherit = xe.Attributes["inherit"].Value
                                });
                            }
                        }
                        else
                        {
                            ls.Add(new Model.url_rewrite
                            {
                                name = xe.Attributes["name"].Value,
                                path = xe.Attributes["path"].Value,
                                pattern = xe.Attributes["pattern"].Value,
                                page = xe.Attributes["page"].Value,
                                querystring = xe.Attributes["querystring"].Value,
                                templet = xe.Attributes["templet"].Value,
                                channel = xe.Attributes["channel"].Value,
                                type = xe.Attributes["type"].Value,
                                inherit = xe.Attributes["inherit"].Value
                            });
                        }
                    }
                }
            }
            return ls;
        }
        #endregion

    }
}
