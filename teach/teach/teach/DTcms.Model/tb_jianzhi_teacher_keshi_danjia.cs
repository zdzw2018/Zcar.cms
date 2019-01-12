using System;

namespace DTcms.Model
{
    [Serializable]
    public partial class tb_jianzhi_teacher_keshi_danjia
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
        /// 年级
        /// </summary>
        private string _grade = string.Empty;
        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        /// <summary>
        /// 教师ID
        /// </summary>
        private int _teacher_id;
        public int teacher_id
        {
            get { return _teacher_id; }
            set { _teacher_id = value; }
        }

        /// <summary>
        /// 教师姓名
        /// </summary>
        private string _teacher_name = string.Empty;
        public string teacher_name
        {
            get { return _teacher_name; }
            set { _teacher_name = value; }
        }

        /// <summary>
        /// 课时单价xx元/小时
        /// </summary>
        private decimal _keshi_danjia = 0;
        public decimal keshi_danjia
        {
            get { return _keshi_danjia; }
            set { _keshi_danjia = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _add_time = DateTime.Now;
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }

        /// <summary>
        /// 校区
        /// </summary>
        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}
