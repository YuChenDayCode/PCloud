using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Myn.Data.ORM
{
    public interface IDbProvider<T>
    {
        T Get();
        /// <summary>
        /// 查询单条符合条件的数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns>数据</returns>
        T Get(Expression<Func<T, object>> exp);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否成功</returns>
        bool Insert(T entity);

        /// <summary>
        /// 插入数据并返回主键
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="Id">主键</param>
        void Insert_Return_Id(T entity, out int Id);

    }
}
