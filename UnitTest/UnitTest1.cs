namespace UnitTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using MassSpringLibrary;
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
			Console.WriteLine("v1_v2:" + spring.Mass1ForceVector);

			v1.UpdateAll(spring.Mass1ForceVector*spring.Force, 0.1f);

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
			Console.WriteLine("v1_v2:" + spring.Mass1ForceVector);

			v1.UpdateAll(spring.Mass1ForceVector * spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X < 0);
			Assert.IsTrue(v1.Position.Y < 0);
			Assert.IsTrue(v1.Position.Z < 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}

		[TestMethod]
		public void TestLockX()
		{
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0), false, true, true);
			v2 = new Mass(1, new Vector3(1, 1, 1), true, true, true);
			Spring spring = new Spring(v1, v2, 100, 0.5f);

			Console.WriteLine("Pos v1:" + v1.Position);
			Console.WriteLine("Pos v2:" + v2.Position);
			Console.WriteLine("Acce v2:" + v2.Acceleration);
			Console.WriteLine("Speed v2:" + v2.Speed);
			Console.WriteLine("Force v2:" + v2.Force);
			Console.WriteLine("v1_v2:" + spring.Mass1ForceVector);

			v1.UpdateAll(spring.Mass1ForceVector * spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X > 0);
			Assert.IsTrue(v1.Position.Y == 0);
			Assert.IsTrue(v1.Position.Z == 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}

		[TestMethod]
		public void TestLockY()
		{
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0), true, false, true);
			v2 = new Mass(1, new Vector3(1, 1, 1), true, true, true);
			Spring spring = new Spring(v1, v2, 100, 0.5f);

			Console.WriteLine("Pos v1:" + v1.Position);
			Console.WriteLine("Pos v2:" + v2.Position);
			Console.WriteLine("Acce v2:" + v2.Acceleration);
			Console.WriteLine("Speed v2:" + v2.Speed);
			Console.WriteLine("Force v2:" + v2.Force);
			Console.WriteLine("v1_v2:" + spring.Mass1ForceVector);

			v1.UpdateAll(spring.Mass1ForceVector * spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X == 0);
			Assert.IsTrue(v1.Position.Y > 0);
			Assert.IsTrue(v1.Position.Z == 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}

		[TestMethod]
		public void TestLockZ()
		{
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0), true, true, false);
			v2 = new Mass(1, new Vector3(1, 1, 1), true, true, true);
			Spring spring = new Spring(v1, v2, 100, 0.5f);

			Console.WriteLine("Pos v1:" + v1.Position);
			Console.WriteLine("Pos v2:" + v2.Position);
			Console.WriteLine("Acce v2:" + v2.Acceleration);
			Console.WriteLine("Speed v2:" + v2.Speed);
			Console.WriteLine("Force v2:" + v2.Force);
			Console.WriteLine("v1_v2:" + spring.Mass1ForceVector);

			v1.UpdateAll(spring.Mass1ForceVector * spring.Force, 0.1f);

			Assert.IsTrue(v1.Position.X == 0);
			Assert.IsTrue(v1.Position.Y == 0);
			Assert.IsTrue(v1.Position.Z > 0);

			Assert.IsTrue(v2.Position.X == 1);
			Assert.IsTrue(v2.Position.Y == 1);
			Assert.IsTrue(v2.Position.Z == 1);
		}

		[TestMethod]
		public void TestForce()
		{
			float constant = 100;
			float lenMod = 0.1f;
			Mass v1, v2;
			v1 = new Mass(1, new Vector3(0, 0, 0), false, false, false);
			v2 = new Mass(1, new Vector3(2, 0, 0), false, false, false);
			Spring spring = new Spring(v1, v2, constant, lenMod);

			spring.AddForcesToMasses();

			Assert.AreEqual(constant * (1 - lenMod) * 2, v1.Force.X, 0.001f);
			Assert.AreEqual(-1 * constant * (1 - lenMod) * 2, v2.Force.X, 0.001f);

			Console.WriteLine("Pos v1:" + v1.Position);
			Console.WriteLine("Pos v2:" + v2.Position);
			Console.WriteLine("Acce v1:" + v1.Acceleration);
			Console.WriteLine("Acce v2:" + v2.Acceleration);
			Console.WriteLine("Speed v1:" + v1.Speed);
			Console.WriteLine("Speed v2:" + v2.Speed);
			Console.WriteLine("Force v1:" + v1.Force);
			Console.WriteLine("Force v2:" + v2.Force);
			Console.WriteLine("Mass1FV:" + spring.Mass1ForceVector);
			Console.WriteLine("Mass2FV:" + spring.Mass2ForceVector);
		}
	}
}
