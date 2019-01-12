using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:下载
    /// </summary>
    public partial class download
    {
        public download()
        { }

        #region  基本的方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_download");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据,及其子表数据
        /// </summary>
        public int Add(DTcms.Model.download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_download(");
            strSql.Append("channel_id,title,category_id,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,is_msg,is_red,is_lock,add_time,digg_good,digg_act)");
            strSql.Append(" values (");
            strSql.Append("@channel_id,@title,@category_id,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@content,@sort_id,@click,@is_msg,@is_red,@is_lock,@add_time,@digg_good,@digg_act)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@digg_good", SqlDbType.Int,4),
					new SqlParameter("@digg_act", SqlDbType.Int,4),
					new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.category_id;
            parameters[3].Value = model.link_url;
            parameters[4].Value = model.img_url;
            parameters[5].Value = model.seo_title;
            parameters[6].Value = model.seo_keywords;
            parameters[7].Value = model.seo_description;
            parameters[8].Value = model.content;
            parameters[9].Value = model.sort_id;
            parameters[10].Value = model.click;
            parameters[11].Value = model.is_msg;
            parameters[12].Value = model.is_red;
            parameters[13].Value = model.is_lock;
            parameters[14].Value = model.add_time;
            parameters[15].Value = model.digg_good;
            parameters[16].Value = model.digg_act;
            parameters[17].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.download_attachs != null)
            {
                StringBuilder strSql2;
                foreach (DTcms.Model.download_attach models in model.download_attachs)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into dt_download_attach(");
                    strSql2.Append("down_id,title,file_path,file_ext,file_size,down_num)");
                    strSql2.Append(" values (");
                    strSql2.Append("@down_id,@title,@file_path,@file_ext,@file_size,@down_num)");
                    SqlParameter[] parameters2 = {
						new SqlParameter("@down_id", SqlDbType.Int,4),
						new SqlParameter("@title", SqlDbType.NVarChar,255),
						new SqlParameter("@file_path", SqlDbType.NVarChar,255),
						new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
						new SqlParameter("@file_size", SqlDbType.Int,4),
						new SqlParameter("@down_num", SqlDbType.Int,4)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.title;
                    parameters2[2].Value = models.file_path;
                    parameters2[3].Value = models.file_ext;
                    parameters2[4].Value = models.file_size;
                    parameters2[5].Value = models.down_num;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[17].Value;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.download model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update dt_download set ");
                        strSql.Append("channel_id=@channel_id,");
                        strSql.Append("title=@title,");
                        strSql.Append("category_id=@category_id,");
                        strSql.Append("link_url=@link_url,");
                        strSql.Append("img_url=@img_url,");
                        strSql.Append("seo_title=@seo_title,");
                        strSql.Append("seo_keywords=@seo_keywords,");
                        strSql.Append("seo_description=@seo_description,");
                        strSql.Append("content=@content,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("click=@click,");
                        strSql.Append("is_msg=@is_msg,");
                        strSql.Append("is_red=@is_red,");
                        strSql.Append("is_lock=@is_lock,");
                        strSql.Append("add_time=@add_time,");
                        strSql.Append("digg_good=@digg_good,");
                        strSql.Append("digg_act=@digg_act");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@channel_id", SqlDbType.Int,4),
                                new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@category_id", SqlDbType.Int,4),
                                new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                                new SqlParameter("@content", SqlDbType.NText),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@click", SqlDbType.Int,4),
					            new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					            new SqlParameter("@add_time", SqlDbType.DateTime),
                                new SqlParameter("@digg_good", SqlDbType.Int,4),
					            new SqlParameter("@digg_act", SqlDbType.Int,4),
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.channel_id;
                        parameters[1].Value = model.title;
                        parameters[2].Value = model.category_id;
                        parameters[3].Value = model.link_url;
                        parameters[4].Value = model.img_url;
                        parameters[5].Value = model.seo_title;
                        parameters[6].Value = model.seo_keywords;
                        parameters[7].Value = model.seo_description;
                        parameters[8].Value = model.content;
                        parameters[9].Value = model.sort_id;
                        parameters[10].Value = model.click;
                        parameters[11].Value = model.is_msg;
                        parameters[12].Value = model.is_red;
                        parameters[13].Value = model.is_lock;
                        parameters[14].Value = model.add_time;
                        parameters[15].Value = model.digg_good;
                        parameters[16].Value = model.digg_act;
                        parameters[17].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已删除的附件
                        DeleteAttachList(conn, trans, model.download_attachs, model.id);

                        #region 添加/修改附件
                        if (model.download_attachs != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.download_attach models in model.download_attachs)
                            {
                                strSql2 = new StringBuilder();
                                if (models.id > 0)
                                {
                                    strSql2.Append("update dt_download_attach set ");
                                    strSql2.Append("down_id=@down_id,");
                                    strSql2.Append("title=@title,");
                                    strSql2.Append("file_path=@file_path,");
                                    strSql2.Append("file_ext=@file_ext,");
                                    strSql2.Append("file_size=@file_size,");
                                    strSql2.Append("down_num=@down_num");
                                    strSql2.Append(" where id=@id");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@down_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
					                        new SqlParameter("@file_size", SqlDbType.Int,4),
					                        new SqlParameter("@down_num", SqlDbType.Int,4),
					                        new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters2[0].Value = models.down_id;
                                    parameters2[1].Value = models.title;
                                    parameters2[2].Value = models.file_path;
                                    parameters2[3].Value = models.file_ext;
                                    parameters2[4].Value = models.file_size;
                                    parameters2[5].Value = models.down_num;
                                    parameters2[6].Value = models.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                                else
                                {
                                    strSql2.Append("insert into dt_download_attach(");
                                    strSql2.Append("down_id,title,file_path,file_ext,file_size)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@down_id,@title,@file_path,@file_ext,@file_size)");
                                    SqlParameter[] parameters2 = {
						                    new SqlParameter("@down_id", SqlDbType.Int,4),
						                    new SqlParameter("@title", SqlDbType.NVarChar,255),
						                    new SqlParameter("@file_path", SqlDbType.NVarChar,255),
						                    new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
						                    new SqlParameter("@file_size", SqlDbType.Int,4)};
                                    parameters2[0].Value = models.down_id;
                                    parameters2[1].Value = models.title;
                                    parameters2[2].Value = models.file_path;
                                    parameters2[3].Value = models.file_ext;
                                    parameters2[4].Value = models.file_size;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }
                        #endregion

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
            //取得下载MODEL
            List<Model.download_attach> ls = new List<Model.download_attach>();
            Model.download model = GetModel(id);
            if (model != null)
            {
                ls = model.download_attachs;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from dt_comment ");
            strSql3.Append(" where channel_id=@channel_id and content_id=@content_id");
            SqlParameter[] parameters3 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
                    new SqlParameter("@content_id", SqlDbType.Int,4)};
            parameters3[0].Value = channel_id;
            parameters3[1].Value = id;

            CommandInfo cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from dt_download_attach ");
            strSql2.Append(" where down_id=@down_id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@down_id", SqlDbType.Int,4)};
            parameters2[0].Value = id;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_download ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                DeleteAttachFile(ls);
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
        public DTcms.Model.download GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,channel_id,title,category_id,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_red,is_lock,add_time from dt_download ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.download model = new Model.download();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["click"] != null && ds.Tables[0].Rows[0]["click"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["is_msg"] != null && ds.Tables[0].Rows[0]["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(ds.Tables[0].Rows[0]["is_msg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_red"] != null && ds.Tables[0].Rows[0]["is_red"].ToString() != "")
                {
                    model.is_red = int.Parse(ds.Tables[0].Rows[0]["is_red"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"] != null && ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["category_id"] != null && ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["link_url"] != null && ds.Tables[0].Rows[0]["link_url"].ToString() != "")
                {
                    model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img_url"] != null && ds.Tables[0].Rows[0]["img_url"].ToString() != "")
                {
                    model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_title"] != null && ds.Tables[0].Rows[0]["seo_title"].ToString() != "")
                {
                    model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_keywords"] != null && ds.Tables[0].Rows[0]["seo_keywords"].ToString() != "")
                {
                    model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_description"] != null && ds.Tables[0].Rows[0]["seo_description"].ToString() != "")
                {
                    model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,down_id,title,file_path,file_ext,file_size,down_num from dt_download_attach ");
                strSql2.Append(" where down_id=@down_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@down_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds2.Tables[0].Rows.Count;
                    List<DTcms.Model.download_attach> models = new List<DTcms.Model.download_attach>();
                    DTcms.Model.download_attach modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new DTcms.Model.download_attach();
                        if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["down_id"] != null && ds2.Tables[0].Rows[n]["down_id"].ToString() != "")
                        {
                            modelt.down_id = int.Parse(ds2.Tables[0].Rows[n]["down_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["title"] != null && ds2.Tables[0].Rows[n]["title"].ToString() != "")
                        {
                            modelt.title = ds2.Tables[0].Rows[n]["title"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["file_path"] != null && ds2.Tables[0].Rows[n]["file_path"].ToString() != "")
                        {
                            modelt.file_path = ds2.Tables[0].Rows[n]["file_path"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["file_ext"] != null && ds2.Tables[0].Rows[n]["file_ext"].ToString() != "")
                        {
                            modelt.file_ext = ds2.Tables[0].Rows[n]["file_ext"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["file_size"] != null && ds2.Tables[0].Rows[n]["file_size"].ToString() != "")
                        {
                            modelt.file_size = int.Parse(ds2.Tables[0].Rows[n]["file_size"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["down_num"] != null && ds2.Tables[0].Rows[n]["down_num"].ToString() != "")
                        {
                            modelt.down_num = int.Parse(ds2.Tables[0].Rows[n]["down_num"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.download_attachs = models;
                    #endregion  子表字段信息end
                }
                #endregion  子表信息end

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
            strSql.Append(" id,channel_id,title,category_id,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_red,is_lock,add_time ");
            strSql.Append(" FROM dt_download ");
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
            strSql.Append("select * FROM dt_download");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #region 私有方法
        /// <summary>
        /// 查找不存在的文件并删除已删除的附件及数据
        /// </summary>
        private void DeleteAttachList(SqlConnection conn, SqlTransaction trans, List<Model.download_attach> models, int down_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.download_attach modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,file_path from dt_download_attach where down_id=" + down_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from dt_download_attach where id=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["file_path"].ToString()); //删除文件
                }
            }
        }

        /// <summary>
        /// 删除附件文件
        /// </summary>
        private void DeleteAttachFile(List<Model.download_attach> models)
        {
            if (models != null)
            {
                foreach (Model.download_attach modelt in models)
                {
                    Utils.DeleteFile(modelt.file_path);
                }
            }
        }
        #endregion

        #endregion  Method

        #region 扩展方法
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_download set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool AttachExists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_download_attach");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改附件一列数据
        /// </summary>
        public void UpdateAttachField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_download_attach set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个附件对象实体
        /// </summary>
        public Model.download_attach GetAttachModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,down_id,title,file_path,file_ext,file_size,down_num from dt_download_attach ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DTcms.Model.download_attach model = new DTcms.Model.download_attach();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["down_id"].ToString() != "")
                {
                    model.down_id = int.Parse(ds.Tables[0].Rows[0]["down_id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.file_path = ds.Tables[0].Rows[0]["file_path"].ToString();
                model.file_ext = ds.Tables[0].Rows[0]["file_ext"].ToString();
                if (ds.Tables[0].Rows[0]["file_size"].ToString() != "")
                {
                    model.file_size = int.Parse(ds.Tables[0].Rows[0]["file_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["down_num"].ToString() != "")
                {
                    model.down_num = int.Parse(ds.Tables[0].Rows[0]["down_num"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}