using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
	 	//tb_student_contract
	public partial class student_contract
    {
    private readonly DAL.student_contract dal=new DAL.student_contract();
    public student_contract()
	{}
    #region  Method
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int id)
    {
            return dal.Exists(id);
    }
    public bool Existsbystu_id(int stu_id,out int id)
    {
        return dal.Existsbystu_id(stu_id,out id);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add(Model.student_contract model)
	{
                return dal.Add(model);
        			
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
    public bool Update(Model.student_contract model)
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
	public Model.student_contract GetModel(int id)
	{
    	return dal.GetModel(id);
	}
    public Model.student_contract GetModelByStu(int stu_id) {
        return dal.GetModelByStu(stu_id);
    }
	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strWhere)
	{
		return dal.GetList(strWhere);
	}

    public decimal getLessonCount(string strWhere)
    {
        return dal.getLessonCount(strWhere);
    }

    public decimal getGiveLessonCount(string strWhere)
    {
        return dal.getGiveLessonCount(strWhere);
    }
	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strSelect,string strWhere)
	{
		return dal.GetList(strSelect,strWhere);
	}
	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strWhere,string filedOrder)
	{
		return dal.GetList(Top,strWhere,filedOrder);
	}
	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strSelect,string strWhere,string filedOrder)
	{
		return dal.GetList(Top,strSelect,strWhere,filedOrder);
	}
	/// <summary>
	/// 获得查询分页数据
	/// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		return dal.GetList(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
	}

    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount,string groupBy)
    {
        return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount, groupBy);
    }
	/// <summary>
	/// 获得查询分页数据
	/// </summary>
    public DataSet GetList(int pageSize, int pageIndex,string strSelect, string strWhere, string filedOrder, out int recordCount)
	{
		return dal.GetList(pageSize,pageIndex,strSelect,strWhere,filedOrder,out recordCount);
	}
    #endregion  Method
    }
    
}