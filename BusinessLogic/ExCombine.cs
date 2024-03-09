using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public static class ExCombine
	{
		public static Expression<Func<TValue, TResult>> Combine<TValue, TResult>(
					this Expression<Func<TValue, TResult>> left,
					Expression<Func<TValue, TResult>> right,
					Func<Expression, Expression, BinaryExpression> combination)
		{
			// rewrite the body of "right" using "left"'s parameter in place
			// of the original "right"'s parameter
			var newRight = new SwapVisitor(right.Parameters[0], left.Parameters[0])
								.Visit(right.Body);
			// combine via && / || etc and create a new lambda
			return Expression.Lambda<Func<TValue, TResult>>(
				combination(left.Body, newRight), left.Parameters);
		}
		internal class SwapVisitor : ExpressionVisitor
		{
			private readonly Expression from, to;
			public SwapVisitor(Expression from, Expression to)
			{
				this.from = from;
				this.to = to;
			}
			public override Expression Visit(Expression node)
			{
				return node == from ? to : base.Visit(node);
			}
		}
	}
}
