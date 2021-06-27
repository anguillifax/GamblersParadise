using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamblersParadise
{
	internal class MainMenuCommands : MonoBehaviour
	{
		public UnityEngine.Object startScene;

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				SceneManager.LoadScene(startScene.name);
			}
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}