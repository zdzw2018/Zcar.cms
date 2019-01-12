using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// download
    /// </summary>
    public partial class download
    {
        private readonly DAL.download dal = new DAL.download();
        public download()
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
        public int Add(Model.download model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.download model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int channel_id, int id)
        {
            return dal.Delete(channel_id, id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.download GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method

        #region 扩展方法
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool AttachExists(int id)
        {
            return dal.AttachExists(id);
        }

        /// <summary>
        /// 修改附件一列数据
        /// </summary>
        public void UpdateAttachField(int id, string strValue)
        {
            dal.UpdateAttachField(id, strValue);
        }

        /// <summary>
        /// 得到一个附件对象实体
        /// </summary>
        public Model.download_attach GetAttachModel(int id)
        {
            return dal.GetAttachModel(id);
        }
        #endregion

    }
}