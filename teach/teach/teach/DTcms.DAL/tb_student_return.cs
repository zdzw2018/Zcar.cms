using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_student_return
    public partial class student_return
    {
        public student_return() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_student_return");
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
        public int Add(Model.student_return model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_student_return(");
            strSql.Append("return_user_id,return_user_name,return_content,add_time,return_result,stu_id,stu_name");
            strSql.Append(") values (");
            strSql.Append("@return_user_id,@return_user_name,@return_content,@add_time,@return_result,@stu_id,@stu_name");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@return_user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@return_user_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@return_content", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@return_result", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.return_user_id;
            parameters[1].Value = model.return_user_name;
            parameters[2].Value = model.return_content;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.return_result;
            parameters[5].Value = model.stu_id;
            parameters[6].Value = model.stu_name;

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
            strSql.Append("update tb_student_return set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.student_return model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_student_return set ");

            strSql.Append(" return_user_id = @return_user_id , ");
            strSql.Append(" return_user_name = @return_user_name , ");
            strSql.Append(" return_content = @return_content , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" return_result = @return_result , ");
            strSql.Append(" stu_id = @stu_id , ");
            strSql.Append(" stu_name = @stu_name  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@return_user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@return_user_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@return_content", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@return_result", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.return_user_id;
            parameters[2].Value = model.return_user_name;
            parameters[3].Value = model.return_content;
            parameters[4].Value = model.add_time;
            parameters[5].Value = model.return_result;
            parameters[6].Value = model.stu_id;
            parameters[7].Value = model.stu_name;
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
            strSql.Append("delete from tb_student_return ");
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
        public Model.student_return GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, return_user_id, return_user_name, return_content, add_time, return_result, stu_id, stu_name  ");
            strSql.Append("  from tb_student_return ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.student_return model = new Model.student_return();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["return_user_id"].ToString() != "")
                {
                    model.return_user_id = int.Parse(ds.Tables[0].Rows[0]["return_user_id"].ToString());
                }
                model.return_user_name = ds.Tables[0].Rows[0]["return_user_name"].ToString();
                model.return_content = ds.Tables[0].Rows[0]["return_content"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                model.return_result = ds.Tables[0].Rows[0]["return_result"].ToString();
                if (ds.Tables[0].Rows[0]["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(ds.Tables[0].Rows[0]["stu_id"].ToString());
                }
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public int getReturnCountByMonth(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(id) ");
            strSql.Append(" FROM tb_student_return ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_student_return ");
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
            strSql.Append(" FROM tb_student_return ");
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
            strSql.Append("select * FROM tb_student_return ");
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
