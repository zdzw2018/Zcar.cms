using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_outfield_entry
		public partial class outfield_entry
	{
   		public outfield_entry(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_outfield_entry");
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
		public int Add(Model.outfield_entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_outfield_entry(");			
            strSql.Append("activity_time,activity_location,activity_content,watchers,collect_msg,oprice_push,part_time_fees,ques_feed,add_time,user_id,channel_id");
			strSql.Append(") values (");
            strSql.Append("@activity_time,@activity_location,@activity_content,@watchers,@collect_msg,@oprice_push,@part_time_fees,@ques_feed,@add_time,@user_id,@channel_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@activity_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@activity_location", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@activity_content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@watchers", SqlDbType.Int,4) ,            
                        new SqlParameter("@collect_msg", SqlDbType.Int,4) ,            
                        new SqlParameter("@oprice_push", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@part_time_fees", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ques_feed", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.activity_time;                        
            parameters[1].Value = model.activity_location;                        
            parameters[2].Value = model.activity_content;                        
            parameters[3].Value = model.watchers;                        
            parameters[4].Value = model.collect_msg;                        
            parameters[5].Value = model.oprice_push;                        
            parameters[6].Value = model.part_time_fees;                        
            parameters[7].Value = model.ques_feed;                        
            parameters[8].Value = model.add_time;                        
            parameters[9].Value = model.user_id;                        
            parameters[10].Value = model.channel_id;                        
			   
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
            strSql.Append("update tb_outfield_entry set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.outfield_entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_outfield_entry set ");
			                                                
            strSql.Append(" activity_time = @activity_time , ");                                    
            strSql.Append(" activity_location = @activity_location , ");                                    
            strSql.Append(" activity_content = @activity_content , ");                                    
            strSql.Append(" watchers = @watchers , ");                                    
            strSql.Append(" collect_msg = @collect_msg , ");                                    
            strSql.Append(" oprice_push = @oprice_push , ");                                    
            strSql.Append(" part_time_fees = @part_time_fees , ");                                    
            strSql.Append(" ques_feed = @ques_feed , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" user_id = @user_id , ");                                    
            strSql.Append(" channel_id = @channel_id  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@activity_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@activity_location", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@activity_content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@watchers", SqlDbType.Int,4) ,            
                        new SqlParameter("@collect_msg", SqlDbType.Int,4) ,            
                        new SqlParameter("@oprice_push", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@part_time_fees", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ques_feed", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.activity_time;                        
            parameters[2].Value = model.activity_location;                        
            parameters[3].Value = model.activity_content;                        
            parameters[4].Value = model.watchers;                        
            parameters[5].Value = model.collect_msg;                        
            parameters[6].Value = model.oprice_push;                        
            parameters[7].Value = model.part_time_fees;                        
            parameters[8].Value = model.ques_feed;                        
            parameters[9].Value = model.add_time;                        
            parameters[10].Value = model.user_id;                        
            parameters[11].Value = model.channel_id;                        
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
			strSql.Append("delete from tb_outfield_entry ");
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
		public Model.outfield_entry GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, activity_time, activity_location, activity_content, watchers, collect_msg, oprice_push, part_time_fees, ques_feed, add_time, user_id, channel_id  ");			
			strSql.Append("  from tb_outfield_entry ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.outfield_entry model=new Model.outfield_entry();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["activity_time"].ToString()!="")
				{
					model.activity_time=DateTime.Parse(ds.Tables[0].Rows[0]["activity_time"].ToString());
				}
																																				model.activity_location= ds.Tables[0].Rows[0]["activity_location"].ToString();
																																model.activity_content= ds.Tables[0].Rows[0]["activity_content"].ToString();
																												if(ds.Tables[0].Rows[0]["watchers"].ToString()!="")
				{
					model.watchers=int.Parse(ds.Tables[0].Rows[0]["watchers"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["collect_msg"].ToString()!="")
				{
					model.collect_msg=int.Parse(ds.Tables[0].Rows[0]["collect_msg"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["oprice_push"].ToString()!="")
				{
					model.oprice_push=decimal.Parse(ds.Tables[0].Rows[0]["oprice_push"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["part_time_fees"].ToString()!="")
				{
					model.part_time_fees=decimal.Parse(ds.Tables[0].Rows[0]["part_time_fees"].ToString());
				}
																																				model.ques_feed= ds.Tables[0].Rows[0]["ques_feed"].ToString();
																												if(ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
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
			strSql.Append(" FROM tb_outfield_entry ");
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
			strSql.Append(" FROM tb_outfield_entry ");
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
			strSql.Append(" FROM tb_outfield_entry ");
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
			strSql.Append(" FROM tb_outfield_entry ");
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
            strSql.Append("select * FROM tb_outfield_entry ");
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
            strSql.Append("select "+strSelect+" FROM tb_outfield_entry ");
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
