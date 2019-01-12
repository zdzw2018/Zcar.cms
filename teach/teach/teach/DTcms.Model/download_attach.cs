using System;
namespace DTcms.Model
{
    /// <summary>
    /// ���ظ���:ʵ����
    /// </summary>
    [Serializable]
    public partial class download_attach
    {
        public download_attach()
        { }
        #region Model
        private int _id;
        private int _down_id;
        private string _title;
        private string _file_path;
        private string _file_ext;
        private int _file_size = 0;
        private int _down_num = 0;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��������ID
        /// </summary>
        public int down_id
        {
            set { _down_id = value; }
            get { return _down_id; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �ļ�·��
        /// </summary>
        public string file_path
        {
            set { _file_path = value; }
            get { return _file_path; }
        }
        /// <summary>
        /// �ļ���չ��
        /// </summary>
        public string file_ext
        {
            set { _file_ext = value; }
            get { return _file_ext; }
        }
        /// <summary>
        /// �ļ���С
        /// </summary>
        public int file_size
        {
            set { _file_size = value; }
            get { return _file_size; }
        }
        /// <summary>
        /// ���ش���
        /// </summary>
        public int down_num
        {
            set { _down_num = value; }
            get { return _down_num; }
        }
        #endregion Model

    }
}