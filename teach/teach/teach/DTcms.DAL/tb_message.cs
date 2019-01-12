using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_message
    public partial class message
    {
        public message() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_message");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_message(");
            strSql.Append("msg_id,remark,msg_from_user,msg_income_user,msg_content,msg_title,add_time,update_time,msg_from_del,msg_income_del");
            strSql.Append(") values (");
            strSql.Append("@msg_id,@remark,@msg_from_user,@msg_income_user,@msg_content,@msg_title,@add_time,@update_time,@msg_from_del,@msg_income_del");
            strSql.Append(") ");
            strSql.Append(";select @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
			             new SqlParameter("@msg_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.Int,4) ,            
                        new SqlParameter("@msg_from_user", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@msg_income_user", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@msg_content", SqlDbType.NText) ,            
                        new SqlParameter("@msg_title", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@update_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@msg_from_del", SqlDbType.Int,4) ,            
                        new SqlParameter("@msg_income_del", SqlDbType.Int,4),    
					    new SqlParameter("@ReturnValue",SqlDbType.Int)             
              
            };

            parameters[0].Value = model.msg_id;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.msg_from_user;
            parameters[3].Value = model.msg_income_user;
            parameters[4].Value = model.msg_content;
            parameters[5].Value = model.msg_title;
            parameters[6].Value = model.add_time;
            parameters[7].Value = model.update_time;
            parameters[8].Value = model.msg_from_del;
            parameters[9].Value = model.msg_income_del; 
            parameters[10].Direction = ParameterDirection.Output;
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
            return (int)parameters[10].Value;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField1(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_message set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.message model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update tb_message set ");

                        strSql.Append(" msg_from_user = @msg_from_user , ");
                        strSql.Append(" msg_income_user = @msg_income_user , ");
                        strSql.Append(" msg_content = @msg_content , ");
                        strSql.Append(" add_time = @add_time , ");
                        strSql.Append(" update_time = @update_time , ");
                        strSql.Append(" msg_from_del = @msg_from_del , ");
                        strSql.Append(" msg_income_del = @msg_income_del , ");
                        strSql.Append(" msg_id = @msg_id , ");
                        strSql.Append(" remark = @remark  ");
                        strSql.Append(" where id=@id ");

                        SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@msg_from_user", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@msg_income_user", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@msg_content", SqlDbType.NText) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@update_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@msg_from_del", SqlDbType.Int,4) ,            
                        new SqlParameter("@msg_income_del", SqlDbType.Int,4) ,            
                        new SqlParameter("@msg_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.Int,4)             
                        };
                        parameters[0].Value = model.id;
                        parameters[1].Value = model.msg_from_user;
                        parameters[2].Value = model.msg_income_user;
                        parameters[3].Value = model.msg_content;
                        parameters[4].Value = model.add_time;
                        parameters[5].Value = model.update_time;
                        parameters[6].Value = model.msg_from_del;
                        parameters[7].Value = model.msg_income_del;
                        parameters[8].Value = model.msg_id;
                        parameters[9].Value = model.remark;
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
                    catch (Exception ex) {
                        trans.Rollback();
                        return false;
                    }
                }
                return true;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_message ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


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
        /// 得到一个对象实体
        /// </summary>
        public Model.message GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, msg_from_user, msg_income_user, msg_content, add_time, update_time, msg_from_del, msg_income_del, msg_id, remark  ");
            strSql.Append("  from tb_message ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.message model = new Model.message();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.msg_from_user = ds.Tables[0].Rows[0]["msg_from_user"].ToString();
                model.msg_income_user = ds.Tables[0].Rows[0]["msg_income_user"].ToString();
                model.msg_content = ds.Tables[0].Rows[0]["msg_content"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(ds.Tables[0].Rows[0]["update_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["msg_from_del"].ToString() != "")
                {
                    model.msg_from_del = int.Parse(ds.Tables[0].Rows[0]["msg_from_del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["msg_income_del"].ToString() != "")
                {
                    model.msg_income_del = int.Parse(ds.Tables[0].Rows[0]["msg_income_del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["msg_id"].ToString() != "")
                {
                    model.msg_id = int.Parse(ds.Tables[0].Rows[0]["msg_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = int.Parse(ds.Tables[0].Rows[0]["remark"].ToString());
                }

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_message ");
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
            strSql.Append("select * FROM tb_message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        #endregion  Method


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
