using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_student_info
    public partial class student_info
    {
        public student_info() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from view_student_info");
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
        public int Add(Model.student_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_student_info(");
            strSql.Append("stu_parent_name,stu_name,stu_tel,stu_school,stu_grade,stu_addr,stu_lesson,stu_remark,user_id,channel_id,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@stu_parent_name,@stu_name,@stu_tel,@stu_school,@stu_grade,@stu_addr,@stu_lesson,@stu_remark,@user_id,@channel_id,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@stu_parent_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_tel", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_school", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_grade", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_addr", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_remark", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.stu_parent_name;
            parameters[1].Value = model.stu_name;
            parameters[2].Value = model.stu_tel;
            parameters[3].Value = model.stu_school;
            parameters[4].Value = model.stu_grade;
            parameters[5].Value = model.stu_addr;
            parameters[6].Value = model.stu_lesson;
            parameters[7].Value = model.stu_remark;
            parameters[8].Value = model.user_id;
            parameters[9].Value = model.channel_id;
            parameters[10].Value = model.xiaoqu;

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
            strSql.Append("update tb_student_info set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.student_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_student_info set ");

            strSql.Append(" stu_parent_name = @stu_parent_name , ");
            strSql.Append(" stu_name = @stu_name , ");
            strSql.Append(" stu_tel = @stu_tel , ");
            strSql.Append(" stu_school = @stu_school , ");
            strSql.Append(" stu_grade = @stu_grade , ");
            strSql.Append(" stu_addr = @stu_addr , ");
            strSql.Append(" stu_lesson = @stu_lesson , ");
            strSql.Append(" stu_remark = @stu_remark , ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" xiaoqu = @xiaoqu  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_parent_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_tel", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_school", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_grade", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@stu_addr", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_remark", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.stu_parent_name;
            parameters[2].Value = model.stu_name;
            parameters[3].Value = model.stu_tel;
            parameters[4].Value = model.stu_school;
            parameters[5].Value = model.stu_grade;
            parameters[6].Value = model.stu_addr;
            parameters[7].Value = model.stu_lesson;
            parameters[8].Value = model.stu_remark;
            parameters[9].Value = model.user_id;
            parameters[10].Value = model.channel_id;
            parameters[11].Value = model.xiaoqu;

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
            strSql.Append("delete from tb_student_info ");
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
        public Model.student_info GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from view_student_info ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.student_info model = new Model.student_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.stu_parent_name = ds.Tables[0].Rows[0]["stu_parent_name"].ToString();
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();
                model.stu_tel = ds.Tables[0].Rows[0]["stu_tel"].ToString();
                model.stu_school = ds.Tables[0].Rows[0]["stu_school"].ToString();
                model.stu_grade = ds.Tables[0].Rows[0]["stu_grade"].ToString();
                model.stu_addr = ds.Tables[0].Rows[0]["stu_addr"].ToString();
                if (ds.Tables[0].Rows[0]["stu_lesson"].ToString() != "")
                {
                    model.stu_lesson = decimal.Parse(ds.Tables[0].Rows[0]["stu_lesson"].ToString());
                }
                model.stu_remark = ds.Tables[0].Rows[0]["stu_remark"].ToString();
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_student_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strSelect, string strWhere)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect);
                strSql.Append(" FROM tb_student_info ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperSQL.Query(strSql.ToString());
            }
            else
                return GetList(strWhere);
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
            strSql.Append(" FROM tb_student_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strSelect, string strWhere, string filedOrder)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(strSelect);
                strSql.Append(" FROM view_student_info ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                return DbHelperSQL.Query(strSql.ToString());
            }
            else return GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM view_student_info ");
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
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect + " FROM view_student_info ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
                return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }

}
