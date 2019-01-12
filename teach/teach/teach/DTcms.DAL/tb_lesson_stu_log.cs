using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_lesson_stu_log
    public partial class lesson_stu_log
    {
        public lesson_stu_log() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_lesson_stu_log");
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
        public int Add(Model.lesson_stu_log model)
        {
            DAL.lesson dallesson = new lesson();
            Model.lesson modellesson = dallesson.GetModel(model.lesson_id);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_lesson_stu_log(");
            strSql.Append("stu_id,lesson_id,stu_lesson,add_time,user_id,channel_id");
            strSql.Append(") values (");
            strSql.Append("@stu_id,@lesson_id,@stu_lesson,@add_time,@user_id,@channel_id");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.stu_id;
            parameters[1].Value = model.lesson_id;
            parameters[2].Value = model.stu_lesson;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.user_id;
            parameters[5].Value = model.channel_id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                //DAL.student_info dal = new DAL.student_info();
                //dal.UpdateField(model.stu_id, " stu_lesson=stu_lesson-"+modellesson.lesson_count);
                return Convert.ToInt32(obj);
            }
        }

        public void Add(List<Model.lesson_stu_log> list) 
        {
            foreach (Model.lesson_stu_log item in list)
            {
                if (item.id == 0) 
                {
                    Add(item);
                }
            }
        }



        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_lesson_stu_log set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.lesson_stu_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_lesson_stu_log set ");

            strSql.Append(" stu_id = @stu_id , ");
            strSql.Append(" lesson_id = @lesson_id , ");
            strSql.Append(" stu_lesson = @stu_lesson , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" channel_id = @channel_id  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@lesson_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_lesson", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.stu_id;
            parameters[2].Value = model.lesson_id;
            parameters[3].Value = model.stu_lesson;
            parameters[4].Value = model.add_time;
            parameters[5].Value = model.user_id;
            parameters[6].Value = model.channel_id;
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

        public void Delete(List<Model.lesson_stu_log> models, int lesson_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.lesson_stu_log modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
                string id_list = Utils.DelLastChar(idList.ToString(), ",");
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from tb_lesson_stu_log ");
                strSql.Append(" where id not in ( ");
                strSql.Append(id_list);
                strSql.Append(" ) ");
            }
        }
        
            
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_lesson_stu_log ");
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
        public Model.lesson_stu_log GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, stu_id, lesson_id, stu_lesson, add_time, user_id, channel_id  ");
            strSql.Append("  from tb_lesson_stu_log ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.lesson_stu_log model = new Model.lesson_stu_log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

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
                if (ds.Tables[0].Rows[0]["lesson_id"].ToString() != "")
                {
                    model.lesson_id = int.Parse(ds.Tables[0].Rows[0]["lesson_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stu_lesson"].ToString() != "")
                {
                    model.stu_lesson = int.Parse(ds.Tables[0].Rows[0]["stu_lesson"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
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
            strSql.Append(" FROM tb_lesson_stu_log ");
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
                strSql.Append(" FROM tb_lesson_stu_log ");
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
            strSql.Append(" FROM tb_lesson_stu_log ");
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
                strSql.Append(" FROM tb_lesson_stu_log ");
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
            strSql.Append("select * FROM tb_lesson_stu_log ");
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
                strSql.Append("select " + strSelect + " FROM tb_lesson_stu_log ");
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

        public List<Model.lesson_stu_log> GetList(DataTable dt)
        {
            List<Model.lesson_stu_log> list = new List<Model.lesson_stu_log>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(GetModel(item));
            }
            return list;
        }

        public Model.lesson_stu_log GetModel(DataRow dr)
        {
            Model.lesson_stu_log model = new Model.lesson_stu_log();
            if (dr["id"].ToString() != "")
            {
                model.id = int.Parse(dr["id"].ToString());
            }
            if (dr["stu_id"].ToString() != "")
            {
                model.stu_id = int.Parse(dr["stu_id"].ToString());
            }
            if (dr["lesson_id"].ToString() != "")
            {
                model.lesson_id = int.Parse(dr["lesson_id"].ToString());
            }
            if (dr["stu_lesson"].ToString() != "")
            {
                model.stu_lesson = int.Parse(dr["stu_lesson"].ToString());
            }
            if (dr["add_time"].ToString() != "")
            {
                model.add_time = DateTime.Parse(dr["add_time"].ToString());
            }
            if (dr["user_id"].ToString() != "")
            {
                model.user_id = int.Parse(dr["user_id"].ToString());
            }
            if (dr["channel_id"].ToString() != "")
            {
                model.channel_id = int.Parse(dr["channel_id"].ToString());
            }
            return model;
        }

        public List<Model.lesson_stu_log> GetListbyModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_lesson_stu_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return GetList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        public int GetLettonCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(stu_lesson) ");
            strSql.Append(" FROM tb_lesson_stu_log ");
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
        
    }

}
