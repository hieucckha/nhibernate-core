﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using NHibernate.Criterion;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH637
{
	using System.Threading.Tasks;

	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		[Test]
		public async Task MultiColumnBetweenAsync()
		{
			PointHolder holder = new PointHolder();
			holder.Point = new Point(20, 10);

			using (ISession s = OpenSession())
			using(ITransaction t = s.BeginTransaction())
			{
				await (s.SaveAsync(holder));

				PointHolder result = (PointHolder) await (s
				                                   	.CreateCriteria(typeof(PointHolder))
				                                   	.Add(Expression.Between("Point", new Point(19, 9), new Point(21, 11)))
				                                   	.UniqueResultAsync());

				Assert.AreSame(holder, result);

				await (s.DeleteAsync(holder));
				await (t.CommitAsync());
			}
		}
	}
}