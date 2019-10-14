namespace UnitTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Mass_Spring_Library;
	using System;
	using System.Numerics;

	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestContraction()
		{
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0));
			v2 = new Mass(1, new Vector3(1, 1, 1), true, true, true);
			Spring spring = new Spring(v1, v2, 100, 0.5f);

			Console.WriteLine("Pos v1:"+v1.Position);
			Console.WriteLine("Pos v2:"+v2.Position);
			Console.WriteLine("Acce v2:"+v2.Acceleration);
			Console.WriteLine("Speed v2:"+v2.Speed);
			Console.WriteLine("Force v2:"+v2.Force);
			Console.WriteLine("v1_v2:" + spring.v1_v2);

			v1.Update(spring.v1_v2*spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X > 0);
			Assert.IsTrue(v1.Position.Y > 0);
			Assert.IsTrue(v1.Position.Z > 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}

		[TestMethod]
		public void TestExpantion()
		{
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0));
			v2 = new Mass(1, new Vector3(1, 1, 1), true, true, true);
			Spring spring = new Spring(v1, v2, 100, 1.5f);

			Console.WriteLine("Pos v1:" + v1.Position);
			Console.WriteLine("Pos v2:" + v2.Position);
			Console.WriteLine("Acce v2:" + v2.Acceleration);
			Console.WriteLine("Speed v2:" + v2.Speed);
			Console.WriteLine("Force v2:" + v2.Force);
			Console.WriteLine("v1_v2:" + spring.v1_v2);

			v1.Update(spring.v1_v2 * spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X < 0);
			Assert.IsTrue(v1.Position.Y < 0);
			Assert.IsTrue(v1.Position.Z < 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}
	}
}
