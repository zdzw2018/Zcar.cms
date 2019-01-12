using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class market_work_log
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

        private DateTime _work_date;
        /// <summary>
        /// 日期
        /// </summary>	
        public DateTime work_date
        {
            get { return _work_date; }
            set { _work_date = value; }
        }

        private string _work_content;
        /// <summary>
        /// 工作内容
        /// </summary>	
        public string work_content
        {
            get { return _work_content; }
            set { _work_content = value; }
        }

        private string _work_summary;
        /// <summary>
        /// 工作总结
        /// </summary>	
        public string work_summary
        {
            get { return _work_summary; }
            set { _work_summary = value; }
        }

        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
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
        private string _real_name;

        public string real_name
        {
            get { return _real_name; }
            set { _real_name = value; }
        }
        private string _work_opinion;
        /// <summary>
        /// 领导意见
        /// </summary>	
        public string work_opinion
        {
            get { return _work_opinion; }
            set { _work_opinion = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}