using System;
namespace DTcms.Model
{
    [Serializable]
    
    public partial class budget
    {
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// budget_publicity
        /// </summary>		
        private string _budget_publicity;
        public string budget_publicity
        {
            get { return _budget_publicity; }
            set { _budget_publicity = value; }
        }
        /// <summary>
        /// budget_price
        /// </summary>		
        private decimal _budget_price;
        public decimal budget_price
        {
            get { return _budget_price; }
            set { _budget_price = value; }
        }
        /// <summary>
        /// budget_date
        /// </summary>		
        private DateTime _budget_date;
        public DateTime budget_date
        {
            get { return _budget_date; }
            set { _budget_date = value; }
        }
        /// <summary>
        /// add_time
        /// </summary>		
        private DateTime _add_time;
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }
        /// <summary>
        /// user_id
        /// </summary>		
        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        /// <summary>
        /// remark
        /// </summary>		
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}