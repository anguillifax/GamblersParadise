using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class VesselHinge : MonoBehaviour
	{
		public AnimationCurve curve;
		public Vector3 multiplier;

		private float timer;

		private void Awake()
		{
			timer = float.NaN;
		}

		public void Animate()
		{
			timer = 0;
		}

		private void Update()
		{
			if (float.IsNaN(timer)) return;

			transform.localRotation = Quaternion.Euler(multiplier * curve.Evaluate(timer));
			timer += Time.deltaTime;
		}
	}
}