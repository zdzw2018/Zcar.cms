using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class student_teach
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

        private int _manager_id;
        /// <summary>
        /// manager_id
        /// </summary>	
        public int manager_id
        {
            get { return _manager_id; }
            set { _manager_id = value; }
        }

        private string _manager_name;
        /// <summary>
        /// manager_name
        /// </summary>	
        public string manager_name
        {
            get { return _manager_name; }
            set { _manager_name = value; }
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

        private string _lesson = "";
        /// <summary>
        /// lesson
        /// </summary>	
        public string lesson
        {
            get { return _lesson; }
            set { _lesson = value; }
        }

        private string _grade;
        /// <summary>
        /// grade
        /// </summary>	
        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        private int _xiaoqu;
        public int xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }
    }
}