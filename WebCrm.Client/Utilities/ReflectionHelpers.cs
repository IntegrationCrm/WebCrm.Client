using System;
using System.Linq.Expressions;

namespace WebCrm.Client.Utilities
{
    internal static class ReflectionHelpers
    {
        public static MemberExpression GetMemberInfo(Expression method)
        {
            var lambda = method as LambdaExpression;
            if (lambda == null)
            {
                throw new ArgumentNullException("method");
            }

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
            {
                throw new ArgumentException("method");
            }

            return memberExpr;
        }

        public static string GetMemberName<TT>(Expression<Func<TT>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }

        public static string GetName(Expression method)
        {
            return GetMemberInfo(method).Member.Name;
        }
    }
}