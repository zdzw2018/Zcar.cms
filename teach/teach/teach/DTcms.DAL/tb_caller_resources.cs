using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_caller_resources
    public partial class caller_resources
    {
        public caller_resources() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_caller_resources");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.caller_resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_caller_resources(");
            strSql.Append("tel_time,partent_name,stu_name,tel,school,grade,address,learn_ways,remark,channel_id,user_id,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@tel_time,@partent_name,@stu_name,@tel,@school,@grade,@address,@learn_ways,@remark,@channel_id,@user_id,@xiaoqu");
            strSql.Append(") ");

            SqlParameter[] parameters = {       
                        new SqlParameter("@tel_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@partent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@learn_ways", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@user_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4) 
              
            };
            parameters[0].Value = model.tel_time;
            parameters[1].Value = model.partent_name;
            parameters[2].Value = model.stu_name;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.school;
            parameters[5].Value = model.grade;
            parameters[6].Value = model.address;
            parameters[7].Value = model.learn_ways;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.channel_id;
            parameters[10].Value = model.user_id;
            parameters[11].Value = model.xiaoqu;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_caller_resources set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.caller_resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_caller_resources set ");

            strSql.Append(" id = @id , ");
            strSql.Append(" tel_time = @tel_time , ");
            strSql.Append(" partent_name = @partent_name , ");
            strSql.Append(" stu_name = @stu_name , ");
            strSql.Append(" tel = @tel , ");
            strSql.Append(" school = @school , ");
            strSql.Append(" grade = @grade , ");
            strSql.Append(" address = @address , ");
            strSql.Append(" learn_ways = @learn_ways , ");
            strSql.Append(" remark = @remark , ");
            strSql.Append(" channel_id = @channel_id, ");
            strSql.Append(" user_id = @user_id,  ");
            strSql.Append(" xiaoqu = @xiaoqu  ");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@tel_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@partent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@learn_ways", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@user_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.tel_time;
            parameters[2].Value = model.partent_name;
            parameters[3].Value = model.stu_name;
            parameters[4].Value = model.tel;
            parameters[5].Value = model.school;
            parameters[6].Value = model.grade;
            parameters[7].Value = model.address;
            parameters[8].Value = model.learn_ways;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.channel_id;
            parameters[11].Value = model.user_id;
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
            strSql.Append("delete from tb_caller_resources ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
        public Model.caller_resources GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, tel_time, partent_name, stu_name, tel, school, grade, address, learn_ways, remark, channel_id ,user_id,xiaoqu  ");
            strSql.Append("  from tb_caller_resources ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;


            Model.caller_resources model = new Model.caller_resources();
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
                if (ds.Tables[0].Rows[0]["tel_time"].ToString() != "")
                {
                    model.tel_time = DateTime.Parse(ds.Tables[0].Rows[0]["tel_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.partent_name = ds.Tables[0].Rows[0]["partent_name"].ToString();
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.school = ds.Tables[0].Rows[0]["school"].ToString();
                model.grade = ds.Tables[0].Rows[0]["grade"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.learn_ways = ds.Tables[0].Rows[0]["learn_ways"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
            strSql.Append(" FROM tb_caller_resources ");
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
                strSql.Append(" FROM tb_caller_resources ");
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
            strSql.Append(" FROM tb_caller_resources ");
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
                strSql.Append(" FROM tb_caller_resources ");
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
            strSql.Append("select * FROM tb_caller_resources ");
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
                strSql.Append("select " + strSelect + " FROM tb_caller_resources ");
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
