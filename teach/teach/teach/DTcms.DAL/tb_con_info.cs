using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_contract_info
		public partial class con_info
	{
            public con_info() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_contract_info");
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
        public int Add(Model.con_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_contract_info(");			
            strSql.Append("contract_info,contract_id,buy_lesson,sessions_price,service_price,education_price,un_edu");
			strSql.Append(") values (");
            strSql.Append("@contract_info,@contract_id,@buy_lesson,@sessions_price,@service_price,@education_price,@un_edu");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@contract_info", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@buy_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@sessions_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@service_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@education_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@un_edu", SqlDbType.Money,8)             
              
            };
			            
            parameters[0].Value = model.contract_info;                        
            parameters[1].Value = model.contract_id;                        
            parameters[2].Value = model.buy_lesson;                        
            parameters[3].Value = model.sessions_price;                        
            parameters[4].Value = model.service_price;                        
            parameters[5].Value = model.education_price;                        
            parameters[6].Value = model.un_edu;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
            strSql.Append("update tb_contract_info set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Model.con_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_contract_info set ");
			                                                
            strSql.Append(" contract_info = @contract_info , ");                                    
            strSql.Append(" contract_id = @contract_id , ");                                    
            strSql.Append(" buy_lesson = @buy_lesson , ");                                    
            strSql.Append(" sessions_price = @sessions_price , ");                                    
            strSql.Append(" service_price = @service_price , ");                                    
            strSql.Append(" education_price = @education_price , ");                                    
            strSql.Append(" un_edu = @un_edu  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@contract_info", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@buy_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@sessions_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@service_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@education_price", SqlDbType.Money,8) ,            
                        new SqlParameter("@un_edu", SqlDbType.Money,8)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.contract_info;                        
            parameters[2].Value = model.contract_id;                        
            parameters[3].Value = model.buy_lesson;                        
            parameters[4].Value = model.sessions_price;                        
            parameters[5].Value = model.service_price;                        
            parameters[6].Value = model.education_price;                        
            parameters[7].Value = model.un_edu;                        
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_contract_info ");
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
        public Model.con_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, contract_info, contract_id, buy_lesson, sessions_price, service_price, education_price, un_edu  ");			
			strSql.Append("  from tb_contract_info ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;


            Model.con_info model = new Model.con_info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.contract_info= ds.Tables[0].Rows[0]["contract_info"].ToString();
																												if(ds.Tables[0].Rows[0]["contract_id"].ToString()!="")
				{
					model.contract_id=int.Parse(ds.Tables[0].Rows[0]["contract_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["buy_lesson"].ToString()!="")
				{
					model.buy_lesson=int.Parse(ds.Tables[0].Rows[0]["buy_lesson"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sessions_price"].ToString()!="")
				{
					model.sessions_price=decimal.Parse(ds.Tables[0].Rows[0]["sessions_price"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["service_price"].ToString()!="")
				{
					model.service_price=decimal.Parse(ds.Tables[0].Rows[0]["service_price"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["education_price"].ToString()!="")
				{
					model.education_price=decimal.Parse(ds.Tables[0].Rows[0]["education_price"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["un_edu"].ToString()!="")
				{
					model.un_edu=decimal.Parse(ds.Tables[0].Rows[0]["un_edu"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM tb_contract_info ");
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
			strSql.Append(" FROM tb_contract_info ");
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
			strSql.Append(" FROM tb_contract_info ");
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
			strSql.Append(" FROM tb_contract_info ");
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
            strSql.Append("select * FROM tb_contract_info ");
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
            strSql.Append("select "+strSelect+" FROM tb_contract_info ");
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
