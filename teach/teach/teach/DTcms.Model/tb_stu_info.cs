using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class stu_info
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
        	
        private string _stu_base_info;
        /// <summary>
        /// 学生基本信息
        /// </summary>	
        public string stu_base_info
        {
            get{ return _stu_base_info; }
            set{ _stu_base_info = value; }
        }
        	
        private string _partent_name;
        /// <summary>
        /// partent_name
        /// </summary>	
        public string partent_name
        {
            get{ return _partent_name; }
            set{ _partent_name = value; }
        }
        	
        private string _stu_name;
        /// <summary>
        /// stu_name
        /// </summary>	
        public string stu_name
        {
            get{ return _stu_name; }
            set{ _stu_name = value; }
        }
        	
        private string _school;
        /// <summary>
        /// school
        /// </summary>	
        public string school
        {
            get{ return _school; }
            set{ _school = value; }
        }
        	
        private string _tel;
        /// <summary>
        /// tel
        /// </summary>	
        public string tel
        {
            get{ return _tel; }
            set{ _tel = value; }
        }
        	
        private string _grade;
        /// <summary>
        /// grade
        /// </summary>	
        public string grade
        {
            get{ return _grade; }
            set{ _grade = value; }
        }
        	
        private string _address;
        /// <summary>
        /// address
        /// </summary>	
        public string address
        {
            get{ return _address; }
            set{ _address = value; }
        }
            }
}