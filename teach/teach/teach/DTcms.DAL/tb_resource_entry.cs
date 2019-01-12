using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_resource_entry
		public partial class resource_entry
	{
   		public resource_entry(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_resource_entry");
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
		public int Add(Model.resource_entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_resource_entry(");			
            strSql.Append("collection_time,parent_name,stu_name,tel,school,grade,address,marketet_man,collection_route,remark,user_id,channel_id");
			strSql.Append(") values (");
            strSql.Append("@collection_time,@parent_name,@stu_name,@tel,@school,@grade,@address,@marketet_man,@collection_route,@remark,@user_id,@channel_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@collection_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@parent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@marketet_man", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@collection_route", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.collection_time;                        
            parameters[1].Value = model.parent_name;                        
            parameters[2].Value = model.stu_name;                        
            parameters[3].Value = model.tel;                        
            parameters[4].Value = model.school;                        
            parameters[5].Value = model.grade;                        
            parameters[6].Value = model.address;                        
            parameters[7].Value = model.marketet_man;                        
            parameters[8].Value = model.collection_route;                        
            parameters[9].Value = model.remark;                        
            parameters[10].Value = model.user_id;                        
            parameters[11].Value = model.channel_id;                        
			   
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
            strSql.Append("update tb_resource_entry set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.resource_entry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_resource_entry set ");
			                                                
            strSql.Append(" collection_time = @collection_time , ");                                    
            strSql.Append(" parent_name = @parent_name , ");                                    
            strSql.Append(" stu_name = @stu_name , ");                                    
            strSql.Append(" tel = @tel , ");                                    
            strSql.Append(" school = @school , ");                                    
            strSql.Append(" grade = @grade , ");                                    
            strSql.Append(" address = @address , ");                                    
            strSql.Append(" marketet_man = @marketet_man , ");                                    
            strSql.Append(" collection_route = @collection_route , ");                                    
            strSql.Append(" remark = @remark , ");                                    
            strSql.Append(" user_id = @user_id , ");                                    
            strSql.Append(" channel_id = @channel_id  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@collection_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@parent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@marketet_man", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@collection_route", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.collection_time;                        
            parameters[2].Value = model.parent_name;                        
            parameters[3].Value = model.stu_name;                        
            parameters[4].Value = model.tel;                        
            parameters[5].Value = model.school;                        
            parameters[6].Value = model.grade;                        
            parameters[7].Value = model.address;                        
            parameters[8].Value = model.marketet_man;                        
            parameters[9].Value = model.collection_route;                        
            parameters[10].Value = model.remark;                        
            parameters[11].Value = model.user_id;                        
            parameters[12].Value = model.channel_id;                        
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
			strSql.Append("delete from tb_resource_entry ");
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
		public Model.resource_entry GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, collection_time, parent_name, stu_name, tel, school, grade, address, marketet_man, collection_route, remark, user_id, channel_id  ");			
			strSql.Append("  from tb_resource_entry ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.resource_entry model=new Model.resource_entry();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["collection_time"].ToString()!="")
				{
					model.collection_time=DateTime.Parse(ds.Tables[0].Rows[0]["collection_time"].ToString());
				}
																																				model.parent_name= ds.Tables[0].Rows[0]["parent_name"].ToString();
																																model.stu_name= ds.Tables[0].Rows[0]["stu_name"].ToString();
																																model.tel= ds.Tables[0].Rows[0]["tel"].ToString();
																																model.school= ds.Tables[0].Rows[0]["school"].ToString();
																																model.grade= ds.Tables[0].Rows[0]["grade"].ToString();
																																model.address= ds.Tables[0].Rows[0]["address"].ToString();
																																model.marketet_man= ds.Tables[0].Rows[0]["marketet_man"].ToString();
																																model.collection_route= ds.Tables[0].Rows[0]["collection_route"].ToString();
																																model.remark= ds.Tables[0].Rows[0]["remark"].ToString();
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
			strSql.Append(" FROM tb_resource_entry ");
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
			strSql.Append(" FROM tb_resource_entry ");
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
			strSql.Append(" FROM tb_resource_entry ");
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
			strSql.Append(" FROM tb_resource_entry ");
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
            strSql.Append("select * FROM tb_resource_entry ");
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
            strSql.Append("select "+strSelect+" FROM tb_resource_entry ");
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
