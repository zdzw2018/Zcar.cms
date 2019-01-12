using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class con_info
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
        	
        private string _contract_info;
        /// <summary>
        /// 合同
        /// </summary>	
        public string contract_info
        {
            get{ return _contract_info; }
            set{ _contract_info = value; }
        }
        	
        private int _contract_id;
        /// <summary>
        /// 合同编号
        /// </summary>	
        public int contract_id
        {
            get{ return _contract_id; }
            set{ _contract_id = value; }
        }
        	
        private int _buy_lesson;
        /// <summary>
        /// 购买课时
        /// </summary>	
        public int buy_lesson
        {
            get{ return _buy_lesson; }
            set{ _buy_lesson = value; }
        }
        	
        private decimal _sessions_price;
        /// <summary>
        /// 课时单价
        /// </summary>	
        public decimal sessions_price
        {
            get{ return _sessions_price; }
            set{ _sessions_price = value; }
        }
        	
        private decimal _service_price;
        /// <summary>
        /// 综合服务费
        /// </summary>	
        public decimal service_price
        {
            get{ return _service_price; }
            set{ _service_price = value; }
        }
        	
        private decimal _education_price;
        /// <summary>
        /// 教育咨询费
        /// </summary>	
        public decimal education_price
        {
            get{ return _education_price; }
            set{ _education_price = value; }
        }
        	
        private decimal _un_edu;
        /// <summary>
        /// 未支付教育咨询费
        /// </summary>	
        public decimal un_edu
        {
            get{ return _un_edu; }
            set{ _un_edu = value; }
        }
            }
}