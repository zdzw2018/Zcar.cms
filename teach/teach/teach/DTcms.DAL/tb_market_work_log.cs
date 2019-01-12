using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_market_work_log
    public partial class market_work_log
    {
        public market_work_log() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_market_work_log");
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
        public int Add(Model.market_work_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_market_work_log(");
            strSql.Append("work_date,work_content,work_summary,remark,user_id,channel_id,work_opinion,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@work_date,@work_content,@work_summary,@remark,@user_id,@channel_id,@work_opinion,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@work_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@work_content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@work_summary", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@work_opinion", SqlDbType.NVarChar,500),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.work_date;
            parameters[1].Value = model.work_content;
            parameters[2].Value = model.work_summary;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.user_id;
            parameters[5].Value = model.channel_id;
            parameters[6].Value = model.work_opinion;
            parameters[7].Value = model.xiaoqu;

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
            strSql.Append("update tb_market_work_log set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.market_work_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_market_work_log set ");

            strSql.Append(" work_date = @work_date , ");
            strSql.Append(" work_content = @work_content , ");
            strSql.Append(" work_summary = @work_summary , ");
            strSql.Append(" remark = @remark , ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" work_opinion = @work_opinion , ");
            strSql.Append(" xiaoqu = @xiaoqu  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@work_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@work_content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@work_summary", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@work_opinion", SqlDbType.NVarChar,500) ,      
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)         
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.work_date;
            parameters[2].Value = model.work_content;
            parameters[3].Value = model.work_summary;
            parameters[4].Value = model.remark;
            parameters[5].Value = model.user_id;
            parameters[6].Value = model.channel_id;
            parameters[7].Value = model.work_opinion;
            parameters[8].Value = model.xiaoqu;
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_market_work_log ");
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
        public Model.market_work_log GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from view_market_work_log ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.market_work_log model = new Model.market_work_log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["work_date"].ToString() != "")
                {
                    model.work_date = DateTime.Parse(ds.Tables[0].Rows[0]["work_date"].ToString());
                } model.work_content = ds.Tables[0].Rows[0]["work_content"].ToString();
                model.work_summary = ds.Tables[0].Rows[0]["work_summary"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.real_name = ds.Tables[0].Rows[0]["real_name"].ToString();
                model.work_opinion = ds.Tables[0].Rows[0]["work_opinion"].ToString();
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_market_work_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strSelect, string strWhere)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect);
                strSql.Append(" FROM view_market_work_log ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperSQL.Query(strSql.ToString());
            }
            else
                return GetList(strWhere);
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
            strSql.Append(" FROM view_market_work_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strSelect, string strWhere, string filedOrder)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(strSelect);
                strSql.Append(" FROM view_market_work_log ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                return DbHelperSQL.Query(strSql.ToString());
            }
            else return GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM view_market_work_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect + " FROM view_market_work_log ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
                return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }

}
