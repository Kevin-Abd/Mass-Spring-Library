namespace MassSpringLibrary
{
	using System.Numerics;

	public class Mass
	{
		/// <summary>
		/// Denotes the Postion of the Mass as a <see cref="Vector3"/>
		/// </summary>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Denotes the Speed of the Mass as a <see cref="Vector3"/>
		/// </summary>
		public Vector3 Speed { get; set; }

		/// <summary>
		/// Denotes the Acceleration of the Mass as a <see cref="Vector3"/>
		/// </summary>
		public Vector3 Acceleration { get; set; }

		/// <summary>
		/// Denotes the Force of the Mass as a <see cref="Vector3"/>
		/// </summary>
		public Vector3 Force { get;  set; }

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
			bool axisZLock = false,
			bool highFriction = false)
			: this(
				  mass,
				  Vector3.Zero,
				  Vector3.Zero,
				  Vector3.Zero,
				  position,
				  axisXLock,
				  axisYLock,
				  axisZLock)
		{
		}

		/// <summary>
		/// updates Force, Accelration, Speed and Position
		/// </summary>
		/// <param name="force">force applied to the mass</param>
		/// <param name="dt">Delta Time</param>
		public void UpdateAll(Vector3 force, float dt)
		{
			AddForce(force);
			UpdateAcceleration();
			UpdateSpeed(dt);
			UpdatePostion(dt);
		}


		public void AddForce(Vector3 force)
		{
			Force += force;
		}

		public void UpdateAcceleration(bool resetForce = false)
		{
			Acceleration = Force / mass;
			Force = resetForce ? Vector3.Zero : Force;
		}

		public void UpdateSpeed(float dt, bool HighFriction = false)
		{
			Vector3 tmpSpeed = (Acceleration * dt) + (HighFriction ? Vector3.Zero : Speed);

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
