using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamblersParadise
{
	internal class MainMenuCommands : MonoBehaviour
	{
		public GameObject sessionPrefab;
		public string startNode = "UNSET";
		public int startTokens = 3;
		public UnityEngine.Object startScene;

		public void StartGame()
		{
			StartCoroutine(StartCR());
		}

		private IEnumerator StartCR()
		{
			var go = Instantiate(sessionPrefab);
			DontDestroyOnLoad(go);
			yield return null;

			GameState.Instance.YarnStartNode = startNode;
			GameState.Instance.SoulTokens = startTokens;
			SceneManager.LoadScene(startScene.name);
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}