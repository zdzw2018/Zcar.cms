using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class student_teach_return
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

        private string _return_content;
        /// <summary>
        /// return_content
        /// </summary>	
        public string return_content
        {
            get { return _return_content; }
            set { _return_content = value; }
        }

        private DateTime _return_time;
        /// <summary>
        /// return_time
        /// </summary>	
        public DateTime return_time
        {
            get { return _return_time; }
            set { _return_time = value; }
        }
    }
}