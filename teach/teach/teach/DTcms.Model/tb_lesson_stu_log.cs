using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class lesson_stu_log
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
        	
        private int _stu_id;
        /// <summary>
        /// 学生ID
        /// </summary>	
        public int stu_id
        {
            get{ return _stu_id; }
            set{ _stu_id = value; }
        }
        	
        private int _lesson_id;
        /// <summary>
        /// 课程ID
        /// </summary>	
        public int lesson_id
        {
            get{ return _lesson_id; }
            set{ _lesson_id = value; }
        }
        	
        private int _stu_lesson;
        /// <summary>
        /// 学生剩余课时
        /// </summary>	
        public int stu_lesson
        {
            get{ return _stu_lesson; }
            set{ _stu_lesson = value; }
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
        	
        private int _user_id;
        /// <summary>
        /// user_id
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