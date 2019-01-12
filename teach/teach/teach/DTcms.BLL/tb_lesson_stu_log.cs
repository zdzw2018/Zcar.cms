using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
    //tb_lesson_stu_log
    public partial class lesson_stu_log
    {
        private readonly DAL.lesson_stu_log dal = new DAL.lesson_stu_log();
        public lesson_stu_log()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.lesson_stu_log model)
        {
            return dal.Add(model);

        }

        public int GetLettonCount(string strWhere)
        {
            return dal.GetLettonCount(strWhere);
        }

        public void Add(List<Model.lesson_stu_log> lis)
        {
            dal.Add(lis);
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.lesson_stu_log model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public void Delete(List<Model.lesson_stu_log> ls, int id)
        {
            dal.Delete(ls, id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.lesson_stu_log GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strSelect, string strWhere)
        {
            return dal.GetList(strSelect, strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strSelect, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strSelect, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strSelect, strWhere, filedOrder, out recordCount);
        }

        public List<Model.lesson_stu_log> GetListbyModel(string strWhere) 
        {
            return dal.GetListbyModel(strWhere);
        }

        public Model.lesson_stu_log GetModel(int stu_id,int lesson_id)
        {
            List<Model.lesson_stu_log> list= GetListbyModel(" stu_id=" + stu_id + " and lesson_id=" + lesson_id);
            if (list.Count > 0)
            {
                return list[0];
            }
            else 
            {
                return null;
            }
        }
        #endregion  Method
    }

}