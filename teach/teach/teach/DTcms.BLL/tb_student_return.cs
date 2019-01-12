using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
	 	//tb_student_return
	public partial class student_return
    {
    private readonly DAL.student_return dal=new DAL.student_return();
    public student_return()
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
    public int Add(Model.student_return model)
	{
                return dal.Add(model);
        			
    }

    public int getReturnCountByMonth(string strWhere)
    {
        return dal.getReturnCountByMonth(strWhere);
    }
    /// <summary>
    /// 修改一列数据
    /// </summary>
    public void UpdateField(int id, string strValue)
    {
    	dal.UpdateField(id,strValue);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public bool Update(Model.student_return model)
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
	public Model.student_return GetModel(int id)
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
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strWhere,string filedOrder)
	{
		return dal.GetList(Top,strWhere,filedOrder);
	}
	/// <summary>
	/// 获得查询分页数据
	/// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		return dal.GetList(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
	}
    #endregion  Method
    }
    
}