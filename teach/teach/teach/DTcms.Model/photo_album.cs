using System;
namespace DTcms.Model
{
    /// <summary>
    /// ͼ�����:ʵ����
    /// </summary>
    [Serializable]
    public partial class photo_album
    {
        public photo_album()
        { }
        #region Model
        private int _id;
        private int _photo_id = 0;
        private string _big_img;
        private string _small_img;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����ͼ��ID
        /// </summary>
        public int photo_id
        {
            set { _photo_id = value; }
            get { return _photo_id; }
        }
        /// <summary>
        /// ԭͼ��ַ
        /// </summary>
        public string big_img
        {
            set { _big_img = value; }
            get { return _big_img; }
        }
        /// <summary>
        /// ����ͼ��ַ
        /// </summary>
        public string small_img
        {
            set { _small_img = value; }
            get { return _small_img; }
        }
        #endregion Model

    }
}

