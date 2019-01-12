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
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Model.photo model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.photo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int channel_id, int id)
		{
            return dal.Delete(channel_id, id);
		}
        /// <summary>
        /// ɾ��һ������
        /// </summary>
         
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.photo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
            return dal.GetList(Top, strWhere, filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

		#endregion  Method
	}
}

