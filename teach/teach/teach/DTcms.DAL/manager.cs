using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:管理员
    /// </summary>
    public partial class manager
    {
        public manager()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_manager");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_manager");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_manager(");
            strSql.Append("add_time,grade,lesson,role_id,role_type,user_name,user_pwd,real_name,telephone,email,is_lock,xiaoqu,is_jianzhi");
            strSql.Append(") values (");
            strSql.Append("@add_time,@grade,@lesson,@role_id,@role_type,@user_name,@user_pwd,@real_name,@telephone,@email,@is_lock,@xiaoqu,@is_jianzhi");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@lesson", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@role_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@user_pwd", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@real_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@telephone", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@email", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@is_lock", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4),
                        new SqlParameter("@is_jianzhi", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.add_time;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.lesson;
            parameters[3].Value = model.role_id;
            parameters[4].Value = model.role_type;
            parameters[5].Value = model.user_name;
            parameters[6].Value = model.user_pwd;
            parameters[7].Value = model.real_name;
            parameters[8].Value = model.telephone;
            parameters[9].Value = model.email;
            parameters[10].Value = model.is_lock;
            parameters[11].Value = model.xiaoqu;
            parameters[12].Value = model.is_jianzhi;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_manager set ");

            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" grade = @grade , ");
            strSql.Append(" lesson = @lesson , ");
            strSql.Append(" role_id = @role_id , ");
            strSql.Append(" role_type = @role_type , ");
            strSql.Append(" user_name = @user_name , ");
            strSql.Append(" user_pwd = @user_pwd , ");
            strSql.Append(" real_name = @real_name , ");
            strSql.Append(" telephone = @telephone , ");
            strSql.Append(" email = @email , ");
            strSql.Append(" is_lock = @is_lock,  ");
            strSql.Append(" xiaoqu = @xiaoqu,  ");
            strSql.Append(" is_jianzhi = @is_jianzhi  ");
            
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@lesson", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@role_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@user_pwd", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@real_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@telephone", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@email", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@is_lock", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4),
                        new SqlParameter("@is_jianzhi", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.add_time;
            parameters[2].Value = model.grade;
            parameters[3].Value = model.lesson;
            parameters[4].Value = model.role_id;
            parameters[5].Value = model.role_type;
            parameters[6].Value = model.user_name;
            parameters[7].Value = model.user_pwd;
            parameters[8].Value = model.real_name;
            parameters[9].Value = model.telephone;
            parameters[10].Value = model.email;
            parameters[11].Value = model.is_lock;
            parameters[12].Value = model.xiaoqu;
            parameters[13].Value = model.is_jianzhi;

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
            strSql.Append("delete from dt_manager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
        public Model.manager GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, add_time, grade, lesson, role_id, role_type, user_name, user_pwd, real_name, telephone, email, is_lock,xiaoqu,is_jianzhi  ");
            strSql.Append("  from dt_manager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.manager model = new Model.manager();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_jianzhi"].ToString() != "")
                {
                    model.is_jianzhi = int.Parse(ds.Tables[0].Rows[0]["is_jianzhi"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                model.grade = ds.Tables[0].Rows[0]["grade"].ToString();
                model.lesson = ds.Tables[0].Rows[0]["lesson"].ToString();
                if (ds.Tables[0].Rows[0]["role_id"].ToString() != "")
                {
                    model.role_id = int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["role_type"].ToString() != "")
                {
                    model.role_type = int.Parse(ds.Tables[0].Rows[0]["role_type"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.user_pwd = ds.Tables[0].Rows[0]["user_pwd"].ToString();
                model.real_name = ds.Tables[0].Rows[0]["real_name"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.manager GetModel(string user_name, string user_pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from dt_manager");
            strSql.Append(" where user_name=@user_name and user_pwd=@user_pwd and is_lock=0");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@user_pwd", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = user_pwd;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dt_manager ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time desc");
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
            strSql.Append(" FROM dt_manager ");
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
            strSql.Append("select * FROM dt_manager");
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