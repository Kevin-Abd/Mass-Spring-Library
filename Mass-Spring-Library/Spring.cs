using System.Numerics;

namespace Mass_Spring_Library
{
	public class Spring
	{
		/// <summary>
		/// Denotes the cuurent Lenght of the spring
		/// </summary>
		public float Length { get => Vector3.Distance(v1.Position, v2.Position); }

		/// <summary>
		/// Denotes the natrual length of the spring
		/// </summary>
		public float L0 { get; }

		/// <summary>
		/// Spring constant
		/// </summary>
		public float Constant { get; }

		/// <summary>
		/// Denotes the force with which the spring is expanding
		/// </summary>
		public float Force { get => -1 * Constant * (Length - L0); }

		// todo fix naming
		public Vector3 v1_v2 { get => Vector3.Normalize(v1.Position - v2.Position); }
		public Vector3 v2_v1 { get => Vector3.Normalize(v2.Position - v1.Position); }

		private readonly Mass v1;
		private readonly Mass v2;

		public Spring(Mass v1, Mass v2, float constant, float lengthModifier = 1)
		{
			this.v1 = v1;
			this.v2 = v2;
			this.Constant = constant;
			L0 = lengthModifier * Length;
		}

	}
}
