using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_monthly_budget
		public partial class monthly_budget
	{
   		public monthly_budget(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_monthly_budget");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.monthly_budget model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_monthly_budget(");
            strSql.Append("propaganda,month,budget,total_cost,channel_id,budget_opinion");
            strSql.Append(") values (");
            strSql.Append("@propaganda,@month,@budget,@total_cost,@channel_id,@budget_opinion");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@propaganda", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@month", SqlDbType.Int,4) ,            
                        new SqlParameter("@budget", SqlDbType.Money,8) ,            
                        new SqlParameter("@total_cost", SqlDbType.Money,8) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@budget_opinion", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.propaganda;
            parameters[1].Value = model.month;
            parameters[2].Value = model.budget;
            parameters[3].Value = model.total_cost;
            parameters[4].Value = model.channel_id;
            parameters[5].Value = model.budget_opinion;

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
            strSql.Append("update tb_monthly_budget set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.monthly_budget model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_monthly_budget set ");

            strSql.Append(" propaganda = @propaganda , ");
            strSql.Append(" month = @month , ");
            strSql.Append(" budget = @budget , ");
            strSql.Append(" total_cost = @total_cost , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" budget_opinion = @budget_opinion  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@propaganda", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@month", SqlDbType.Int,4) ,            
                        new SqlParameter("@budget", SqlDbType.Money,8) ,            
                        new SqlParameter("@total_cost", SqlDbType.Money,8) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@budget_opinion", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.propaganda;
            parameters[2].Value = model.month;
            parameters[3].Value = model.budget;
            parameters[4].Value = model.total_cost;
            parameters[5].Value = model.channel_id;
            parameters[6].Value = model.budget_opinion;
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_monthly_budget ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public Model.monthly_budget GetModel(int id)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from tb_monthly_budget ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.monthly_budget model = new Model.monthly_budget();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.propaganda = ds.Tables[0].Rows[0]["propaganda"].ToString();
                if (ds.Tables[0].Rows[0]["month"].ToString() != "")
                {
                    model.month = int.Parse(ds.Tables[0].Rows[0]["month"].ToString());
                }
                if (ds.Tables[0].Rows[0]["budget"].ToString() != "")
                {
                    model.budget = decimal.Parse(ds.Tables[0].Rows[0]["budget"].ToString());
                }
                if (ds.Tables[0].Rows[0]["total_cost"].ToString() != "")
                {
                    model.total_cost = decimal.Parse(ds.Tables[0].Rows[0]["total_cost"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                model.budget_opinion = ds.Tables[0].Rows[0]["budget_opinion"].ToString();

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM tb_monthly_budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strSelect,string strWhere)
		{
		if(strSelect!=""){
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select "+strSelect);
			strSql.Append(" FROM tb_monthly_budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
			}
			else
			return GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM tb_monthly_budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strSelect,string strWhere,string filedOrder)
		{
		if(strSelect!="")
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(strSelect);
			strSql.Append(" FROM tb_monthly_budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
			}
			else return GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得查询分页数据
		/// </summary>
		public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM tb_monthly_budget ");
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
		public DataSet GetList(int pageSize, int pageIndex,string strSelect, string strWhere, string filedOrder, out int recordCount)
		{
		if(strSelect!="")
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+strSelect+" FROM tb_monthly_budget ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList( pageSize,  pageIndex,  strWhere, filedOrder,out recordCount);
		}
        #endregion  Method		
	}

}
