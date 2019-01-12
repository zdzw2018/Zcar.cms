using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class student_return
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

        private int _return_user_id;
        /// <summary>
        /// return_user_id
        /// </summary>	
        public int return_user_id
        {
            get { return _return_user_id; }
            set { _return_user_id = value; }
        }

        private string _return_user_name;
        /// <summary>
        /// return_user_name
        /// </summary>	
        public string return_user_name
        {
            get { return _return_user_name; }
            set { _return_user_name = value; }
        }

        private string _return_content;
        /// <summary>
        /// return_content
        /// </summary>	
        public string return_content
        {
            get { return _return_content; }
            set { _return_content = value; }
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

        private string _return_result;
        /// <summary>
        /// 满意度
        /// </summary>	
        public string return_result
        {
            get { return _return_result; }
            set { _return_result = value; }
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
    }
}