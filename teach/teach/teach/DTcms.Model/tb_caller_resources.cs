using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class caller_resources
    {

        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        private DateTime _tel_time;
        /// <summary>
        /// 来电日期
        /// </summary>	
        public DateTime tel_time
        {
            get { return _tel_time; }
            set { _tel_time = value; }
        }

        private string _partent_name;
        /// <summary>
        /// partent_name
        /// </summary>	
        public string partent_name
        {
            get { return _partent_name; }
            set { _partent_name = value; }
        }

        private string _stu_name;
        /// <summary>
        /// stu_name
        /// </summary>	
        public string stu_name
        {
            get { return _stu_name; }
            set { _stu_name = value; }
        }

        private string _tel;
        /// <summary>
        /// tel
        /// </summary>	
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _school;
        /// <summary>
        /// school
        /// </summary>	
        public string school
        {
            get { return _school; }
            set { _school = value; }
        }

        private string _grade;
        /// <summary>
        /// grade
        /// </summary>	
        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        private string _address;
        /// <summary>
        /// address
        /// </summary>	
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _learn_ways;
        /// <summary>
        /// 了解途径
        /// </summary>	
        public string learn_ways
        {
            get { return _learn_ways; }
            set { _learn_ways = value; }
        }

        private string _remark;
        /// <summary>
        /// remark
        /// </summary>	
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _channel_id;
        /// <summary>
        /// channel_id
        /// </summary>	
        public int channel_id
        {
            get { return _channel_id; }
            set { _channel_id = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}