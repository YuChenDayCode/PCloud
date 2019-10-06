using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Myn.Reflection
{
    public static class ReflectionExtension
    {
        public static PropertyInfo GetProperty(LambdaExpression lambda)
        {
            Expression expr = lambda;
            for (; ; )
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.Lambda:
                        expr = ((LambdaExpression)expr).Body;
                        break;
                    case ExpressionType.Convert:
                        expr = ((UnaryExpression)expr).Operand;
                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)expr;
                        MemberInfo mi = memberExpression.Member;
                        return mi as PropertyInfo;
                    default:
                        return null;
                }
            }
        }
    }
}
