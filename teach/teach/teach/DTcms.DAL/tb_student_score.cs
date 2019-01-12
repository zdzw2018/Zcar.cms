using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_student_score
		public partial class student_score
	{
   		public student_score(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_student_score");
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
		public int Add(Model.student_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_student_score(");			
            strSql.Append("stu_id,stu_name,lesson_01,lesson_02,lesson_03,lesson_04,lesson_05,lesson_06,lesson_07,lesson_08,lesson_09,lesson_010,lesson_count,lesson_year,lesson_semester,lesson_type,add_time,user_id,user_name,remark");
			strSql.Append(") values (");
            strSql.Append("@stu_id,@stu_name,@lesson_01,@lesson_02,@lesson_03,@lesson_04,@lesson_05,@lesson_06,@lesson_07,@lesson_08,@lesson_09,@lesson_010,@lesson_count,@lesson_year,@lesson_semester,@lesson_type,@add_time,@user_id,@user_name,@remark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_01", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_02", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_03", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_04", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_05", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_06", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_07", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_08", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_09", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_010", SqlDbType.Decimal,9) ,            
                                  
                        new SqlParameter("@lesson_count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_year", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_semester", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_type", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.NVarChar,50),
                        new SqlParameter("@remark", SqlDbType.NText) 
              
            };
			            
            parameters[0].Value = model.stu_id;                        
            parameters[1].Value = model.stu_name;                        
            parameters[2].Value = model.lesson_01;                        
            parameters[3].Value = model.lesson_02;                        
            parameters[4].Value = model.lesson_03;                        
            parameters[5].Value = model.lesson_04;                        
            parameters[6].Value = model.lesson_05;                        
            parameters[7].Value = model.lesson_06;                        
            parameters[8].Value = model.lesson_07;                        
            parameters[9].Value = model.lesson_08;                        
            parameters[10].Value = model.lesson_09;                        
            parameters[11].Value = model.lesson_010;                        
                                 
            parameters[12].Value = model.lesson_count;                        
            parameters[13].Value = model.lesson_year;                        
            parameters[14].Value = model.lesson_semester;                        
            parameters[15].Value = model.lesson_type;                        
            parameters[16].Value = model.add_time;                        
            parameters[17].Value = model.user_id;                        
            parameters[18].Value = model.user_name;
            parameters[19].Value = model.remark;        
			   
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
            strSql.Append("update tb_student_score set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.student_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_student_score set ");
			                                                
            strSql.Append(" stu_id = @stu_id , ");                                    
            strSql.Append(" stu_name = @stu_name , ");                                    
            strSql.Append(" lesson_01 = @lesson_01 , ");                                    
            strSql.Append(" lesson_02 = @lesson_02 , ");                                    
            strSql.Append(" lesson_03 = @lesson_03 , ");                                    
            strSql.Append(" lesson_04 = @lesson_04 , ");                                    
            strSql.Append(" lesson_05 = @lesson_05 , ");                                    
            strSql.Append(" lesson_06 = @lesson_06 , ");                                    
            strSql.Append(" lesson_07 = @lesson_07 , ");                                    
            strSql.Append(" lesson_08 = @lesson_08 , ");                                    
            strSql.Append(" lesson_09 = @lesson_09 , ");                                    
            strSql.Append(" lesson_010 = @lesson_010 , ");                                    
            strSql.Append(" lesson_011 = @lesson_011 , ");                                    
            strSql.Append(" lesson_012 = @lesson_012 , ");                                    
            strSql.Append(" lesson_013 = @lesson_013 , ");                                    
            strSql.Append(" lesson_count = @lesson_count , ");                                    
            strSql.Append(" lesson_year = @lesson_year , ");                                    
            strSql.Append(" lesson_semester = @lesson_semester , ");                                    
            strSql.Append(" lesson_type = @lesson_type , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" user_id = @user_id , ");                                    
            strSql.Append(" user_name = @user_name , ");
            strSql.Append(" remark = @remark  "); 		
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_01", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_02", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_03", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_04", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_05", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_06", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_07", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_08", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_09", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_010", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_011", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_012", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_013", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_year", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_semester", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_type", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@remark", SqlDbType.NText)
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.stu_id;                        
            parameters[2].Value = model.stu_name;                        
            parameters[3].Value = model.lesson_01;                        
            parameters[4].Value = model.lesson_02;                        
            parameters[5].Value = model.lesson_03;                        
            parameters[6].Value = model.lesson_04;                        
            parameters[7].Value = model.lesson_05;                        
            parameters[8].Value = model.lesson_06;                        
            parameters[9].Value = model.lesson_07;                        
            parameters[10].Value = model.lesson_08;                        
            parameters[11].Value = model.lesson_09;                        
            parameters[12].Value = model.lesson_010;                        
            parameters[13].Value = model.lesson_011;                        
            parameters[14].Value = model.lesson_012;                        
            parameters[15].Value = model.lesson_013;                        
            parameters[16].Value = model.lesson_count;                        
            parameters[17].Value = model.lesson_year;                        
            parameters[18].Value = model.lesson_semester;                        
            parameters[19].Value = model.lesson_type;                        
            parameters[20].Value = model.add_time;                        
            parameters[21].Value = model.user_id;                        
            parameters[22].Value = model.user_name;
            parameters[23].Value = model.remark;          
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
			strSql.Append("delete from tb_student_score ");
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
		public Model.student_score GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, stu_id, stu_name, lesson_01, lesson_02, lesson_03, lesson_04, lesson_05, lesson_06, lesson_07, lesson_08, lesson_09, lesson_010, lesson_011, lesson_012, lesson_013, lesson_count, lesson_year, lesson_semester, lesson_type, add_time, user_id, user_name,remark  ");			
			strSql.Append("  from tb_student_score ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.student_score model=new Model.student_score();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(ds.Tables[0].Rows[0]["stu_id"].ToString());
                }
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();
                if (ds.Tables[0].Rows[0]["lesson_01"].ToString() != "")
                {
                    model.lesson_01 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_02"].ToString() != "")
                {
                    model.lesson_02 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_03"].ToString() != "")
                {
                    model.lesson_03 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_03"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_04"].ToString() != "")
                {
                    model.lesson_04 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_04"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_05"].ToString() != "")
                {
                    model.lesson_05 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_05"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_06"].ToString() != "")
                {
                    model.lesson_06 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_06"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_07"].ToString() != "")
                {
                    model.lesson_07 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_07"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_08"].ToString() != "")
                {
                    model.lesson_08 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_08"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_09"].ToString() != "")
                {
                    model.lesson_09 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_09"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_010"].ToString() != "")
                {
                    model.lesson_010 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_010"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_011"].ToString() != "")
                {
                    model.lesson_011 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_011"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_012"].ToString() != "")
                {
                    model.lesson_012 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_012"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_013"].ToString() != "")
                {
                    model.lesson_013 = decimal.Parse(ds.Tables[0].Rows[0]["lesson_013"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_count"].ToString() != "")
                {
                    model.lesson_count = decimal.Parse(ds.Tables[0].Rows[0]["lesson_count"].ToString());
                }
                model.lesson_year = ds.Tables[0].Rows[0]["lesson_year"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.lesson_semester = ds.Tables[0].Rows[0]["lesson_semester"].ToString();
                model.lesson_type = ds.Tables[0].Rows[0]["lesson_type"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();

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
			strSql.Append(" FROM tb_student_score ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" FROM tb_student_score ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select * FROM tb_student_score ");
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
