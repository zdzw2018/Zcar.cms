using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_visitors_resources
    public partial class visitors_resources
    {
        public visitors_resources() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_visitors_resources");
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
        public int Add(Model.visitors_resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_visitors_resources(");
            strSql.Append("date_visit,partent_name,stu_name,tel,school,grade,address,visiting_nature,signed,channel_id,user_id,zixun_content,genjin_content,xiaoqu");
            strSql.Append(") values (");
            strSql.Append("@date_visit,@partent_name,@stu_name,@tel,@school,@grade,@address,@visiting_nature,@signed,@channel_id,@user_id,@zixun_content,@genjin_content,@xiaoqu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@date_visit", SqlDbType.DateTime) ,            
                        new SqlParameter("@partent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visiting_nature", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@signed", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@user_id", SqlDbType.Int,4),
                        new SqlParameter("zixun_content",SqlDbType.NVarChar,255),
                        new SqlParameter("@genjin_content",SqlDbType.NVarChar,255),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.date_visit;
            parameters[1].Value = model.partent_name;
            parameters[2].Value = model.stu_name;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.school;
            parameters[5].Value = model.grade;
            parameters[6].Value = model.address;
            parameters[7].Value = model.visiting_nature;
            parameters[8].Value = model.signed;
            parameters[9].Value = model.channel_id;
            parameters[10].Value = model.user_id;
            parameters[11].Value = model.zixun_content;
            parameters[12].Value = model.genjin_content;
            parameters[13].Value = model.xiaoqu;

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
            strSql.Append("update tb_visitors_resources set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.visitors_resources model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_visitors_resources set ");

            strSql.Append(" date_visit = @date_visit , ");
            strSql.Append(" partent_name = @partent_name , ");
            strSql.Append(" stu_name = @stu_name , ");
            strSql.Append(" tel = @tel , ");
            strSql.Append(" school = @school , ");
            strSql.Append(" grade = @grade , ");
            strSql.Append(" address = @address , ");
            strSql.Append(" visiting_nature = @visiting_nature , ");
            strSql.Append(" signed = @signed , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" zixun_content=@zixun_content, ");
            strSql.Append(" genjin_content=@genjin_content, ");
            strSql.Append(" xiaoqu=@xiaoqu ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@date_visit", SqlDbType.DateTime) ,            
                        new SqlParameter("@partent_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@stu_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@school", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@grade", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@visiting_nature", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@signed", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4),
                        new SqlParameter("@user_id", SqlDbType.Int,4),
                        new SqlParameter("zixun_content",SqlDbType.NVarChar,255),
                        new SqlParameter("@genjin_content",SqlDbType.NVarChar,255),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.date_visit;
            parameters[2].Value = model.partent_name;
            parameters[3].Value = model.stu_name;
            parameters[4].Value = model.tel;
            parameters[5].Value = model.school;
            parameters[6].Value = model.grade;
            parameters[7].Value = model.address;
            parameters[8].Value = model.visiting_nature;
            parameters[9].Value = model.signed;
            parameters[10].Value = model.channel_id;
            parameters[11].Value = model.user_id;
            parameters[12].Value = model.zixun_content;
            parameters[13].Value = model.genjin_content;
            parameters[14].Value = model.xiaoqu;
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
            strSql.Append("delete from tb_visitors_resources ");
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
        public Model.visitors_resources GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, date_visit, partent_name, stu_name, tel, school, grade, address, visiting_nature, signed, channel_id ,user_id, genjin_content,zixun_content,xiaoqu ");
            strSql.Append("  from tb_visitors_resources ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.visitors_resources model = new Model.visitors_resources();
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
                if (ds.Tables[0].Rows[0]["date_visit"].ToString() != "")
                {
                    model.date_visit = DateTime.Parse(ds.Tables[0].Rows[0]["date_visit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                model.partent_name = ds.Tables[0].Rows[0]["partent_name"].ToString();
                model.stu_name = ds.Tables[0].Rows[0]["stu_name"].ToString();
                model.genjin_content = ds.Tables[0].Rows[0]["genjin_content"].ToString();
                model.zixun_content = ds.Tables[0].Rows[0]["zixun_content"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.school = ds.Tables[0].Rows[0]["school"].ToString();
                model.grade = ds.Tables[0].Rows[0]["grade"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.visiting_nature = ds.Tables[0].Rows[0]["visiting_nature"].ToString();
                model.signed = ds.Tables[0].Rows[0]["signed"].ToString();
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
            strSql.Append(" FROM tb_visitors_resources ");
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
                strSql.Append(" FROM tb_visitors_resources ");
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
            strSql.Append(" FROM tb_visitors_resources ");
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
                strSql.Append(" FROM tb_visitors_resources ");
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
            strSql.Append("select * FROM tb_visitors_resources ");
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
                strSql.Append("select " + strSelect + " FROM tb_visitors_resources ");
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
