using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam
{
	public class SceneLoader : MonoBehaviour
	{
		public void Load(string scene)
		{
			SceneManager.LoadSceneAsync(scene);
		}
	}
}