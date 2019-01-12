using System;
using System.Collections.Generic;
namespace DTcms.Model
{
	/// <summary>
    /// 系统模型实体类
	/// </summary>
    [Serializable]
    public class sys_model
    {
        public sys_model()
        { }
        #region Model
        private int _id;
        private string _title;
        private int _sort_id = 99;
        private string _inherit_index = "";
        private string _inherit_list = "";
        private string _inherit_detail = "";
        private int _is_sys = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 模型名称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 排序数字
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 首页类名
        /// </summary>
        public string inherit_index
        {
            set { _inherit_index = value; }
            get { return _inherit_index; }
        }
        /// <summary>
        /// 列表页类名
        /// </summary>
        public string inherit_list
        {
            set { _inherit_list = value; }
            get { return _inherit_list; }
        }
        /// <summary>
        /// 详细页类名
        /// </summary>
        public string inherit_detail
        {
            set { _inherit_detail = value; }
            get { return _inherit_detail; }
        }
        /// <summary>
        /// 是否系统定义
        /// </summary>
        public int is_sys
        {
            set { _is_sys = value; }
            get { return _is_sys; }
        }
        #endregion Model

        private List<sys_model_nav> _sys_model_navs;
        /// <summary>
        /// 模型菜单
        /// </summary>
        public List<sys_model_nav> sys_model_navs
        {
            set { _sys_model_navs = value; }
            get { return _sys_model_navs; }
        }
    }

	/// <summary>
	/// 系统模型菜单实体类
	/// </summary>
    [Serializable]
    public class sys_model_nav
    {
        public sys_model_nav()
        { }
        #region Model
        private int _id;
        private int _model_id = 0;
        private string _title;
        private string _nav_url;
        private int _sort_id = 99;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属模型ID
        /// </summary>
        public int model_id
        {
            set { _model_id = value; }
            get { return _model_id; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 管理链接地址
        /// </summary>
        public string nav_url
        {
            set { _nav_url = value; }
            get { return _nav_url; }
        }
        /// <summary>
        /// 排序数字
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        #endregion Model
    }
}

