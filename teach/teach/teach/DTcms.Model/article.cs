using System;
namespace DTcms.Model
{
    /// <summary>
    /// 资讯:实体类
    /// </summary>
    [Serializable]
    public partial class article
    {
        public article()
        { }
        #region Model
        private int _id;
        private int _channel_id = 0;
        private int _category_id = 0;
        private string _title;
        private string _author;
        private string _form;
        private string _zhaiyao;
        private string _link_url;
        private string _img_url;
        private string _seo_title;
        private string _seo_keywords;
        private string _seo_description;
        private string _content;
        private int _sort_id = 99;
        private int _click = 0;
        private int _digg_good = 0;
        private int _digg_act = 0;
        private int _is_msg = 0;
        private int _is_top = 0;
        private int _is_red = 0;
        private int _is_hot = 0;
        private int _is_slide = 0;
        private int _is_lock = 0;
        private DateTime _add_time = DateTime.Now;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public int channel_id
        {
            set { _channel_id = value; }
            get { return _channel_id; }
        }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string form
        {
            set { _form = value; }
            get { return _form; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string zhaiyao
        {
            set { _zhaiyao = value; }
            get { return _zhaiyao; }
        }
        /// <summary>
        /// 外部链接
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string seo_title
        {
            set { _seo_title = value; }
            get { return _seo_title; }
        }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string seo_keywords
        {
            set { _seo_keywords = value; }
            get { return _seo_keywords; }
        }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string seo_description
        {
            set { _seo_description = value; }
            get { return _seo_description; }
        }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 查看次数
        /// </summary>
        public int click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 顶一下
        /// </summary>
        public int digg_good
        {
            set { _digg_good = value; }
            get { return _digg_good; }
        }
        /// <summary>
        /// 踩一下
        /// </summary>
        public int digg_act
        {
            set { _digg_act = value; }
            get { return _digg_act; }
        }
        /// <summary>
        /// 是否评论
        /// </summary>
        public int is_msg
        {
            set { _is_msg = value; }
            get { return _is_msg; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int is_top
        {
            set { _is_top = value; }
            get { return _is_top; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int is_red
        {
            set { _is_red = value; }
            get { return _is_red; }
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public int is_hot
        {
            set { _is_hot = value; }
            get { return _is_hot; }
        }
        /// <summary>
        /// 是否灯片
        /// </summary>
        public int is_slide
        {
            set { _is_slide = value; }
            get { return _is_slide; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}