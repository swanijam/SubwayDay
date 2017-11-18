using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{	
	/// <summary>
	/// A small collection of "Watches" which track the result 
	/// of a polynomial functions with provided coefficients,
	///  whose 'x' is the time elapsed since the Watch was intialized.
	/// 
	/// Each Watch is an object of a class designed for a particular
	/// polynomial function, and must be intialized with a 'TimeCurve_<math function>'
	/// struct.
	/// 
	/// For example, 
	/// The following will move 'Ball' vertically & faster over time, following the 
	/// curve created by ax^b + offset.
	/// {
	///   TimeCurve_Linear BallOffset;
	///   BallOffset.a = 2f;
	///   BallOffset.b = 3f;
	///   BallOffset.offset = .05f;
	/// 
	///   Watch_Exponential BallOffsetWatch = 
	///   new Watch_Exponential(BallOffset, Time.currentTime);
	/// 
	///   void Update() {
	///     Ball.transform.position = 
	///     new Vector3(0, BallOffsetWatch.value, 0);
	/// }
	/// </summary>
	public static class Watches
	{
		
	}
}

