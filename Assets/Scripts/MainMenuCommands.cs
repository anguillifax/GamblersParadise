using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameJam
{
	internal class MainMenuCommands : MonoBehaviour
	{
		public UnityEvent onClickPlay;
		public float waitTime = 3;

		private float timeCreated;

		private void Awake()
		{
			timeCreated = Time.unscaledTime;
		}

		private void Update()
		{
			if (Input.GetMouseButtonUp(0) && Time.unscaledTime > timeCreated + waitTime)
			{
				onClickPlay.Invoke();
			}
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}