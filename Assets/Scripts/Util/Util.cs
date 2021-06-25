using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Util {

	#region Vector Tools

	/// <summary>
	/// Sets the x component of a Vector3
	/// </summary>
	public static Vector3 SetX(Vector3 v, float val) {
		v.x = val;
		return v;
	}
	/// <summary>
	/// Sets the x component of a Vector3Int
	/// </summary>
	public static Vector3Int SetX(Vector3Int v, int y) {
		v.x = y;
		return v;
	}


	/// <summary>
	/// Sets the y component of a Vector3
	/// </summary>
	public static Vector3 SetY(Vector3 v, float y) {
		v.y = y;
		return v;
	}
	/// <summary>
	/// Sets the y component of a Vector3Int
	/// </summary>
	public static Vector3Int SetY(Vector3Int v, int y) {
		v.y = y;
		return v;
	}


	/// <summary>
	/// Sets the z component of a Vector3
	/// </summary>
	public static Vector3 SetZ(Vector3 v, float val) {
		v.z = val;
		return v;
	}
	/// <summary>
	/// Sets the z component of a Vector3Int
	/// </summary>
	public static Vector3Int SetZ(Vector3Int v, int y) {
		v.z = y;
		return v;
	}


	/// <summary>
	/// Takes the absolute value of each component
	/// </summary>
	public static Vector2 Abs(Vector2 v) {
		v.x = Mathf.Abs(v.x);
		v.y = Mathf.Abs(v.y);
		return v;
	}
	/// <summary>
	/// Takes the absolute value of each component
	/// </summary>
	public static Vector3 Abs(Vector3 v) {
		v.x = Mathf.Abs(v.x);
		v.y = Mathf.Abs(v.y);
		v.z = Mathf.Abs(v.z);
		return v;
	}

	/// <summary>
	/// Returns the sum of the xyz components
	/// </summary>
	public static float ComponentSum(Vector3 v) {
		return v.x + v.y + v.z;
	}
	/// <summary>
	/// Returns the sum of the xy components
	/// </summary>
	public static float ComponentSum(Vector2 v) {
		return v.x + v.y;
	}
	/// <summary>
	/// Returns the sum of the xyz components
	/// </summary>
	public static int ComponentSum(Vector3Int v) {
		return (int)ComponentSum((Vector3)v);
	}

	/// <summary>
	/// Multiplies the xyz components by a scalar
	/// </summary>
	public static Vector3Int Scale(Vector3Int v, int scalar) {
		v.x *= scalar;
		v.y *= scalar;
		v.z *= scalar;
		return v;
	}

	/// <summary>
	/// Divides the xy component of dividend by xy component of divisor, respectively
	/// </summary>
	public static Vector2 Divide(Vector2 dividend, Vector2 divisor) {
		dividend.x /= divisor.x;
		dividend.y /= divisor.y;
		return dividend;
	}
	/// <summary>
	/// Divides the xyz component of dividend by xyz component of divisor, respectively
	/// </summary>
	public static Vector3 Divide(Vector3 dividend, Vector3 divisor) {
		for (int i = 0; i < 3; i++) {
			dividend[i] /= divisor[i];
		}
		return dividend;
	}


	/// <summary>
	/// If resultant projection is inline with normal, returns projection. Otherwise, returns 0
	/// </summary>
	public static Vector3 GetPositiveProjection(Vector3 vec, Vector3 normal) {
		var projection = Vector3.Project(vec, normal);
		if (!Mathf.Approximately(Vector3.Angle(projection, normal), 0f)) {
			projection = Vector3.zero;
		}
		return projection;
	}

	/// <summary>
	/// If FROM vector component has a non-zero value, then overwrites TO vector component. Otherwise, does nothing
	/// </summary>
	public static Vector3 OverrideNonZero(Vector3 to, Vector3 from) {
		for (int i = 0; i < 3; i++) {
			if (from[i] != 0) {
				to[i] = from[i];
			}
		}
		return to;
	}

	/// <summary>
	/// If FROM vector component is not infinity, then overwrites TO vector component. Otherwise, does nothing
	/// </summary>
	public static Vector3 OverrideNonInf(Vector3 from, Vector3 to) {
		for (int i = 0; i < 3; i++) {
			if (from[i] != Mathf.Infinity) {
				to[i] = from[i];
			}
		}
		return to;
	}

	// public static Vector2 GetDirectionToMouse(Vector2 position) {
	// 	var dir = CamController.mousePos - position;
	// 	if (Mathf.Approximately(dir.sqrMagnitude, 0f)) {
	// 		dir = Vector2.up;
	// 	} else {
	// 		dir.Normalize();
	// 	}
	// 	return dir;
	// }

	#endregion


	#region Math
	
	/// <summary>
	/// Returns the angle rotation relative to Vector2.up
	/// </summary>
	public static float LookRotation(Vector2 dir) {
		return Vector2.SignedAngle(dir, Vector2.up);
	}

	/// <summary>
	/// Continuously multiplies by MULTIPLIER. If CUR is below threshold, CUR is set to 0
	/// </summary>
	public static void ExponentialDecay(ref float cur, float multiplier, float zeroThreshold) {
		if (Mathf.Abs(cur) > zeroThreshold) {
			cur *= multiplier;
		} else {
			cur = 0;
		}
	}
	/// <summary>
	/// Continuously multiplies by MULTIPLIER. If CUR is below threshold, CUR is set to 0
	/// </summary>
	public static void ExponentialDecay(ref Vector2 cur, float multiplier, float zeroThreshold) {
		ExponentialDecay(ref cur.x, multiplier, zeroThreshold);
		ExponentialDecay(ref cur.y, multiplier, zeroThreshold);
	}
	/// <summary>
	/// Continuously multiplies by MULTIPLIER. If CUR is below threshold, CUR is set to 0
	/// </summary>
	public static void ExponentialDecay(ref Vector3 cur, float multiplier, float zeroThreshold) {
		ExponentialDecay(ref cur.x, multiplier, zeroThreshold);
		ExponentialDecay(ref cur.y, multiplier, zeroThreshold);
		ExponentialDecay(ref cur.z, multiplier, zeroThreshold);
	}


	/// <summary>
	/// Returns true if VAL is in (lower, upper) exclusive
	/// </summary>
	public static bool IsBetweenE(double val, double lower, double upper) {
		return val > lower && val < upper;
	}
	/// <summary>
	/// Returns true if VAL is in [lower, upper] inclusive
	/// </summary>
	public static bool IsBetweenI(double val, double lower, double upper) {
		return val >= lower && val <= upper;
	}


	/// <summary>
	/// Takes any angle and clamps it to [0, 360]
	/// </summary>
	public static float ClampAngle0To360(float angle) {
		angle = Mathf.DeltaAngle(0, angle);
		if (angle < 0) angle += 360f;
		return angle;
	}

	/// <summary>
	/// Takes any angle and clamps it to [min, max]
	/// </summary>
	public static float ClampAngle(float angle, float min, float max) {
		var delta = Mathf.DeltaAngle(0, angle);
		if (delta < min) {
			angle = min;
		} else if (delta > max) {
			angle = max;
		}
		return delta;
	}

	/// <summary>
	/// Returns +1.0f if true, -1.0f if false
	/// </summary>
	public static float BoolSign(bool positive) {
		return positive ? 1f : -1f;
	}

	/// <summary>
	/// Works with any number
	/// </summary>
	public static float Round(float val, float round) {
		return round * Mathf.Round(val / round);
	}

	/// <summary>
	/// Remaps a value from range [min1, max1] to a range of [min2, max2]
	/// </summary>
	public static float Remap(float value, float min1, float max1, float min2, float max2) {
		return Mathf.Lerp(min2, max2, Mathf.InverseLerp(min1, max1, value));
	}

	/// <summary>
	/// Returns true if v1 and v2 are less than tolerance apart. Default is 0.01f
	/// </summary>
	public static bool FuzzyEquals(float v1, float v2, float tolerance = 0.01f) {
		return Mathf.Abs(v1 - v2) < tolerance;
	}
	/// <summary>
	/// Returns true if v1 and v2 are less than tolerance apart. Default is 0.01f
	/// </summary>
	public static bool FuzzyEquals(Vector3 v1, Vector3 v2, float tolerance = 0.01f) {
		return FuzzyEquals(v1.x, v2.x, tolerance) && FuzzyEquals(v1.y, v2.y, tolerance) && FuzzyEquals(v1.z, v2.z, tolerance);
	}
	/// <summary>
	/// Returns true if v1 and v2 are less than tolerance apart. Default is 0.01f
	/// </summary>
	public static bool FuzzyEquals(Vector2 v1, Vector2 v2, float tolerance = 0.01f) {
		return FuzzyEquals(v1.x, v2.x, tolerance) && FuzzyEquals(v1.y, v2.y, tolerance);
	}

	#endregion


	#region DirInt

	/// <summary>
	/// Converts dir to an angle in [0, 360]
	/// </summary>
	public static float DirIntToAngle(int dir) {
		return dir * 90f;
	}

	/// <summary>
	/// Converts angle into a dir int
	/// </summary>
	public static int AngleToDirInt(float angle) {
		return Mathf.RoundToInt(ClampAngle0To360(angle) / 90f);
	}

	/// <summary>
	/// Returns true if dir matches a value in values
	/// </summary>
	public static bool DirIntCompare(int dir, params int[] values) {
		foreach (var item in values) {
			if (dir == item) {
				return true;
			}
		}
		return false;
	}

	#endregion


	#region GameObject/Transform

	/// <summary>
	/// Properly destroys all child objects
	/// </summary>
	public static void DestroyChildObjects(Transform parent, bool immediate = false) {
		var tempArray = new GameObject[parent.childCount];

		for (int i = 0; i < tempArray.Length; i++) {
			tempArray[i] = parent.GetChild(i).gameObject;
		}

		foreach (var child in tempArray) {
			if (immediate) {
				Object.DestroyImmediate(child);
			} else {
				Object.Destroy(child);
			}
		}
	}

	/// <summary>
	/// Returns true if test is a child object of parent
	/// </summary>
	public static bool IsChild(Transform parent, Transform test) {
		for (var t = test; t != t.root; t = t.parent) {
			if (t == parent) {
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Returns the closest transform in candidates to specified location. Returns null if empty.
	/// </summary>
	public static Transform GetClosest(Transform[] candidates, Vector3 location) {
		Transform ret = null;
		float closestDistance = Mathf.Infinity;

		foreach (var go in candidates) {
			var directionToTarget = go.position - location;
			float dist = directionToTarget.sqrMagnitude;

			if (dist < closestDistance) {
				closestDistance = dist;
				ret = go;
			}
		}
		return ret;
	}


	#endregion


	#region Misc

	/// <summary>
	/// Adds spaces between words (...what else were you expecting?)
	/// </summary>
	public static string AddSpacesToSentence(string text) {
		if (string.IsNullOrEmpty(text))
			return "";
		StringBuilder newText = new StringBuilder(text.Length * 2);
		newText.Append(text[0]);
		for (int i = 1; i < text.Length; i++) {
			if (char.IsUpper(text[i]) && text[i - 1] != ' ')
				newText.Append(' ');
			newText.Append(text[i]);
		}
		return newText.ToString();
	}

	/// <summary>
	/// Returns a string with format "{item1, item2, etc}"
	/// </summary>
	public static string ArrayToString<T>(T[] array) {
		return "{" + string.Join(", ", array.Select(p => p.ToString()).ToArray()) + "}";
	}

	/// <summary>
	/// Sets the alpha channel of a color
	/// </summary>
	public static Color SetAlpha(Color c, float a) {
		c.a = a;
		return c;
	}

	#endregion


}

public static class UtilExtension {

	/// <summary>
	/// Automatically truncates the z component from transform.position
	/// </summary>
	public static Vector2 AsPos2D(this Transform transform) {
		return transform.position;
	}
	/// <summary>
	/// Automatically truncates the z component from transform.localPosition
	/// </summary>
	public static Vector2 AsLocalPos2D(this Transform transform) {
		return transform.localPosition;
	}


	/// <summary>
	/// Inserts value into the front of the array, moving all previous values to the next index
	/// </summary>
	public static void InsertHead<T>(this T[] target, T value) {
		for (int i = 1; i < target.Length; i++) {
			target[i] = target[i - 1];
		}
		target[0] = value;
	}

}
