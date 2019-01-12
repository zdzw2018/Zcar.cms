using System;
namespace DTcms.Model
{
    /// <summary>
    /// ͼ������ֵ:ʵ����
    /// </summary>
    [Serializable]
    public partial class photo_attribute_value
    {
        public photo_attribute_value()
        { }
        #region Model
        private int _id;
        private int _photo_id = 0;
        private int _attribute_id = 0;
        private string _title;
        private string _content;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ͼ��ID
        /// </summary>
        public int photo_id
        {
            set { _photo_id = value; }
            get { return _photo_id; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int attribute_id
        {
            set { _attribute_id = value; }
            get { return _attribute_id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        #endregion Model

    }
}