using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class student_info
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

        private string _stu_parent_name;
        /// <summary>
        /// 家长姓名
        /// </summary>	
        public string stu_parent_name
        {
            get { return _stu_parent_name; }
            set { _stu_parent_name = value; }
        }

        private string _stu_name;
        /// <summary>
        /// 学生姓名
        /// </summary>	
        public string stu_name
        {
            get { return _stu_name; }
            set { _stu_name = value; }
        }

        private string _stu_tel;
        /// <summary>
        /// 联系电话
        /// </summary>	
        public string stu_tel
        {
            get { return _stu_tel; }
            set { _stu_tel = value; }
        }

        private string _stu_school;
        /// <summary>
        /// 学校
        /// </summary>	
        public string stu_school
        {
            get { return _stu_school; }
            set { _stu_school = value; }
        }

        private string _stu_grade;
        /// <summary>
        /// 年级
        /// </summary>	
        public string stu_grade
        {
            get { return _stu_grade; }
            set { _stu_grade = value; }
        }

        private string _stu_addr;
        /// <summary>
        /// 家庭住址
        /// </summary>	
        public string stu_addr
        {
            get { return _stu_addr; }
            set { _stu_addr = value; }
        }

        private decimal _stu_lesson;
        /// <summary>
        /// 剩余课时
        /// </summary>	
        public decimal stu_lesson
        {
            get { return _stu_lesson; }
            set { _stu_lesson = value; }
        }

        private string _stu_remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string stu_remark
        {
            get { return _stu_remark; }
            set { _stu_remark = value; }
        }

        private int _user_id;
        /// <summary>
        /// 添加人
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
        private string _contract;
        /// <summary>
        /// 添加合同 查看合同
        /// </summary>
        public string contract
        {
            get { return _contract; }
            set { _contract = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}