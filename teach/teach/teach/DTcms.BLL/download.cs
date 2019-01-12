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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.download model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.download model)
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
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.download GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ���ǰ��������
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

        #region ��չ����
        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool AttachExists(int id)
        {
            return dal.AttachExists(id);
        }

        /// <summary>
        /// �޸ĸ���һ������
        /// </summary>
        public void UpdateAttachField(int id, string strValue)
        {
            dal.UpdateAttachField(id, strValue);
        }

        /// <summary>
        /// �õ�һ����������ʵ��
        /// </summary>
        public Model.download_attach GetAttachModel(int id)
        {
            return dal.GetAttachModel(id);
        }
        #endregion

    }
}