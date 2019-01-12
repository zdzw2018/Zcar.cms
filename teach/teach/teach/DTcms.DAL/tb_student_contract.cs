using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //tb_student_contract
    public partial class student_contract
    {
        public student_contract() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_student_contract");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        
            /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Existsbystu_id(int stu_id, out int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from tb_student_contract");
            strSql.Append(" where ");
            strSql.Append(" stu_id =  " + stu_id);

            int result= Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            if (result > 0)
            {
                id = result;
                return true;
            }
            else 
            {
                id = 0;
                return false;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.student_contract model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_student_contract(");
            strSql.Append("user_id,add_time,channel_id,contract_status,status,contract_no,contract_lesson,contract_lesson_price,contract_service_price,contract_advice_price,contract_advice_price_surplus,contract_remark,stu_id,xiaoqu,give_lesson,one_several,keshi_multiple");
            strSql.Append(") values (");
            strSql.Append("@user_id,@add_time,@channel_id,@contract_status,@status,@contract_no,@contract_lesson,@contract_lesson_price,@contract_service_price,@contract_advice_price,@contract_advice_price_surplus,@contract_remark,@stu_id,@xiaoqu,@give_lesson,@one_several,@keshi_multiple");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@contract_status", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@status", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_lesson", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_lesson_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_service_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_advice_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_advice_price_surplus", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_remark", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4),
                        new SqlParameter("@give_lesson", SqlDbType.Decimal,9),
                        new SqlParameter("@one_several", SqlDbType.Int,4),
                        new SqlParameter("@keshi_multiple", SqlDbType.Decimal,9) 
              
            };

            parameters[0].Value = model.user_id;
            parameters[1].Value = model.add_time;
            parameters[2].Value = model.channel_id;
            parameters[3].Value = model.contract_status;
            parameters[4].Value = model.status;
            parameters[5].Value = model.contract_no;
            parameters[6].Value = model.contract_lesson;
            parameters[7].Value = model.contract_lesson_price;
            parameters[8].Value = model.contract_service_price;
            parameters[9].Value = model.contract_advice_price;
            parameters[10].Value = model.contract_advice_price_surplus;
            parameters[11].Value = model.contract_remark;
            parameters[12].Value = model.stu_id;
            parameters[13].Value = model.xiaoqu;
            parameters[14].Value = model.give_lesson;
            parameters[15].Value = model.one_several;
            parameters[16].Value = model.keshi_multiple;

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
            strSql.Append("update tb_student_contract set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.student_contract model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_student_contract set ");
            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" channel_id = @channel_id , ");
            strSql.Append(" contract_status = @contract_status , ");
            strSql.Append(" status = @status , ");
            strSql.Append(" contract_no = @contract_no , ");
            strSql.Append(" contract_lesson = @contract_lesson , ");
            strSql.Append(" contract_lesson_price = @contract_lesson_price , ");
            strSql.Append(" contract_service_price = @contract_service_price , ");
            strSql.Append(" contract_advice_price = @contract_advice_price , ");
            strSql.Append(" contract_advice_price_surplus = @contract_advice_price_surplus , ");
            strSql.Append(" contract_remark = @contract_remark , ");
            strSql.Append(" stu_id = @stu_id,  ");
            strSql.Append(" xiaoqu = @xiaoqu , ");
            strSql.Append(" give_lesson = @give_lesson,  ");
            strSql.Append(" one_several = @one_several,  ");
            strSql.Append(" keshi_multiple = @keshi_multiple  ");

            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@contract_status", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@status", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@contract_lesson", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_lesson_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_service_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_advice_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_advice_price_surplus", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@contract_remark", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@stu_id", SqlDbType.Int,4),
                        new SqlParameter("@xiaoqu", SqlDbType.Int,4),
                        new SqlParameter("@give_lesson", SqlDbType.Decimal,9),
                        new SqlParameter("@one_several", SqlDbType.Int,4),
                        new SqlParameter("@keshi_multiple", SqlDbType.Decimal,9) 
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.user_id;
            parameters[2].Value = model.add_time;
            parameters[3].Value = model.channel_id;
            parameters[4].Value = model.contract_status;
            parameters[5].Value = model.status;
            parameters[6].Value = model.contract_no;
            parameters[7].Value = model.contract_lesson;
            parameters[8].Value = model.contract_lesson_price;
            parameters[9].Value = model.contract_service_price;
            parameters[10].Value = model.contract_advice_price;
            parameters[11].Value = model.contract_advice_price_surplus;
            parameters[12].Value = model.contract_remark;
            parameters[13].Value = model.stu_id;
            parameters[14].Value = model.xiaoqu;
            parameters[15].Value = model.give_lesson;
            parameters[16].Value = model.one_several;
            parameters[17].Value = model.keshi_multiple;

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
            strSql.Append("delete from tb_student_contract ");
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
        public Model.student_contract GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, user_id, add_time, channel_id, contract_status, status, audit_stutas, audit_user_id, audit_date, audit_user_name, audit_remrak, contract_no, contract_lesson, contract_lesson_price, contract_service_price, contract_advice_price, contract_advice_price_surplus, contract_remark, stu_id,xiaoqu,give_lesson,one_several,keshi_multiple  ");
            strSql.Append("  from tb_student_contract ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.student_contract model = new Model.student_contract();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["one_several"].ToString() != "")
                {
                    model.one_several = int.Parse(ds.Tables[0].Rows[0]["one_several"].ToString());
                }
                if (ds.Tables[0].Rows[0]["keshi_multiple"].ToString() != "")
                {
                    model.keshi_multiple = decimal.Parse(ds.Tables[0].Rows[0]["keshi_multiple"].ToString());
                }
                if (ds.Tables[0].Rows[0]["xiaoqu"].ToString() != "")
                {
                    model.xiaoqu = int.Parse(ds.Tables[0].Rows[0]["xiaoqu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                model.contract_status = ds.Tables[0].Rows[0]["contract_status"].ToString();
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                if (ds.Tables[0].Rows[0]["audit_stutas"].ToString() != "")
                {
                    model.audit_stutas = int.Parse(ds.Tables[0].Rows[0]["audit_stutas"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit_user_id"].ToString() != "")
                {
                    model.audit_user_id = int.Parse(ds.Tables[0].Rows[0]["audit_user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit_date"].ToString() != "")
                {
                    model.audit_date = DateTime.Parse(ds.Tables[0].Rows[0]["audit_date"].ToString());
                }
                model.audit_user_name = ds.Tables[0].Rows[0]["audit_user_name"].ToString();
                model.audit_remrak = ds.Tables[0].Rows[0]["audit_remrak"].ToString();
                model.contract_no = ds.Tables[0].Rows[0]["contract_no"].ToString();
                if (ds.Tables[0].Rows[0]["contract_lesson"].ToString() != "")
                {
                    model.contract_lesson = decimal.Parse(ds.Tables[0].Rows[0]["contract_lesson"].ToString());
                }
                if (ds.Tables[0].Rows[0]["contract_lesson_price"].ToString() != "")
                {
                    model.contract_lesson_price = decimal.Parse(ds.Tables[0].Rows[0]["contract_lesson_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["contract_service_price"].ToString() != "")
                {
                    model.contract_service_price = decimal.Parse(ds.Tables[0].Rows[0]["contract_service_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["give_lesson"].ToString() != "")
                {
                    model.give_lesson = decimal.Parse(ds.Tables[0].Rows[0]["give_lesson"].ToString());
                }
                if (ds.Tables[0].Rows[0]["contract_advice_price"].ToString() != "")
                {
                    model.contract_advice_price = decimal.Parse(ds.Tables[0].Rows[0]["contract_advice_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["contract_advice_price_surplus"].ToString() != "")
                {
                    model.contract_advice_price_surplus = decimal.Parse(ds.Tables[0].Rows[0]["contract_advice_price_surplus"].ToString());
                }
                model.contract_remark = ds.Tables[0].Rows[0]["contract_remark"].ToString();
                if (ds.Tables[0].Rows[0]["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(ds.Tables[0].Rows[0]["stu_id"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.student_contract GetModelByStu(int stu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from tb_student_contract");
            strSql.Append(" where stu_id=@stu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.Int,4)};
            parameters[0].Value = stu_id;

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
            strSql.Append(" FROM view_student_contract ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal getLessonCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(contract_lesson) ");
            strSql.Append(" FROM view_student_contract ");
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

        public decimal getGiveLessonCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(give_lesson) ");
            strSql.Append(" FROM view_student_contract ");
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strSelect, string strWhere)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect);
                strSql.Append(" FROM view_student_contract ");
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
            strSql.Append(" FROM view_student_contract ");
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
                strSql.Append(" FROM view_student_contract ");
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
            strSql.Append("select * FROM view_student_contract ");
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount,string groupBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [user_id], datepart(year,add_time) as year,  datepart(month,add_time) as  month ,sum(contract_service_price+contract_advice_price) as newmoney,sum(contract_service_price+contract_advice_price-contract_advice_price_surplus) as realmoney,count(contract_no) as hetong FROM tb_student_contract ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where stu_id in(select id from tb_student_info) and " + strWhere);
            }
            if (groupBy.Trim() != "")
            {
                strSql.Append(" group by " + groupBy);
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
                strSql.Append("select " + strSelect + " FROM view_student_contract ");
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
