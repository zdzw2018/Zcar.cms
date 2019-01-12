using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class visit
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
        	
        private DateTime _visit_n_time;
        /// <summary>
        /// 回访日期
        /// </summary>	
        public DateTime visit_n_time
        {
            get{ return _visit_n_time; }
            set{ _visit_n_time = value; }
        }
        	
        private string _visit_name;
        /// <summary>
        /// 回访人
        /// </summary>	
        public string visit_name
        {
            get{ return _visit_name; }
            set{ _visit_name = value; }
        }
        	
        private string _visit_to_name;
        /// <summary>
        /// 被回访人
        /// </summary>	
        public string visit_to_name
        {
            get{ return _visit_to_name; }
            set{ _visit_to_name = value; }
        }
        	
        private string _visit_content;
        /// <summary>
        /// 回访内容
        /// </summary>	
        public string visit_content
        {
            get{ return _visit_content; }
            set{ _visit_content = value; }
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
            }
}