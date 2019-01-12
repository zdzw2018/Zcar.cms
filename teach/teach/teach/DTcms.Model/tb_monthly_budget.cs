using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class monthly_budget
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
        	
        private string _propaganda;
        /// <summary>
        /// 宣传形式
        /// </summary>	
        public string propaganda
        {
            get{ return _propaganda; }
            set{ _propaganda = value; }
        }
        	
        private int _month;
        /// <summary>
        /// 月份
        /// </summary>	
        public int month
        {
            get{ return _month; }
            set{ _month = value; }
        }
        	
        private decimal _budget;
        /// <summary>
        /// 费用预算
        /// </summary>	
        public decimal budget
        {
            get{ return _budget; }
            set{ _budget = value; }
        }
        	
        private decimal _total_cost;
        /// <summary>
        /// 总费用
        /// </summary>	
        public decimal total_cost
        {
            get{ return _total_cost; }
            set{ _total_cost = value; }
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
        private string _budget_opinion;
        /// <summary>
        /// 总部意见
        /// </summary>	
        public string budget_opinion
        {
            get { return _budget_opinion; }
            set { _budget_opinion = value; }
        }
            }
}