using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_visit
		public partial class visit
	{
   		public visit(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_visit");
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
		public int Add(Model.visit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_visit(");			
            strSql.Append("visit_n_time,visit_name,visit_to_name,visit_content,channel_id,add_time,user_id");
			strSql.Append(") values (");
            strSql.Append("@visit_n_time,@visit_name,@visit_to_name,@visit_content,@channel_id,@add_time,@user_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@visit_n_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@visit_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visit_to_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visit_content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.visit_n_time;                        
            parameters[1].Value = model.visit_name;                        
            parameters[2].Value = model.visit_to_name;                        
            parameters[3].Value = model.visit_content;                        
            parameters[4].Value = model.channel_id;                        
            parameters[5].Value = model.add_time;                        
            parameters[6].Value = model.user_id;                        
			   
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
            strSql.Append("update tb_visit set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.visit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_visit set ");
			                                                
            strSql.Append(" visit_n_time = @visit_n_time , ");                                    
            strSql.Append(" visit_name = @visit_name , ");                                    
            strSql.Append(" visit_to_name = @visit_to_name , ");                                    
            strSql.Append(" visit_content = @visit_content , ");                                    
            strSql.Append(" channel_id = @channel_id , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" user_id = @user_id  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@visit_n_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@visit_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visit_to_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visit_content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.visit_n_time;                        
            parameters[2].Value = model.visit_name;                        
            parameters[3].Value = model.visit_to_name;                        
            parameters[4].Value = model.visit_content;                        
            parameters[5].Value = model.channel_id;                        
            parameters[6].Value = model.add_time;                        
            parameters[7].Value = model.user_id;                        
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
			strSql.Append("delete from tb_visit ");
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
		public Model.visit GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, visit_n_time, visit_name, visit_to_name, visit_content, channel_id, add_time, user_id  ");			
			strSql.Append("  from tb_visit ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.visit model=new Model.visit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["visit_n_time"].ToString()!="")
				{
					model.visit_n_time=DateTime.Parse(ds.Tables[0].Rows[0]["visit_n_time"].ToString());
				}
																																				model.visit_name= ds.Tables[0].Rows[0]["visit_name"].ToString();
																																model.visit_to_name= ds.Tables[0].Rows[0]["visit_to_name"].ToString();
																																model.visit_content= ds.Tables[0].Rows[0]["visit_content"].ToString();
																												if(ds.Tables[0].Rows[0]["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
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
			strSql.Append(" FROM tb_visit ");
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
			strSql.Append(" FROM tb_visit ");
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
			strSql.Append(" FROM tb_visit ");
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
			strSql.Append(" FROM tb_visit ");
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
            strSql.Append("select * FROM tb_visit ");
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
            strSql.Append("select "+strSelect+" FROM tb_visit ");
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
