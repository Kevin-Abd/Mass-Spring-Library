namespace MassSpringLibrary
{
	using System.Numerics;

	public static class Helper
	{
		/// <summary>
		/// updates the Forces of <see cref="Mass"/>es attached to this spring with the given dt.
		/// Uses <see cref="Mass.AddForce(Vector3)"/>.
		/// </summary>
		/// <param name="spring">the spring</param>
		public static void AddForcesToMasses(this Spring spring)
		{
			if ( spring == null)
			{
				throw new System.NullReferenceException();
			}

			Vector3 v1v2 = spring.Mass1ForceVector;
			Vector3 v2v1 = spring.Mass2ForceVector;
			float force = spring.Force;

			spring.mass1.AddForce(v1v2 * force);
			spring.mass2.AddForce(v2v1 * force);
		}

	}
}
