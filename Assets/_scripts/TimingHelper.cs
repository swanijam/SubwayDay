using UnityEngine;
using System.Collections;

/// <summary>
/// ax + b
/// </summary>
[System.Serializable]
public struct TimeCurve_Linear {
	public float a;
	public float offset;

	public TimeCurve_Linear(float _a, float _offset) {
		a = _a;
		offset = _offset;
	}
}

/// <summary>
/// ab^x + offset
/// </summary>
public struct TimeCurve_Exponential {
	public float a; 
	public float b;
	public float offset;
}

/// <summary>
///  ax^2 + bx + c
/// </summary>
public struct TimeCurve_Quadratic {
	public float a;
	public float b;
	public float offset;
}

/// <summary>
///  a sin (b x + c)
/// </summary>
public struct TimeCurve_Sinusoidal {
	public float a;
	public float b;
	public float c;
}
public class TimingHelper : MonoBehaviour {
	Watch_Linear wl;
	void Start() {
		TimeCurve_Linear tl;
		tl.a = .5f;
		tl.offset = 0f;
		wl = new Watch_Linear (tl);
	}

	void Update() {
//		Debug.Log(wl.GetValue ());
	}
}

public class Watch_Linear {
	private TimeCurve_Linear coefficients;
	private float start_time;

	public float GetValue() {
		return this.coefficients.a * (Time.time - start_time) + this.coefficients.offset;
	}

	public Watch_Linear(TimeCurve_Linear t) {
		coefficients = t;
		start_time = Time.time;
	}
}
