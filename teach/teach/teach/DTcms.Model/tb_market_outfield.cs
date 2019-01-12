using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class market_outfield
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

        private DateTime _activity_time;
        /// <summary>
        /// activity_time
        /// </summary>	
        public DateTime activity_time
        {
            get { return _activity_time; }
            set { _activity_time = value; }
        }

        private string _activity_location;
        /// <summary>
        /// 活动地点
        /// </summary>	
        public string activity_location
        {
            get { return _activity_location; }
            set { _activity_location = value; }
        }

        private string _activity_content;
        /// <summary>
        /// 活动内容
        /// </summary>	
        public string activity_content
        {
            get { return _activity_content; }
            set { _activity_content = value; }
        }

        private int _watchers;
        /// <summary>
        /// 关注人数
        /// </summary>	
        public int watchers
        {
            get { return _watchers; }
            set { _watchers = value; }
        }

        private int _collect_msg;
        /// <summary>
        /// 收集有效信息数
        /// </summary>	
        public int collect_msg
        {
            get { return _collect_msg; }
            set { _collect_msg = value; }
        }

        private decimal _oprice_push;
        /// <summary>
        /// 地推费用
        /// </summary>	
        public decimal oprice_push
        {
            get { return _oprice_push; }
            set { _oprice_push = value; }
        }

        private decimal _part_time_fees;
        /// <summary>
        /// 兼职费用
        /// </summary>	
        public decimal part_time_fees
        {
            get { return _part_time_fees; }
            set { _part_time_fees = value; }
        }

        private string _ques_feed;
        /// <summary>
        /// 问题与反馈
        /// </summary>	
        public string ques_feed
        {
            get { return _ques_feed; }
            set { _ques_feed = value; }
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

        private int _user_id;
        /// <summary>
        /// 录入员
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