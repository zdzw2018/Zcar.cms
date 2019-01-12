using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_student_teach
    public partial class student_teach
    {
        public student_teach() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_student_teach");
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
        public int Add(Model.student_teach model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_student_teach(");
            strSql.Append("manager_id,manager_name,stu_id,stu_name,lesson,grade,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@manager_id,@manager_name,@stu_id,@stu_name,@lesson,@grade,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@manager_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@manager_name", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@lesson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.VarChar,1024),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.manager_id;
            parameters[1].Value = model.manager_name;
            parameters[2].Value = model.stu_id;
            parameters[3].Value = model.stu_name;
            parameters[4].Value = model.lesson;
            parameters[5].Value = model.grade;
            parameters[6].Value = model.xiaoqu;

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
            strSql.Append("update tb_student_teach set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.student_teach model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_student_teach set ");

            strSql.Append(" manager_id = @manager_id , ");
            strSql.Append(" manager_name = @manager_name , ");
            strSql.Append(" stu_id = @stu_id , ");
            strSql.Append(" stu_name = @stu_name , ");
            strSql.Append(" lesson = @lesson , ");
            strSql.Append(" grade = @grade,  ");
            strSql.Append(" xiaoqu = @xiaoqu  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@manager_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@manager_name", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@stu_name", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@lesson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.VarChar,1024) ,           
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) 
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.manager_id;
            parameters[2].Value = model.manager_name;
            parameters[3].Value = model.stu_id;
            parameters[4].Value = model.stu_name;
            parameters[5].Value = model.lesson;
            parameters[6].Value = model.grade;
            parameters[7].Value = model.xiaoqu;

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
            strSql.Append("delete from tb_student_teach ");
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
        public Model.student_teach GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, manager_id, manager_name, stu_id, stu_name, lesson, grade,xiaoqu  ");
            strSql.Append("  from tb_student_teach ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.student_teach model = new Model.student_teach();
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
                if (ds.Tables[0].Rows[0]["manager_id"].ToString() != "")
                {
                    model.manager_id = int.Parse(ds.Tables[0].Rows[0]["manager_id"].ToString());
                }
                model.manager_name = ds.Tables[0].Rows[0]["manager_name"].ToString();
                if (ds.Tables[0].Rows[0]["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(ds.Tables[0].Rows[0]["stu_id"].ToString());
                }
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();
                model.lesson = ds.Tables[0].Rows[0]["lesson"].ToString();
                model.grade = ds.Tables[0].Rows[0]["grade"].ToString();

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
            strSql.Append(" FROM tb_student_teach ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(string strWhere, string groupBy)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select manager_id,manager_name ");
            builder.Append(" FROM tb_student_teach ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " group by " + groupBy);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public int GetZeorRenShu(int userid)
        {
            //StringBuilder builder = new StringBuilder();
            //builder.Append("select count(*) from (select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where a.leftlesson=0 and stu_id in(select stu_id from tb_student_teach where  manager_name=(select real_name from dt_manager where id=" + userid + " and stu_id in(select id from tb_student_info))) ");
            //try
            //{
            //    return int.Parse(DbHelperSQL.GetSingle(builder.ToString()).ToString());
            //}
            //catch
            //{
            //    return 0;
            //}
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(distinct stu_id)  FROM tb_student_teach where  stu_id in(select id from tb_student_info) and  stu_id not in(select stu_id from tb_lesson  where datepart(year,lesson_date)=2017 and datepart(month,lesson_date)=10) and manager_id="+userid+" and stu_id in(select  a.stu_id from view_student_contract a  left join (select stu_id, sum(lesson_count) as a2 from tb_lesson group by stu_id   )  b  on a.stu_id=b.stu_id group by b.stu_id,a.stu_id,b.a2,a.audit_stutas  having SUM(a.contract_lesson)-IsNull(a2,0)=0 and a.audit_stutas=1)");
            try
            {
                return int.Parse(DbHelperSQL.GetSingle(builder.ToString()).ToString());
            }
            catch
            {
                return 0;
            }
        }

        public DataSet GetListSelect(string strSelect, string strWhere)
        {
            if (!(strSelect != ""))
            {
                return this.GetList(strWhere);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select " + strSelect);
            builder.Append(" FROM tb_student_teach ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public string GetShengYu(int userid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sum(leftlesson) from (select isnull(m.countlesson,0)-isnull(n.countlesson,0) leftlesson, m.stu_id  from ( select stu_id ,sum(contract_lesson) countlesson from tb_student_contract group by stu_id ) m full join (select stu_id ,sum(lesson_count) countlesson from tb_lesson group by stu_id)n on m.stu_id=n.stu_id )a where stu_id in(select stu_id from tb_student_teach where  manager_name=(select real_name from dt_manager where id=" + userid + ") and stu_id in(select id from tb_student_info)) ");
            try
            {
                return DbHelperSQL.GetSingle(builder.ToString()).ToString();
            }
            catch
            {
                return "0";
            }
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
            strSql.Append(" FROM tb_student_teach ");
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
            strSql.Append("select * FROM tb_student_teach ");
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
