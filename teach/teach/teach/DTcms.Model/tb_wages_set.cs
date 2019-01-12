using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class tb_wages_set
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
        /// grade
        /// </summary>		
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        /// <summary>
        /// keshi_qujian
        /// </summary>		
        private decimal _keshi_begin;
        public decimal keshi_begin
        {
            get { return _keshi_begin; }
            set { _keshi_begin = value; }
        }

        private decimal _keshi_end;
        public decimal keshi_end
        {
            get { return _keshi_end; }
            set { _keshi_end = value; }
        }
        /// <summary>
        /// wages
        /// </summary>		
        private decimal _wages;
        public decimal wages
        {
            get { return _wages; }
            set { _wages = value; }
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
    }
}
