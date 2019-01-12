using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class give_lesson
    {
        public give_lesson() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_give_lesson");
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
        public int Add(Model.give_lesson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_give_lesson(");
            strSql.Append("user_id,channel_id,lesson_date,stu_id,lesson_time,lesson_count,lesson_grade,lesson_name,manager_id,manager_name,keshi_status,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@user_id,@channel_id,@lesson_date,@stu_id,@lesson_time,@lesson_count,@lesson_grade,@lesson_name,@manager_id,@manager_name,@keshi_status,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_time", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_grade", SqlDbType.NChar,10) ,            
                        new SqlParameter("@lesson_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@manager_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@manager_name", SqlDbType.NVarChar,1000),
                        new SqlParameter("@keshi_status",SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu",SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.user_id;
            parameters[1].Value = model.channel_id;
            parameters[2].Value = model.lesson_date;
            parameters[3].Value = model.stu_id;
            parameters[4].Value = model.lesson_time;
            parameters[5].Value = model.lesson_count;
            parameters[6].Value = model.lesson_grade;
            parameters[7].Value = model.lesson_name;
            parameters[8].Value = model.manager_id;
            parameters[9].Value = model.manager_name;
            parameters[10].Value = model.keshi_status;
            parameters[11].Value = model.xiaoqu;

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
            strSql.Append("update tb_give_lesson set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.give_lesson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_give_lesson set ");

            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" lesson_date = @lesson_date , ");
            strSql.Append(" stu_id = @stu_id , ");
            strSql.Append(" lesson_time = @lesson_time , ");
            strSql.Append(" lesson_count = @lesson_count , ");
            strSql.Append(" lesson_grade = @lesson_grade , ");
            strSql.Append(" lesson_name = @lesson_name , ");
            strSql.Append(" manager_id = @manager_id , ");
            strSql.Append(" manager_name = @manager_name , ");
            strSql.Append(" keshi_status=@keshi_status, ");
            strSql.Append(" xiaoqu=@xiaoqu ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_time", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@lesson_count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@lesson_grade", SqlDbType.NChar,10) ,            
                        new SqlParameter("@lesson_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@manager_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@manager_name", SqlDbType.NVarChar,1000),
                        new SqlParameter("@keshi_status",SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu",SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.user_id;
            parameters[2].Value = model.channel_id;
            parameters[3].Value = model.lesson_date;
            parameters[4].Value = model.stu_id;
            parameters[5].Value = model.lesson_time;
            parameters[6].Value = model.lesson_count;
            parameters[7].Value = model.lesson_grade;
            parameters[8].Value = model.lesson_name;
            parameters[9].Value = model.manager_id;
            parameters[10].Value = model.manager_name;
            parameters[11].Value = model.keshi_status;
            parameters[12].Value = model.xiaoqu;
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
            strSql.Append("delete from tb_give_lesson ");
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
        public Model.give_lesson GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, user_id, channel_id, lesson_date, stu_id, lesson_time, lesson_count, lesson_grade, lesson_name, manager_id, manager_name,keshi_status,xiaoqu  ");
            strSql.Append("  from tb_give_lesson ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.give_lesson model = new Model.give_lesson();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["keshi_status"].ToString() != "")
                {
                    model.keshi_status = int.Parse(ds.Tables[0].Rows[0]["keshi_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lesson_date"].ToString() != "")
                {
                    model.lesson_date = DateTime.Parse(ds.Tables[0].Rows[0]["lesson_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(ds.Tables[0].Rows[0]["stu_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.lesson_time = ds.Tables[0].Rows[0]["lesson_time"].ToString();
                if (ds.Tables[0].Rows[0]["lesson_count"].ToString() != "")
                {
                    model.lesson_count = decimal.Parse(ds.Tables[0].Rows[0]["lesson_count"].ToString());
                }
                model.lesson_grade = ds.Tables[0].Rows[0]["lesson_grade"].ToString();
                model.lesson_name = ds.Tables[0].Rows[0]["lesson_name"].ToString();
                if (ds.Tables[0].Rows[0]["manager_id"].ToString() != "")
                {
                    model.manager_id = int.Parse(ds.Tables[0].Rows[0]["manager_id"].ToString());
                }
                model.manager_name = ds.Tables[0].Rows[0]["manager_name"].ToString();

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
            strSql.Append(" FROM tb_give_lesson ");
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
                strSql.Append(" FROM tb_give_lesson ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperSQL.Query(strSql.ToString());
            }
            else
                return GetList(strWhere);
        }

        public DataSet GetList(string strWhere, string groupBy, bool isOk)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sum(lesson_count) as lesson ,stu_id  ");
            builder.Append(" FROM tb_give_lesson ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " group by " + groupBy);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public DataSet GetListGroupBy(string strWhere, string groupBy)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" select user_id ,count(distinct stu_id) stucount ,datepart(year,lesson_date) as year , datepart(month,lesson_date) as month ");
            builder.Append(" FROM tb_give_lesson ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " group by " + groupBy);
            }
            return DbHelperSQL.Query(builder.ToString());
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
            strSql.Append(" FROM tb_give_lesson ");
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
                strSql.Append(" FROM tb_give_lesson ");
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
            strSql.Append("select * FROM tb_give_lesson ");
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
                strSql.Append("select " + strSelect + " FROM tb_give_lesson ");
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

        public decimal GetLettonCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(lesson_count) ");
            strSql.Append(" FROM tb_give_lesson ");
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
                return Convert.ToDecimal(obj);
            }
        }
    }
}
