using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_station_letters
		public partial class station_letters
	{
   		public station_letters(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_station_letters");
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
		public int Add(Model.station_letters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_station_letters(");			
            strSql.Append("role,real_name,content,remark,item_type,add_time,item_id,status");
			strSql.Append(") values (");
            strSql.Append("@role,@real_name,@content,@remark,@item_type,@add_time,@item_id,@status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@role", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@real_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@item_type", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@item_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@status", SqlDbType.TinyInt,1)             
              
            };
			            
            parameters[0].Value = model.role;                        
            parameters[1].Value = model.real_name;                        
            parameters[2].Value = model.content;                        
            parameters[3].Value = model.remark;                        
            parameters[4].Value = model.item_type;                        
            parameters[5].Value = model.add_time;                        
            parameters[6].Value = model.item_id;                        
            parameters[7].Value = model.status;                        
			   
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
            strSql.Append("update tb_station_letters set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.station_letters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_station_letters set ");
			                                                
            strSql.Append(" role = @role , ");                                    
            strSql.Append(" real_name = @real_name , ");                                    
            strSql.Append(" content = @content , ");                                    
            strSql.Append(" remark = @remark , ");                                    
            strSql.Append(" item_type = @item_type , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" item_id = @item_id , ");                                    
            strSql.Append(" status = @status  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@role", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@real_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@item_type", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@item_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@status", SqlDbType.TinyInt,1)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.role;                        
            parameters[2].Value = model.real_name;                        
            parameters[3].Value = model.content;                        
            parameters[4].Value = model.remark;                        
            parameters[5].Value = model.item_type;                        
            parameters[6].Value = model.add_time;                        
            parameters[7].Value = model.item_id;                        
            parameters[8].Value = model.status;                        
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
			strSql.Append("delete from tb_station_letters ");
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
		public Model.station_letters GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, role, real_name, content, remark, item_type, add_time, item_id, status  ");			
			strSql.Append("  from tb_station_letters ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.station_letters model=new Model.station_letters();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.role= ds.Tables[0].Rows[0]["role"].ToString();
																																model.real_name= ds.Tables[0].Rows[0]["real_name"].ToString();
																																model.content= ds.Tables[0].Rows[0]["content"].ToString();
																																model.remark= ds.Tables[0].Rows[0]["remark"].ToString();
																																model.item_type= ds.Tables[0].Rows[0]["item_type"].ToString();
																												if(ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["item_id"].ToString()!="")
				{
					model.item_id=int.Parse(ds.Tables[0].Rows[0]["item_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
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
			strSql.Append(" FROM tb_station_letters ");
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
			strSql.Append(" FROM tb_station_letters ");
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
			strSql.Append(" FROM tb_station_letters ");
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
			strSql.Append(" FROM tb_station_letters ");
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
            strSql.Append("select * FROM tb_station_letters ");
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
            strSql.Append("select "+strSelect+" FROM tb_station_letters ");
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
