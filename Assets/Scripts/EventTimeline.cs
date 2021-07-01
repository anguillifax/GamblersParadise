using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UObject = UnityEngine.Object;

namespace GameJam
{
	internal class EventTimeline : MonoBehaviour
	{
		public static EventTimeline Instance { get; private set; }


		private void Awake()
		{
			Instance = this;
		}
	}
}