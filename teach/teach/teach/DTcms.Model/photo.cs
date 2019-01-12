using System;
using System.Collections.Generic;

namespace DTcms.Model
{
    /// <summary>
    /// 图文:实体类
    /// </summary>
    [Serializable]
    public partial class photo
    {
        public photo()
        { }
        #region Model
        private int _id;
        private int _channel_id = 0;
        private string _title;
        private int _category_id = 0;
        private string _photo_no;
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;
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
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
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
        /// 编号
        /// </summary>
        public string photo_no
        {
            set { _photo_no = value; }
            get { return _photo_no; }
        }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal market_price
        {
            set { _market_price = value; }
            get { return _market_price; }
        }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal sell_price
        {
            set { _sell_price = value; }
            get { return _sell_price; }
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
        /// 图片
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
        /// 详细介绍
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
        /// 点击率
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
        /// 是否允许评论
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
        /// 是否幻灯片
        /// </summary>
        public int is_slide
        {
            set { _is_slide = value; }
            get { return _is_slide; }
        }
        /// <summary>
        /// 是否不显示
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

        private List<photo_album> _photo_albums;
        /// <summary>
        /// 图文相册列表
        /// </summary>
        public List<photo_album> photo_albums
        {
            set { _photo_albums = value; }
            get { return _photo_albums; }
        }

        private List<photo_attribute_value> _photo_attribute_values;
        /// <summary>
        /// 图文属性列表
        /// </summary>
        public List<photo_attribute_value> photo_attribute_values
        {
            set { _photo_attribute_values = value; }
            get { return _photo_attribute_values; }
        }

        #endregion Model

    }
}