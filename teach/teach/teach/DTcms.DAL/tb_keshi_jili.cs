using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class tb_keshi_jili
    {
        public tb_keshi_jili() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_keshi_jili");
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
        public int Add(Model.tb_keshi_jili model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_keshi_jili(");
            strSql.Append("total_begin,total_end,add_wages,add_time,dangwei");
            strSql.Append(") values (");
            strSql.Append("@total_begin,@total_end,@add_wages,@add_time,@dangwei");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@total_begin", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@total_end", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_wages", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime),
                        new SqlParameter("@dangwei", SqlDbType.Int,4)  
              
            };

            parameters[0].Value = model.total_begin;
            parameters[1].Value = model.total_end;
            parameters[2].Value = model.add_wages;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.dangwei;

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
            strSql.Append("update tb_keshi_jili set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void UpdateWhere(string where, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_keshi_jili set " + strValue);
            strSql.Append(" where " + where);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.tb_keshi_jili model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_keshi_jili set ");
            strSql.Append(" total_begin = @total_begin , ");
            strSql.Append(" total_end = @total_end , ");
            strSql.Append(" add_wages = @add_wages , ");
            strSql.Append(" add_time = @add_time,  ");
            strSql.Append(" dangwei = @dangwei  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@total_begin", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@total_end", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_wages", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime),
                        new SqlParameter("@dangwei", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.total_begin;
            parameters[2].Value = model.total_end;
            parameters[3].Value = model.add_wages;
            parameters[4].Value = model.add_time;
            parameters[5].Value = model.dangwei;
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
            strSql.Append("delete from tb_keshi_jili ");
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

        public decimal GetJiLi(decimal total_keshi)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select add_wages from tb_keshi_jili where " + total_keshi + " between total_begin and total_end");
            
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

        public decimal GetJiLiStart(decimal total_keshi)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select total_begin from tb_keshi_jili where " + total_keshi + " between total_begin and total_end");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.tb_keshi_jili GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,total_begin,total_end,add_wages,add_time,dangwei  ");
            strSql.Append("  from tb_keshi_jili ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.tb_keshi_jili model = new Model.tb_keshi_jili();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dangwei"].ToString() != "")
                {
                    model.dangwei = int.Parse(ds.Tables[0].Rows[0]["dangwei"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total_begin"].ToString() != "")
                {
                    model.total_begin = decimal.Parse(ds.Tables[0].Rows[0]["total_begin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total_end"].ToString() != "")
                {
                    model.total_end = decimal.Parse(ds.Tables[0].Rows[0]["total_end"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_wages"].ToString() != "")
                {
                    model.add_wages = decimal.Parse(ds.Tables[0].Rows[0]["add_wages"].ToString());
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

        public Model.tb_keshi_jili GetModelDangWei(int dangwei)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,total_begin,total_end,add_wages,add_time,dangwei  ");
            strSql.Append("  from tb_keshi_jili ");
            strSql.Append(" where dangwei=@dangwei");
            SqlParameter[] parameters = {
					new SqlParameter("@dangwei", SqlDbType.Int,4)
			};
            parameters[0].Value = dangwei;


            Model.tb_keshi_jili model = new Model.tb_keshi_jili();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dangwei"].ToString() != "")
                {
                    model.dangwei = int.Parse(ds.Tables[0].Rows[0]["dangwei"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total_begin"].ToString() != "")
                {
                    model.total_begin = decimal.Parse(ds.Tables[0].Rows[0]["total_begin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total_end"].ToString() != "")
                {
                    model.total_end = decimal.Parse(ds.Tables[0].Rows[0]["total_end"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_wages"].ToString() != "")
                {
                    model.add_wages = decimal.Parse(ds.Tables[0].Rows[0]["add_wages"].ToString());
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
            strSql.Append(" FROM tb_keshi_jili ");
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
                strSql.Append(" FROM tb_keshi_jili ");
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
            strSql.Append(" FROM tb_keshi_jili ");
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
                strSql.Append(" FROM tb_keshi_jili ");
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
            strSql.Append("select * FROM tb_keshi_jili ");
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
                strSql.Append("select " + strSelect + " FROM tb_keshi_jili ");
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
