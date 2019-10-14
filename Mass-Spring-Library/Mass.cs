using System;
using System.Numerics;

namespace Mass_Spring_Library
{
	public class Mass
	{
		public Vector3 Position { get; private set; }
		public Vector3 Speed { get; private set; }
		public Vector3 Acceleration { get; private set; }
		public Vector3 Force { get; private set; }

		public bool AxisXLock { get; set; }
		public bool AxisYLock { get; set; }
		public bool AxisZLock { get; set; }

		private readonly float mass;

		public Mass(
			float mass,
			Vector3 force,
			Vector3 acceleration,
			Vector3 speed,
			Vector3 position,
			bool axisXLock = false,
			bool axisYLock = false,
			bool axisZLock = false)
		{
			this.mass = mass;

			Force = force;
			Acceleration = acceleration;
			Speed = speed;
			Position = position;

			AxisXLock = axisXLock;
			AxisYLock = axisYLock;
			AxisZLock = axisZLock;
		}

		public Mass(
			float mass,
			Vector3 position,
			bool axisXLock = false,
			bool axisYLock = false,
			bool axisZLock = false)
		{
			this.mass = mass;

			Force = Vector3.Zero;
			Acceleration = Vector3.Zero;
			Speed = Vector3.Zero;
			Position = position;

			AxisXLock = axisXLock;
			AxisYLock = axisYLock;
			AxisZLock = axisZLock;
		}

		public void Update(Vector3 force, float dt)
		{
			UpdateForce(force);
			UpdateAcceleration();
			UpdateSpeed(dt);
			UpdatePostion(dt);
		}

		public void UpdateForce(Vector3 force)
		{
			Force += force;
		}

		public void UpdateAcceleration()
		{
			Acceleration += Force / mass;
		}

		public void UpdateSpeed(float dt)
		{
			Vector3 tmpSpeed = Speed + (Acceleration * dt);

			if (AxisXLock)
			{
				tmpSpeed.X = 0 ;
			}
			if (AxisYLock)
			{
				tmpSpeed.Y = 0;
			}
			if (AxisZLock)
			{
				tmpSpeed.Z = 0;
			}

			Speed = tmpSpeed;
		}

		public void UpdatePostion(float dt)
		{
			Position += Speed * dt;
		}
	}
}
