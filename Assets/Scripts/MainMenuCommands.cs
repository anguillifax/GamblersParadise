using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamblersParadise
{
	internal class MainMenuCommands : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				SceneManager.LoadScene("Dialogue");
			}
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}