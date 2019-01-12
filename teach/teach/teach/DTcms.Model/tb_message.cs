using System;
using System.Collections.Generic; 
namespace DTcms.Model
{
    [Serializable]
    public partial class message
    {
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }
        /// <summary>
        /// 发件人
        /// </summary>		
        private string _msg_from_user;
        public string msg_from_user
        {
            get{ return _msg_from_user; }
            set{ _msg_from_user = value; }
        }
        /// <summary>
        /// 收件人
        /// </summary>		
        private string _msg_income_user;
        public string msg_income_user
        {
            get{ return _msg_income_user; }
            set{ _msg_income_user = value; }
        }
        /// <summary>
        /// 信息内容
        /// </summary>		
        private string _msg_content;
        public string msg_content
        {
            get{ return _msg_content; }
            set{ _msg_content = value; }
        }
        /// <summary>
        /// add_time
        /// </summary>		
        private DateTime _add_time;
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
        /// <summary>
        /// update_time
        /// </summary>		
        private DateTime _update_time;
        public DateTime update_time
        {
            get{ return _update_time; }
            set{ _update_time = value; }
        }
        /// <summary>
        /// msg_from_del
        /// </summary>		
        private int _msg_from_del;
        public int msg_from_del
        {
            get{ return _msg_from_del; }
            set{ _msg_from_del = value; }
        }
        /// <summary>
        /// msg_income_del
        /// </summary>		
        private int _msg_income_del;
        public int msg_income_del
        {
            get{ return _msg_income_del; }
            set{ _msg_income_del = value; }
        }
        /// <summary>
        /// msg_id
        /// </summary>		
        private int _msg_id;
        public int msg_id
        {
            get{ return _msg_id; }
            set{ _msg_id = value; }
        }
        /// <summary>
        /// remark
        /// </summary>		
        private int _remark;
        public int remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }

        private List<Model.download_attach> _download_attachs = new List<download_attach>();
        /// <summary>
        /// 附件夹
        /// </summary>
        public List<Model.download_attach> download_attachs
        {
            get { return _download_attachs; }
            set { _download_attachs = value; }
        }
        /// <summary>
        /// msg_title
        /// </summary>		
        private string _msg_title;
        public string msg_title
        {
            get { return _msg_title; }
            set { _msg_title = value; }
        }
    }
}