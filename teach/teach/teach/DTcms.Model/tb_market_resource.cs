using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class market_resource
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

        private DateTime _rcollect_date;
        /// <summary>
        /// 收集日期
        /// </summary>	
        public DateTime rcollect_date
        {
            get { return _rcollect_date; }
            set { _rcollect_date = value; }
        }

        private DateTime _add_time;
        /// <summary>
        /// 添加时间 
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }

        private string _rparent_name;
        /// <summary>
        /// 家长姓名
        /// </summary>	
        public string rparent_name
        {
            get { return _rparent_name; }
            set { _rparent_name = value; }
        }

        private string _rstudent_name;
        /// <summary>
        /// 学生姓名
        /// </summary>	
        public string rstudent_name
        {
            get { return _rstudent_name; }
            set { _rstudent_name = value; }
        }

        private string _rschool;
        /// <summary>
        /// 学校 
        /// </summary>	
        public string rschool
        {
            get { return _rschool; }
            set { _rschool = value; }
        }

        private string _rgrade;
        /// <summary>
        /// 年级
        /// </summary>	
        public string rgrade
        {
            get { return _rgrade; }
            set { _rgrade = value; }
        }

        private string _raddr;
        /// <summary>
        /// 家庭住址
        /// </summary>	
        public string raddr
        {
            get { return _raddr; }
            set { _raddr = value; }
        }

        private string _rmarket_man;
        /// <summary>
        /// 市场人员
        /// </summary>	
        public string rmarket_man
        {
            get { return _rmarket_man; }
            set { _rmarket_man = value; }
        }

        private string _rcollect_choose;
        /// <summary>
        /// 收集途径
        /// </summary>	
        public string rcollect_choose
        {
            get { return _rcollect_choose; }
            set { _rcollect_choose = value; }
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

        private int _user_id;
        /// <summary>
        /// user_id
        /// </summary>	
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _other;
        /// <summary>
        /// 其他
        /// </summary>	
        public string other
        {
            get { return _other; }
            set { _other = value; }
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

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}