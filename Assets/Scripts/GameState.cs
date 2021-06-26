using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	internal class GameState : MonoBehaviour
	{
		public static GameState Instance { get; private set; }

		public int SoulTokens { get; set; }

		private void Awake()
		{
			Instance = this;

			SoulTokens = 3;
		}
	}
}