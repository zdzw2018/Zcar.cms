using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:图文
    /// </summary>
    public partial class photo
    {
        public photo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_photo");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据,及其子表数据
        /// </summary>
        public int Add(Model.photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_photo(");
            strSql.Append("channel_id,title,category_id,photo_no,market_price,sell_price,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time,digg_good,digg_act)");
			strSql.Append(" values (");
            strSql.Append("@channel_id,@title,@category_id,@photo_no,@market_price,@sell_price,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@content,@sort_id,@click,@is_msg,@is_top,@is_red,@is_hot,@is_slide,@is_lock,@add_time,@digg_good,@digg_act)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@photo_no", SqlDbType.NVarChar,100),
					new SqlParameter("@market_price", SqlDbType.Decimal,9),
					new SqlParameter("@sell_price", SqlDbType.Decimal,9),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					new SqlParameter("@is_top", SqlDbType.TinyInt,1),
					new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
					new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@digg_good", SqlDbType.Int,4),
					new SqlParameter("@digg_act", SqlDbType.Int,4),
					new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.category_id;
            parameters[3].Value = model.photo_no;
            parameters[4].Value = model.market_price;
            parameters[5].Value = model.sell_price;
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
            parameters[23].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.photo_albums != null)
            {
                StringBuilder strSql2;
                foreach (Model.photo_album models in model.photo_albums)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into dt_photo_album(");
                    strSql2.Append("photo_id,big_img,small_img)");
                    strSql2.Append(" values (");
                    strSql2.Append("@photo_id,@big_img,@small_img)");
                    SqlParameter[] parameters2 = {
						new SqlParameter("@photo_id", SqlDbType.Int,4),
						new SqlParameter("@big_img", SqlDbType.NVarChar,255),
						new SqlParameter("@small_img", SqlDbType.NVarChar,255)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.big_img;
                    parameters2[2].Value = models.small_img;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }

            if (model.photo_attribute_values != null)
            {
                StringBuilder strSql3;
                foreach (Model.photo_attribute_value models in model.photo_attribute_values)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into dt_photo_attribute_value(");
                    strSql3.Append("photo_id,attribute_id,title,content)");
                    strSql3.Append(" values (");
                    strSql3.Append("@photo_id,@attribute_id,@title,@content)");
                    SqlParameter[] parameters3 = {
					new SqlParameter("@photo_id", SqlDbType.Int,4),
					new SqlParameter("@attribute_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText)};
                    parameters3[0].Direction = ParameterDirection.InputOutput;
                    parameters3[1].Value = models.attribute_id;
                    parameters3[2].Value = models.title;
                    parameters3[3].Value = models.content;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[23].Value;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_photo set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据,及其子表数据
        /// </summary>
        public bool Update(Model.photo model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update dt_photo set ");
                        strSql.Append("channel_id=@channel_id,");
                        strSql.Append("title=@title,");
                        strSql.Append("category_id=@category_id,");
                        strSql.Append("photo_no=@photo_no,");
                        strSql.Append("market_price=@market_price,");
                        strSql.Append("sell_price=@sell_price,");
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
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@photo_no", SqlDbType.NVarChar,100),
					            new SqlParameter("@market_price", SqlDbType.Decimal,9),
					            new SqlParameter("@sell_price", SqlDbType.Decimal,9),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					            new SqlParameter("@content", SqlDbType.NText),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@click", SqlDbType.Int,4),
					            new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_top", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					            new SqlParameter("@add_time", SqlDbType.DateTime),
                                new SqlParameter("@digg_good", SqlDbType.Int,4),
					            new SqlParameter("@digg_act", SqlDbType.Int,4)};
                        parameters[0].Value = model.id;
                        parameters[1].Value = model.channel_id;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.category_id;
                        parameters[4].Value = model.photo_no;
                        parameters[5].Value = model.market_price;
                        parameters[6].Value = model.sell_price;
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
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已删除的图片
                        DeleteAlbumList(conn, trans, model.photo_albums, model.id);

                        //添加/修改相册
                        if (model.photo_albums != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.photo_album models in model.photo_albums)
                            {
                                strSql2 = new StringBuilder();
                                if (models.id > 0)
                                {
                                    strSql2.Append("update dt_photo_album set ");
                                    strSql2.Append("photo_id=@photo_id,");
                                    strSql2.Append("big_img=@big_img,");
                                    strSql2.Append("small_img=@small_img");
                                    strSql2.Append(" where id=@id");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@id", SqlDbType.Int,4),
					                        new SqlParameter("@photo_id", SqlDbType.Int,4),
					                        new SqlParameter("@big_img", SqlDbType.NVarChar,255),
					                        new SqlParameter("@small_img", SqlDbType.NVarChar,255)};
                                    parameters2[0].Value = models.id;
                                    parameters2[1].Value = models.photo_id;
                                    parameters2[2].Value = models.big_img;
                                    parameters2[3].Value = models.small_img;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                                else
                                {
                                    strSql2.Append("insert into dt_photo_album(");
                                    strSql2.Append("photo_id,big_img,small_img)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@photo_id,@big_img,@small_img)");
                                    SqlParameter[] parameters2 = {
						                    new SqlParameter("@photo_id", SqlDbType.Int,4),
						                    new SqlParameter("@big_img", SqlDbType.NVarChar,255),
						                    new SqlParameter("@small_img", SqlDbType.NVarChar,255)};
                                    parameters2[0].Value = models.photo_id;
                                    parameters2[1].Value = models.big_img;
                                    parameters2[2].Value = models.small_img;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }

                        //添加/修改属性
                        if (model.photo_attribute_values != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.photo_attribute_value models in model.photo_attribute_values)
                            {
                                strSql3 = new StringBuilder();
                                if (models.id > 0)
                                {
                                    strSql3.Append("update dt_photo_attribute_value set ");
                                    strSql3.Append("photo_id=@photo_id,");
                                    strSql3.Append("attribute_id=@attribute_id,");
                                    strSql3.Append("title=@title,");
                                    strSql3.Append("content=@content");
                                    strSql3.Append(" where id=@id");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@id", SqlDbType.Int,4),
					                        new SqlParameter("@photo_id", SqlDbType.Int,4),
					                        new SqlParameter("@attribute_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,100),
					                        new SqlParameter("@content", SqlDbType.NText)};
                                    parameters3[0].Value = models.id;
                                    parameters3[1].Value = models.photo_id;
                                    parameters3[2].Value = models.attribute_id;
                                    parameters3[3].Value = models.title;
                                    parameters3[4].Value = models.content;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                                else
                                {
                                    strSql3.Append("insert into dt_photo_attribute_value(");
                                    strSql3.Append("photo_id,attribute_id,title,content)");
                                    strSql3.Append(" values (");
                                    strSql3.Append("@photo_id,@attribute_id,@title,@content)");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@photo_id", SqlDbType.Int,4),
					                        new SqlParameter("@attribute_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,100),
					                        new SqlParameter("@content", SqlDbType.NText)};
                                    parameters3[0].Value = models.photo_id;
                                    parameters3[1].Value = models.attribute_id;
                                    parameters3[2].Value = models.title;
                                    parameters3[3].Value = models.content;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int channel_id, int id)
        {
            //取得相册MODEL
            List<Model.photo_album> ls = new List<Model.photo_album>();
            Model.photo model = GetModel(id);
            if (model != null)
            {
                ls = model.photo_albums;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_photo_album ");
            strSql.Append(" where photo_id=@photo_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@photo_id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from dt_photo_attribute_value ");
            strSql2.Append(" where photo_id=@photo_id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@photo_id", SqlDbType.Int,4)};
            parameters2[0].Value = id;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from dt_photo ");
            strSql3.Append(" where id=@id ");
            SqlParameter[] parameters3 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters3[0].Value = id;

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from dt_comment ");
            strSql4.Append(" where channel_id=@channel_id and content_id=@content_id");
            SqlParameter[] parameters4 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
                    new SqlParameter("@content_id", SqlDbType.Int,4)};
            parameters4[0].Value = channel_id;
            parameters4[1].Value = id;

            cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                DeleteAlbumFile(ls);
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
        public Model.photo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,channel_id,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,title,add_time,category_id,photo_no,market_price,sell_price,link_url,img_url,seo_title,seo_keywords from dt_photo ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.photo model = new Model.photo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
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
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.photo_no = ds.Tables[0].Rows[0]["photo_no"].ToString();
                if (ds.Tables[0].Rows[0]["market_price"].ToString() != "")
                {
                    model.market_price = decimal.Parse(ds.Tables[0].Rows[0]["market_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_price"].ToString() != "")
                {
                    model.sell_price = decimal.Parse(ds.Tables[0].Rows[0]["sell_price"].ToString());
                }
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                #endregion  父表信息end

                #region  相册信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,photo_id,big_img,small_img from dt_photo_album ");
                strSql2.Append(" where photo_id=@photo_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@photo_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.photo_album> models = new List<Model.photo_album>();
                    Model.photo_album modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.photo_album();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["photo_id"].ToString() != "")
                        {
                            modelt.photo_id = int.Parse(ds2.Tables[0].Rows[n]["photo_id"].ToString());
                        }
                        modelt.big_img = ds2.Tables[0].Rows[n]["big_img"].ToString();
                        modelt.small_img = ds2.Tables[0].Rows[n]["small_img"].ToString();
                        models.Add(modelt);
                    }
                    model.photo_albums = models;
                    #endregion  子表字段信息end
                }
                #endregion  相册信息end

                #region  属性信息
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("select id,photo_id,attribute_id,title,content from dt_photo_attribute_value ");
                strSql3.Append(" where photo_id=@photo_id ");
                SqlParameter[] parameters3 = {
					new SqlParameter("@photo_id", SqlDbType.Int,4)};
                parameters3[0].Value = id;

                DataSet ds3 = DbHelperSQL.Query(strSql3.ToString(), parameters3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds3.Tables[0].Rows.Count;
                    List<DTcms.Model.photo_attribute_value> models = new List<DTcms.Model.photo_attribute_value>();
                    DTcms.Model.photo_attribute_value modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new DTcms.Model.photo_attribute_value();
                        if (ds3.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds3.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds3.Tables[0].Rows[n]["photo_id"].ToString() != "")
                        {
                            modelt.photo_id = int.Parse(ds3.Tables[0].Rows[n]["photo_id"].ToString());
                        }
                        if (ds3.Tables[0].Rows[n]["attribute_id"].ToString() != "")
                        {
                            modelt.attribute_id = int.Parse(ds3.Tables[0].Rows[n]["attribute_id"].ToString());
                        }
                        modelt.title = ds3.Tables[0].Rows[n]["title"].ToString();
                        modelt.content = ds3.Tables[0].Rows[n]["content"].ToString();
                        models.Add(modelt);
                    }
                    model.photo_attribute_values = models;
                    #endregion  子表字段信息end
                }
                #endregion  属性信息end

                return model;
            }
            else
            {
                return null;
            }
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
            strSql.Append(" id,channel_id,title,category_id,photo_no,market_price,sell_price,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time ");
            strSql.Append(" FROM dt_photo ");
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
            strSql.Append("select * FROM dt_photo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #region 私有方法
        /// <summary>
        /// 查找不存在的图片并删除已删除的图片及数据
        /// </summary>
        private void DeleteAlbumList(SqlConnection conn, SqlTransaction trans, List<Model.photo_album> models, int photo_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.photo_album modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,big_img,small_img from dt_photo_album where photo_id=" + photo_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from dt_photo_album where id=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["big_img"].ToString()); //删除原图
                    Utils.DeleteFile(dr["small_img"].ToString()); //删除缩略图
                }
            }
        }

        /// <summary>
        /// 删除相册图片
        /// </summary>
        private void DeleteAlbumFile(List<Model.photo_album> models)
        {
            if (models != null)
            {
                foreach (Model.photo_album modelt in models)
                {
                    Utils.DeleteFile(modelt.big_img);
                    Utils.DeleteFile(modelt.small_img);
                }
            }
        }
        #endregion

        #endregion  Method
    }
}