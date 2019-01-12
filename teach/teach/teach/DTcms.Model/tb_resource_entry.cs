using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class resource_entry
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
        	
        private DateTime _collection_time;
        /// <summary>
        /// 收集日期
        /// </summary>	
        public DateTime collection_time
        {
            get{ return _collection_time; }
            set{ _collection_time = value; }
        }
        	
        private string _parent_name;
        /// <summary>
        /// 家长姓名
        /// </summary>	
        public string parent_name
        {
            get{ return _parent_name; }
            set{ _parent_name = value; }
        }
        	
        private string _stu_name;
        /// <summary>
        /// 学生姓名
        /// </summary>	
        public string stu_name
        {
            get{ return _stu_name; }
            set{ _stu_name = value; }
        }
        	
        private string _tel;
        /// <summary>
        /// 联系电话
        /// </summary>	
        public string tel
        {
            get{ return _tel; }
            set{ _tel = value; }
        }
        	
        private string _school;
        /// <summary>
        /// 学校
        /// </summary>	
        public string school
        {
            get{ return _school; }
            set{ _school = value; }
        }
        	
        private string _grade;
        /// <summary>
        /// 年级
        /// </summary>	
        public string grade
        {
            get{ return _grade; }
            set{ _grade = value; }
        }
        	
        private string _address;
        /// <summary>
        /// 家庭住址
        /// </summary>	
        public string address
        {
            get{ return _address; }
            set{ _address = value; }
        }
        	
        private string _marketet_man;
        /// <summary>
        /// 市场人员
        /// </summary>	
        public string marketet_man
        {
            get{ return _marketet_man; }
            set{ _marketet_man = value; }
        }
        	
        private string _collection_route;
        /// <summary>
        /// 收集途径
        /// </summary>	
        public string collection_route
        {
            get{ return _collection_route; }
            set{ _collection_route = value; }
        }
        	
        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }
        	
        private int _user_id;
        /// <summary>
        /// 录入员
        /// </summary>	
        public int user_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }
        	
        private int _channel_id;
        /// <summary>
        /// channel_id
        /// </summary>	
        public int channel_id
        {
            get{ return _channel_id; }
            set{ _channel_id = value; }
        }
            }
}