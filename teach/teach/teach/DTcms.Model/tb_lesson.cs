using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class lesson
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

        private int _keshi_status;
        public int keshi_status
        {
            get { return _keshi_status; }
            set { _keshi_status = value; }
        }

        private DateTime _lesson_date;
        /// <summary>
        /// 上课日期
        /// </summary>	
        public DateTime lesson_date
        {
            get { return _lesson_date; }
            set { _lesson_date = value; }
        }

        private int _stu_id;
        /// <summary>
        /// 星期
        /// </summary>	
        public int stu_id
        {
            get { return _stu_id; }
            set { _stu_id = value; }
        }

        private string _lesson_time;
        /// <summary>
        /// 上课时间
        /// </summary>	
        public string lesson_time
        {
            get { return _lesson_time; }
            set { _lesson_time = value; }
        }

        private decimal _lesson_count;
        /// <summary>
        /// 课时数
        /// </summary>	
        public decimal lesson_count
        {
            get { return _lesson_count; }
            set { _lesson_count = value; }
        }

        private string _lesson_grade;
        /// <summary>
        /// 年级
        /// </summary>	
        public string lesson_grade
        {
            get { return _lesson_grade; }
            set { _lesson_grade = value; }
        }

        private string _lesson_name;
        /// <summary>
        /// 课程名称
        /// </summary>	
        public string lesson_name
        {
            get { return _lesson_name; }
            set { _lesson_name = value; }
        }

        private int _manager_id;
        /// <summary>
        /// 任课教师
        /// </summary>	
        public int manager_id
        {
            get { return _manager_id; }
            set { _manager_id = value; }
        }

        private string _manager_name;
        /// <summary>
        /// manager_name
        /// </summary>	
        public string manager_name
        {
            get { return _manager_name; }
            set { _manager_name = value; }
        }

        private int _user_id;
        /// <summary>
        /// 任课老师ID
        /// </summary>	
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
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