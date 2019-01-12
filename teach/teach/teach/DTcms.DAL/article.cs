using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:资讯
    /// </summary>
    public partial class article
    {
        public article()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_article");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_article(");
            strSql.Append("channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time,digg_good,digg_act)");
            strSql.Append(" values (");
            strSql.Append("@channel_id,@category_id,@title,@author,@form,@zhaiyao,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@content,@sort_id,@click,@is_msg,@is_top,@is_red,@is_hot,@is_slide,@is_lock,@add_time,@digg_good,@digg_act)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@author", SqlDbType.NVarChar,255),
					new SqlParameter("@form", SqlDbType.NVarChar,50),
					new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_top", SqlDbType.Int,4),
					new SqlParameter("@is_red", SqlDbType.Int,4),
					new SqlParameter("@is_hot", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@digg_good", SqlDbType.Int,4),
					new SqlParameter("@digg_act", SqlDbType.Int,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.category_id;
            parameters[2].Value = model.title;
            parameters[3].Value = model.author;
            parameters[4].Value = model.form;
            parameters[5].Value = model.zhaiyao;
            parameters[6].Value = model.link_url;
            parameters[7].Value = model.img_url;
            parameters[8].Value = model.seo_title;
            parameters[9].Value = model.seo_keywords;
            parameters[10].Value = model.seo_description;
            parameters[11].Value = model.content;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.click;
            parameters[14].Value = model.is_msg;
            parameters[15].Value = model.is_top;
            parameters[16].Value = model.is_red;
            parameters[17].Value = model.is_hot;
            parameters[18].Value = model.is_slide;
            parameters[19].Value = model.is_lock;
            parameters[20].Value = model.add_time;
            parameters[21].Value = model.digg_good;
            parameters[22].Value = model.digg_act;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_article set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_article set ");
            strSql.Append("channel_id=@channel_id,");
            strSql.Append("category_id=@category_id,");
            strSql.Append("title=@title,");
            strSql.Append("author=@author,");
            strSql.Append("form=@form,");
            strSql.Append("zhaiyao=@zhaiyao,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("content=@content,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("click=@click,");
            strSql.Append("is_msg=@is_msg,");
            strSql.Append("is_top=@is_top,");
            strSql.Append("is_red=@is_red,");
            strSql.Append("is_hot=@is_hot,");
            strSql.Append("is_slide=@is_slide,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("digg_good=@digg_good,");
            strSql.Append("digg_act=@digg_act");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@author", SqlDbType.NVarChar,255),
					new SqlParameter("@form", SqlDbType.NVarChar,50),
					new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_top", SqlDbType.Int,4),
					new SqlParameter("@is_red", SqlDbType.Int,4),
					new SqlParameter("@is_hot", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@digg_good", SqlDbType.Int,4),
					new SqlParameter("@digg_act", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.channel_id;
            parameters[2].Value = model.category_id;
            parameters[3].Value = model.title;
            parameters[4].Value = model.author;
            parameters[5].Value = model.form;
            parameters[6].Value = model.zhaiyao;
            parameters[7].Value = model.link_url;
            parameters[8].Value = model.img_url;
            parameters[9].Value = model.seo_title;
            parameters[10].Value = model.seo_keywords;
            parameters[11].Value = model.seo_description;
            parameters[12].Value = model.content;
            parameters[13].Value = model.sort_id;
            parameters[14].Value = model.click;
            parameters[15].Value = model.is_msg;
            parameters[16].Value = model.is_top;
            parameters[17].Value = model.is_red;
            parameters[18].Value = model.is_hot;
            parameters[19].Value = model.is_slide;
            parameters[20].Value = model.is_lock;
            parameters[21].Value = model.add_time;
            parameters[22].Value = model.digg_good;
            parameters[23].Value = model.digg_act;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int channel_id, int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from dt_comment ");
            strSql2.Append(" where channel_id=@channel_id and content_id=@content_id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
                    new SqlParameter("@content_id", SqlDbType.Int,4)};
            parameters2[0].Value = channel_id;
            parameters2[1].Value = id;

            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_article ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.article GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time from dt_article ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.article model = new Model.article();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                model.form = ds.Tables[0].Rows[0]["form"].ToString();
                model.zhaiyao = ds.Tables[0].Rows[0]["zhaiyao"].ToString();
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["click"].ToString() != "")
                {
                    model.click = int.Parse(ds.Tables[0].Rows[0]["click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["digg_good"] != null && ds.Tables[0].Rows[0]["digg_good"].ToString() != "")
                {
                    model.digg_good = int.Parse(ds.Tables[0].Rows[0]["digg_good"].ToString());
                }
                if (ds.Tables[0].Rows[0]["digg_act"] != null && ds.Tables[0].Rows[0]["digg_act"].ToString() != "")
                {
                    model.digg_act = int.Parse(ds.Tables[0].Rows[0]["digg_act"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(ds.Tables[0].Rows[0]["is_msg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_top"].ToString() != "")
                {
                    model.is_top = int.Parse(ds.Tables[0].Rows[0]["is_top"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_red"].ToString() != "")
                {
                    model.is_red = int.Parse(ds.Tables[0].Rows[0]["is_red"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = int.Parse(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_slide"].ToString() != "")
                {
                    model.is_slide = int.Parse(ds.Tables[0].Rows[0]["is_slide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time ");
            strSql.Append(" FROM dt_article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by is_top desc,sort_id asc,add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time ");
            strSql.Append(" FROM dt_article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_article");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}