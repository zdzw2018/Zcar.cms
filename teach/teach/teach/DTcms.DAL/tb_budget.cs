using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_budget
    public partial class budget
    {
        public budget() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_budget");
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
        public int Add(Model.budget model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_budget(");
            strSql.Append("budget_publicity,budget_price,budget_date,add_time,user_id,remark,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@budget_publicity,@budget_price,@budget_date,@add_time,@user_id,@remark,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@budget_publicity", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@budget_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@budget_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,1024),             
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
            };

            parameters[0].Value = model.budget_publicity;
            parameters[1].Value = model.budget_price;
            parameters[2].Value = model.budget_date;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.user_id;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.xiaoqu;

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
            strSql.Append("update tb_budget set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.budget model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_budget set ");

            strSql.Append(" budget_publicity = @budget_publicity , ");
            strSql.Append(" budget_price = @budget_price , ");
            strSql.Append(" budget_date = @budget_date , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" remark = @remark , ");
            strSql.Append(" xiaoqu = @xiaoqu  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@budget_publicity", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@budget_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@budget_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,1024)  ,
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) ,   
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.budget_publicity;
            parameters[2].Value = model.budget_price;
            parameters[3].Value = model.budget_date;
            parameters[4].Value = model.add_time;
            parameters[5].Value = model.user_id;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.xiaoqu;
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
            strSql.Append("delete from tb_budget ");
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
        public Model.budget GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, budget_publicity, budget_price, budget_date, add_time, user_id, remark ,xiaoqu ");
            strSql.Append("  from tb_budget ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.budget model = new Model.budget();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.budget_publicity = ds.Tables[0].Rows[0]["budget_publicity"].ToString();
                if (ds.Tables[0].Rows[0]["budget_price"].ToString() != "")
                {
                    model.budget_price = decimal.Parse(ds.Tables[0].Rows[0]["budget_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["budget_date"].ToString() != "")
                {
                    model.budget_date = DateTime.Parse(ds.Tables[0].Rows[0]["budget_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();

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
            strSql.Append(" FROM tb_budget ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetReport(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM  view_market_count ");
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
            strSql.Append(" FROM tb_budget ");
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
            strSql.Append("select * FROM tb_budget ");
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
