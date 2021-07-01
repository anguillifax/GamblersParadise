using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace GameJam
{
	public class DebugTools : MonoBehaviour
	{
		public void Print(string msg)
		{
			Debug.Log(msg);
		}
	}
}