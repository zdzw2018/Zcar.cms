using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class tb_keshi_jili
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
        /// keshi_qujian
        /// </summary>		
        private decimal _total_begin;
        public decimal total_begin
        {
            get { return _total_begin; }
            set { _total_begin = value; }
        }

        private decimal _total_end;
        public decimal total_end
        {
            get { return _total_end; }
            set { _total_end = value; }
        }
        /// <summary>
        /// wages
        /// </summary>		
        private decimal _add_wages;
        public decimal add_wages
        {
            get { return _add_wages; }
            set { _add_wages = value; }
        }
        private int _dangwei;
        public int dangwei
        {
            get { return _dangwei; }
            set { _dangwei = value; }
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
