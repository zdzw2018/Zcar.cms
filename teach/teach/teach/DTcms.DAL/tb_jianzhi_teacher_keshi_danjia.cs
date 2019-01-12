using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;


namespace DTcms.DAL
{
    public partial class tb_jianzhi_teacher_keshi_danjia
    {
        public tb_jianzhi_teacher_keshi_danjia() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_jianzhi_teacher_keshi_danjia");
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
        public int Add(Model.tb_jianzhi_teacher_keshi_danjia model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_jianzhi_teacher_keshi_danjia(");
            strSql.Append("teacher_id,grade,add_time,keshi_danjia,xiaoqu,teacher_name");
            strSql.Append(") values (");
            strSql.Append("@teacher_id,@grade,@add_time,@keshi_danjia,@xiaoqu,@teacher_name");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@teacher_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@keshi_danjia", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) ,            
                        new SqlParameter("@teacher_name", SqlDbType.NVarChar,50)         
            };

            parameters[0].Value = model.teacher_id;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.add_time;
            parameters[3].Value = model.keshi_danjia;
            parameters[4].Value = model.xiaoqu;
            parameters[5].Value = model.teacher_name;

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
            strSql.Append("update tb_jianzhi_teacher_keshi_danjia set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.tb_jianzhi_teacher_keshi_danjia model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_jianzhi_teacher_keshi_danjia set ");

            strSql.Append(" teacher_id = @teacher_id , ");
            strSql.Append(" grade = @grade , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" keshi_danjia = @keshi_danjia , ");
            strSql.Append(" xiaoqu = @xiaoqu , ");
            strSql.Append(" teacher_name = @teacher_name  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			                 
                        new SqlParameter("@teacher_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@keshi_danjia", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) ,            
                        new SqlParameter("@teacher_name", SqlDbType.NVarChar,50),
                        new SqlParameter("@id", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.teacher_id;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.add_time;
            parameters[3].Value = model.keshi_danjia;
            parameters[4].Value = model.xiaoqu;
            parameters[5].Value = model.teacher_name;
            parameters[6].Value = model.id;
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
            strSql.Append("delete from tb_jianzhi_teacher_keshi_danjia ");
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
        public Model.tb_jianzhi_teacher_keshi_danjia GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,teacher_id,grade,add_time,keshi_danjia,xiaoqu,teacher_name   ");
            strSql.Append("  from tb_jianzhi_teacher_keshi_danjia ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.tb_jianzhi_teacher_keshi_danjia model = new Model.tb_jianzhi_teacher_keshi_danjia();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["teacher_id"].ToString() != "")
                {
                    model.teacher_id = int.Parse(ds.Tables[0].Rows[0]["teacher_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["grade"].ToString() != "")
                {
                    model.grade = ds.Tables[0].Rows[0]["grade"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["keshi_danjia"].ToString() != "")
                {
                    model.keshi_danjia = decimal.Parse(ds.Tables[0].Rows[0]["keshi_danjia"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["teacher_name"].ToString() != "")
                {
                    model.teacher_name = ds.Tables[0].Rows[0]["teacher_name"].ToString();
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
            strSql.Append(" FROM tb_jianzhi_teacher_keshi_danjia ");
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
                strSql.Append(" FROM tb_jianzhi_teacher_keshi_danjia ");
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
            strSql.Append(" FROM tb_jianzhi_teacher_keshi_danjia ");
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
                strSql.Append(" FROM tb_jianzhi_teacher_keshi_danjia ");
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
            strSql.Append("select * FROM tb_jianzhi_teacher_keshi_danjia ");
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
                strSql.Append("select " + strSelect + " FROM tb_jianzhi_teacher_keshi_danjia ");
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
