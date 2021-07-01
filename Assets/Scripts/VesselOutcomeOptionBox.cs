using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class VesselOutcomeOptionBox : MonoBehaviour
	{
		public void Select()
		{
			Debug.Log(gameObject.name);
		}

		public void Remove()
		{
			Destroy(gameObject);
		}
	}
}