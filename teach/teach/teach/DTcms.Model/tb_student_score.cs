using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class student_score
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

        private int _stu_id;
        /// <summary>
        /// stu_id
        /// </summary>	
        public int stu_id
        {
            get { return _stu_id; }
            set { _stu_id = value; }
        }

        private string _stu_name;
        /// <summary>
        /// stu_name
        /// </summary>	
        public string stu_name
        {
            get { return _stu_name; }
            set { _stu_name = value; }
        }

        private decimal _lesson_01;
        /// <summary>
        /// 语文
        /// </summary>	
        public decimal lesson_01
        {
            get { return _lesson_01; }
            set { _lesson_01 = value; }
        }

        private decimal _lesson_02;
        /// <summary>
        /// 数学
        /// </summary>	
        public decimal lesson_02
        {
            get { return _lesson_02; }
            set { _lesson_02 = value; }
        }

        private decimal _lesson_03;
        /// <summary>
        /// 外语
        /// </summary>	
        public decimal lesson_03
        {
            get { return _lesson_03; }
            set { _lesson_03 = value; }
        }

        private decimal _lesson_04;
        /// <summary>
        /// 文综
        /// </summary>	
        public decimal lesson_04
        {
            get { return _lesson_04; }
            set { _lesson_04 = value; }
        }

        private decimal _lesson_05;
        /// <summary>
        /// 理综
        /// </summary>	
        public decimal lesson_05
        {
            get { return _lesson_05; }
            set { _lesson_05 = value; }
        }

        private decimal _lesson_06;
        /// <summary>
        /// 生物
        /// </summary>	
        public decimal lesson_06
        {
            get { return _lesson_06; }
            set { _lesson_06 = value; }
        }

        private decimal _lesson_07;
        /// <summary>
        /// 历史
        /// </summary>	
        public decimal lesson_07
        {
            get { return _lesson_07; }
            set { _lesson_07 = value; }
        }

        private decimal _lesson_08;
        /// <summary>
        /// 地理
        /// </summary>	
        public decimal lesson_08
        {
            get { return _lesson_08; }
            set { _lesson_08 = value; }
        }

        private decimal _lesson_09;
        /// <summary>
        /// 物理
        /// </summary>	
        public decimal lesson_09
        {
            get { return _lesson_09; }
            set { _lesson_09 = value; }
        }

        private decimal _lesson_010;
        /// <summary>
        /// 化学
        /// </summary>	
        public decimal lesson_010
        {
            get { return _lesson_010; }
            set { _lesson_010 = value; }
        }

        private decimal _lesson_011;
        /// <summary>
        /// 政治
        /// </summary>	
        public decimal lesson_011
        {
            get { return _lesson_011; }
            set { _lesson_011 = value; }
        }

        private decimal _lesson_012;
        /// <summary>
        /// 体育
        /// </summary>	
        public decimal lesson_012
        {
            get { return _lesson_012; }
            set { _lesson_012 = value; }
        }

        private decimal _lesson_013;
        /// <summary>
        /// 科学
        /// </summary>	
        public decimal lesson_013
        {
            get { return _lesson_013; }
            set { _lesson_013 = value; }
        }

        private decimal _lesson_count;
        /// <summary>
        /// lesson_count
        /// </summary>	
        public decimal lesson_count
        {
            get { return _lesson_count; }
            set { _lesson_count = value; }
        }

        private string _lesson_year;
        /// <summary>
        /// 学年度
        /// </summary>	
        public string lesson_year
        {
            get { return _lesson_year; }
            set { _lesson_year = value; }
        }

        private string _lesson_semester;
        /// <summary>
        /// 学期
        /// </summary>	
        public string lesson_semester
        {
            get { return _lesson_semester; }
            set { _lesson_semester = value; }
        }

        private string _lesson_type;
        /// <summary>
        /// 成绩类别
        /// </summary>	
        public string lesson_type
        {
            get { return _lesson_type; }
            set { _lesson_type = value; }
        }

        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }

        private int _user_id;
        /// <summary>
        /// user_id
        /// </summary>	
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _user_name;
        /// <summary>
        /// user_name
        /// </summary>	
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _ramark;
        public string remark
        {
            get { return _ramark; }
            set { _ramark = value; }
        }
    }
}