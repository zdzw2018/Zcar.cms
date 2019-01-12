using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class  
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
        	
        private DateTime _start_time;
        /// <summary>
        /// 上课日期
        /// </summary>	
        public DateTime start_time
        {
            get{ return _start_time; }
            set{ _start_time = value; }
        }
        	
        private int _week;
        /// <summary>
        /// 星期
        /// </summary>	
        public int week
        {
            get{ return _week; }
            set{ _week = value; }
        }
        	
        private DateTime _class_time;
        /// <summary>
        /// 上课时间
        /// </summary>	
        public DateTime class_time
        {
            get{ return _class_time; }
            set{ _class_time = value; }
        }
        	
        private int _sessions;
        /// <summary>
        /// 课时数
        /// </summary>	
        public int sessions
        {
            get{ return _sessions; }
            set{ _sessions = value; }
        }
        	
        private string _grade;
        /// <summary>
        /// grade
        /// </summary>	
        public string grade
        {
            get{ return _grade; }
            set{ _grade = value; }
        }
        	
        private string _calss_teacher;
        /// <summary>
        /// calss_teacher
        /// </summary>	
        public string calss_teacher
        {
            get{ return _calss_teacher; }
            set{ _calss_teacher = value; }
        }
            }
}