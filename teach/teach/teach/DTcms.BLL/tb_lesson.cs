using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
    //tb_lesson
    public partial class lesson
    {
        private readonly DAL.lesson dal = new DAL.lesson();
        public lesson()
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
        public int Add(Model.lesson model)
        {
            return dal.Add(model);

        }
        public DataSet GetList(string strWhere, string groupBy, bool isOk)
        {
            return dal.GetList(strWhere, groupBy, isOk);
        }

        public void UpdateWhere(string where, string strValue)
        {
            dal.UpdateWhere(where, strValue);
        }

        public decimal GetLettonCount(string strWhere)
        {
            return dal.GetLettonCount(strWhere);
        }

        public DataSet GetListGroupBy(string strWhere, string groupBy)
        {
            return dal.GetListGroupBy(strWhere, groupBy);
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
        public bool Update(Model.lesson model)
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.lesson GetModel(int id)
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
        public DataSet GetWagesList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetWagesList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        public DataSet GetListAll(int Top, string strWhere, string filedOrder)
        {
            return dal.GetListAll(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strSelect, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }

}