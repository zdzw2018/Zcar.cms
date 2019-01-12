using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class station_letters
    {
        	
        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }
        	
        private string _role;
        /// <summary>
        /// 角色
        /// </summary>	
        public string role
        {
            get{ return _role; }
            set{ _role = value; }
        }
        	
        private string _real_name;
        /// <summary>
        /// 真实姓名
        /// </summary>	
        public string real_name
        {
            get{ return _real_name; }
            set{ _real_name = value; }
        }
        	
        private string _content;
        /// <summary>
        /// 操作内容
        /// </summary>	
        public string content
        {
            get{ return _content; }
            set{ _content = value; }
        }
        	
        private string _remark;
        /// <summary>
        /// remark
        /// </summary>	
        public string remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }
        	
        private string _item_type;
        /// <summary>
        /// 类别
        /// </summary>	
        public string item_type
        {
            get{ return _item_type; }
            set{ _item_type = value; }
        }
        	
        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
        	
        private int _item_id;
        /// <summary>
        /// 操作项目ID
        /// </summary>	
        public int item_id
        {
            get{ return _item_id; }
            set{ _item_id = value; }
        }
        	
        private int _status;
        /// <summary>
        /// 状态
        /// </summary>	
        public int status
        {
            get{ return _status; }
            set{ _status = value; }
        }
            }
}