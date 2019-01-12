using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Model;
namespace DTcms.BLL
{
	/// <summary>
	/// photo
	/// </summary>
	public partial class photo
	{
        private readonly DAL.photo dal = new DAL.photo();
		public photo()
		{}
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
		public int  Add(Model.photo model)
		{
			return dal.Add(model);
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
		public bool Update(Model.photo model)
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
        /// 删除一条数据
        /// </summary>
         
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.photo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
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
	}
}

