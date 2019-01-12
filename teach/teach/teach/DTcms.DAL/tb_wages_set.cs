using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class tb_wages_set
    {
        public tb_wages_set() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_wages_set");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

       
        public decimal GetWages(decimal total_keshi, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select wages from tb_wages_set where " + total_keshi + " between keshi_begin and keshi_end");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.tb_wages_set model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_wages_set(");
            strSql.Append("grade,keshi_begin,keshi_end,wages,add_time");
            strSql.Append(") values (");
            strSql.Append("@grade,@keshi_begin,@keshi_end,@wages,@add_time");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@keshi_begin", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@keshi_end", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@wages", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)  
              
            };

            parameters[0].Value = model.grade;
            parameters[1].Value = model.keshi_begin;
            parameters[2].Value = model.keshi_end;
            parameters[3].Value = model.wages;
            parameters[4].Value = model.add_time;

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
            strSql.Append("update tb_wages_set set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void UpdateWhere(string where, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_wages_set set " + strValue);
            strSql.Append(" where " + where);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.tb_wages_set model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_wages_set set ");
            strSql.Append(" grade = @grade , ");
            strSql.Append(" keshi_begin = @keshi_begin , ");
            strSql.Append(" keshi_end = @keshi_end , ");
            strSql.Append(" wages = @wages , ");
            strSql.Append(" add_time = @add_time  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@keshi_begin", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@keshi_end", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@wages", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)  
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.keshi_begin;
            parameters[3].Value = model.keshi_end;
            parameters[4].Value = model.wages;
            parameters[5].Value = model.add_time;
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
            strSql.Append("delete from tb_wages_set ");
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
        public Model.tb_wages_set GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, grade,keshi_begin,wages,add_time,keshi_end  ");
            strSql.Append("  from tb_wages_set ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.tb_wages_set model = new Model.tb_wages_set();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                model.grade = ds.Tables[0].Rows[0]["grade"].ToString();
                if (ds.Tables[0].Rows[0]["keshi_begin"].ToString() != "")
                {
                    model.keshi_begin = decimal.Parse(ds.Tables[0].Rows[0]["keshi_begin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["keshi_end"].ToString() != "")
                {
                    model.keshi_end = decimal.Parse(ds.Tables[0].Rows[0]["keshi_end"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wages"].ToString() != "")
                {
                    model.wages = decimal.Parse(ds.Tables[0].Rows[0]["wages"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_wages_set ");
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
                strSql.Append(" FROM tb_wages_set ");
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
            strSql.Append(" FROM tb_wages_set ");
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
                strSql.Append(" FROM tb_wages_set ");
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
            strSql.Append("select * FROM tb_wages_set ");
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
                strSql.Append("select " + strSelect + " FROM tb_wages_set ");
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
