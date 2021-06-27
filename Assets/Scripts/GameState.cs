﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	internal class GameState : MonoBehaviour
	{
		public static GameState Instance { get; private set; }

		public int SoulTokens { get; set; }

		public string YarnStartNode { get; set; }
		public bool LastRollWasScarlet { get; set; }
		public string OutcomeScarletNode { get; set; }
		public string OutcomeSkyNode { get; set; }

		private void Awake()
		{
			Instance = this;

			SoulTokens = 3;
		}
	}
}