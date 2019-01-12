using System;
namespace DTcms.Model
{
    /// <summary>
    /// 图文相册:实体类
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
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属图文ID
        /// </summary>
        public int photo_id
        {
            set { _photo_id = value; }
            get { return _photo_id; }
        }
        /// <summary>
        /// 原图地址
        /// </summary>
        public string big_img
        {
            set { _big_img = value; }
            get { return _big_img; }
        }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string small_img
        {
            set { _small_img = value; }
            get { return _small_img; }
        }
        #endregion Model

    }
}

