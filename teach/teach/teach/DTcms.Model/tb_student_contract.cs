using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class student_contract
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

        private int _one_several=1;
        public int one_several
        {
            get { return _one_several; }
            set { _one_several = value; }
        }

        private decimal _keshi_multiple;
        public decimal keshi_multiple
        {
            get { return _keshi_multiple; }
            set { _keshi_multiple = value; }
        }
        private string _contract_no;
        /// <summary>
        /// 合同编号
        /// </summary>	
        public string contract_no
        {
            get { return _contract_no; }
            set { _contract_no = value; }
        }

        private decimal _contract_lesson;
        /// <summary>
        /// 购买课时
        /// </summary>	
        public decimal contract_lesson
        {
            get { return _contract_lesson; }
            set { _contract_lesson = value; }
        }

        private decimal _contract_lesson_price;
        /// <summary>
        /// 课时单价
        /// </summary>	
        public decimal contract_lesson_price
        {
            get { return _contract_lesson_price; }
            set { _contract_lesson_price = value; }
        }

        private decimal _contract_service_price;
        /// <summary>
        /// 综合服务费
        /// </summary>	
        public decimal contract_service_price
        {
            get { return _contract_service_price; }
            set { _contract_service_price = value; }
        }

        private decimal _contract_advice_price;
        /// <summary>
        /// 教育咨询费
        /// </summary>	
        public decimal contract_advice_price
        {
            get { return _contract_advice_price; }
            set { _contract_advice_price = value; }
        }

        private decimal _contract_advice_price_surplus;
        /// <summary>
        /// 未支付教育咨询费
        /// </summary>	
        public decimal contract_advice_price_surplus
        {
            get { return _contract_advice_price_surplus; }
            set { _contract_advice_price_surplus = value; }
        }

        private string _contract_remark;
        /// <summary>
        /// 合同备注
        /// </summary>	
        public string contract_remark
        {
            get { return _contract_remark; }
            set { _contract_remark = value; }
        }

        private int _stu_id;
        /// <summary>
        /// 对应学员ID
        /// </summary>	
        public int stu_id
        {
            get { return _stu_id; }
            set { _stu_id = value; }
        }

        private int _user_id;
        /// <summary>
        /// 操作人
        /// </summary>	
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
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

        private int _channel_id;
        /// <summary>
        /// channel_id
        /// </summary>	
        public int channel_id
        {
            get { return _channel_id; }
            set { _channel_id = value; }
        }

        private string _contract_status;
        /// <summary>
        /// 0 添加合同  1续费合同
        /// </summary>	
        public string contract_status
        {
            get { return _contract_status; }
            set { _contract_status = value; }
        }

        private string _status;
        /// <summary>
        /// 0 待审核 1审核通过 2审核失败
        /// </summary>	
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _audit_stutas;
        /// <summary>
        /// audit_stutas
        /// </summary>	
        public int audit_stutas
        {
            get { return _audit_stutas; }
            set { _audit_stutas = value; }
        }

        private int _audit_user_id;
        /// <summary>
        /// 审核人
        /// </summary>	
        public int audit_user_id
        {
            get { return _audit_user_id; }
            set { _audit_user_id = value; }
        }

        private DateTime _audit_date;
        /// <summary>
        /// audit_date
        /// </summary>	
        public DateTime audit_date
        {
            get { return _audit_date; }
            set { _audit_date = value; }
        }

        private string _audit_user_name;
        /// <summary>
        /// audit_user_name
        /// </summary>	
        public string audit_user_name
        {
            get { return _audit_user_name; }
            set { _audit_user_name = value; }
        }

        private string _audit_remrak;
        /// <summary>
        /// audit_remrak
        /// </summary>	
        public string audit_remrak
        {
            get { return _audit_remrak; }
            set { _audit_remrak = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }

        private decimal _give_lesson = 0;
        public decimal give_lesson
        {
            get { return _give_lesson; }
            set { _give_lesson = value; }
        }
    }
}