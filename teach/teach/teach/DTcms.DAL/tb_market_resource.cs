using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_market_resource
		public partial class market_resource
	{
   		public market_resource(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_market_resource");
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
		public int Add(Model.market_resource model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_market_resource(");			
            strSql.Append("rcollect_date,add_time,rparent_name,rstudent_name,rschool,rgrade,raddr,rmarket_man,rcollect_choose,remark,user_id,other,tel,xiaoqu");
			strSql.Append(") values (");
            strSql.Append("@rcollect_date,@add_time,@rparent_name,@rstudent_name,@rschool,@rgrade,@raddr,@rmarket_man,@rcollect_choose,@remark,@user_id,@other,@tel,@xiaoqu");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@rcollect_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@rparent_name", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rstudent_name", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rschool", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rgrade", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@raddr", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rmarket_man", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rcollect_choose", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@other", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) 
            };
			            
            parameters[0].Value = model.rcollect_date;                        
            parameters[1].Value = model.add_time;                        
            parameters[2].Value = model.rparent_name;                        
            parameters[3].Value = model.rstudent_name;                        
            parameters[4].Value = model.rschool;                        
            parameters[5].Value = model.rgrade;                        
            parameters[6].Value = model.raddr;                        
            parameters[7].Value = model.rmarket_man;                        
            parameters[8].Value = model.rcollect_choose;                        
            parameters[9].Value = model.remark;                        
            parameters[10].Value = model.user_id;                        
            parameters[11].Value = model.other;                        
            parameters[12].Value = model.tel;
            parameters[13].Value = model.xiaoqu;
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
            strSql.Append("update tb_market_resource set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.market_resource model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_market_resource set ");
			                                                
            strSql.Append(" rcollect_date = @rcollect_date , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" rparent_name = @rparent_name , ");                                    
            strSql.Append(" rstudent_name = @rstudent_name , ");                                    
            strSql.Append(" rschool = @rschool , ");                                    
            strSql.Append(" rgrade = @rgrade , ");                                    
            strSql.Append(" raddr = @raddr , ");                                    
            strSql.Append(" rmarket_man = @rmarket_man , ");                                    
            strSql.Append(" rcollect_choose = @rcollect_choose , ");                                    
            strSql.Append(" remark = @remark , ");                                    
            strSql.Append(" user_id = @user_id , ");                                    
            strSql.Append(" other = @other , ");                                    
            strSql.Append(" tel = @tel,  ");
            strSql.Append(" xiaoqu = @xiaoqu  "); 		
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@rcollect_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@rparent_name", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rstudent_name", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rschool", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rgrade", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@raddr", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rmarket_man", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@rcollect_choose", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@other", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)  
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.rcollect_date;                        
            parameters[2].Value = model.add_time;                        
            parameters[3].Value = model.rparent_name;                        
            parameters[4].Value = model.rstudent_name;                        
            parameters[5].Value = model.rschool;                        
            parameters[6].Value = model.rgrade;                        
            parameters[7].Value = model.raddr;                        
            parameters[8].Value = model.rmarket_man;                        
            parameters[9].Value = model.rcollect_choose;                        
            parameters[10].Value = model.remark;                        
            parameters[11].Value = model.user_id;                        
            parameters[12].Value = model.other;                        
            parameters[13].Value = model.tel;
            parameters[14].Value = model.xiaoqu;          
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
			strSql.Append("delete from tb_market_resource ");
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
		public Model.market_resource GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, rcollect_date, add_time, rparent_name, rstudent_name, rschool, rgrade, raddr, rmarket_man, rcollect_choose, remark, user_id, other, tel,xiaoqu  ");			
			strSql.Append("  from tb_market_resource ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.market_resource model=new Model.market_resource();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rcollect_date"].ToString() != "")
                {
                    model.rcollect_date = DateTime.Parse(ds.Tables[0].Rows[0]["rcollect_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.rparent_name = ds.Tables[0].Rows[0]["rparent_name"].ToString();
                model.rstudent_name = ds.Tables[0].Rows[0]["rstudent_name"].ToString();
                model.rschool = ds.Tables[0].Rows[0]["rschool"].ToString();
                model.rgrade = ds.Tables[0].Rows[0]["rgrade"].ToString();
                model.raddr = ds.Tables[0].Rows[0]["raddr"].ToString();
                model.rmarket_man = ds.Tables[0].Rows[0]["rmarket_man"].ToString();
                model.rcollect_choose = ds.Tables[0].Rows[0]["rcollect_choose"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                model.other = ds.Tables[0].Rows[0]["other"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();

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
			strSql.Append(" FROM tb_market_resource ");
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
			strSql.Append(" FROM tb_market_resource ");
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
			strSql.Append(" FROM tb_market_resource ");
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
			strSql.Append(" FROM tb_market_resource ");
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
            strSql.Append("select * FROM tb_market_resource ");
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
            strSql.Append("select "+strSelect+" FROM tb_market_resource ");
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
