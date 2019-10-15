namespace MassSpringLibrary
{
	using System.Numerics;

	public class Spring
	{
		/// <summary>
		/// Denotes the curent Lenght of the spring
		/// </summary>
		public float Length { get => Vector3.Distance(mass1.Position, mass2.Position); }

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

		/// <summary>
		/// Normlized Vector from Mass2 to Mass1
		/// </summary>
		public Vector3 Mass1ForceVector { get => Vector3.Normalize(mass1.Position - mass2.Position); }

		/// <summary>
		/// Normlized Vector from Mass1 to Mass2
		/// </summary>
		public Vector3 Mass2ForceVector { get => Vector3.Normalize(mass2.Position - mass1.Position); }

		internal readonly Mass mass1;
		internal readonly Mass mass2;

		public Spring(Mass mass1, Mass mass2, float constant, float lengthModifier = 1)
		{
			this.mass1 = mass1;
			this.mass2 = mass2;
			this.Constant = constant;
			L0 = lengthModifier * Length;
		}

	}
}
