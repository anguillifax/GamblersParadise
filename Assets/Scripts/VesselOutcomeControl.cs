using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam
{
	public class VesselOutcomeControl : MonoBehaviour
	{
		public static VesselOutcomeControl Instance { get; private set; }

		public VesselOutcomeOptionBox scarlet;
		public VesselOutcomeOptionBox sky;

		bool resScarlet;

		private void Awake()
		{
			Instance = this;
		}

		public void SelectOutcome(bool isScarlet)
		{
			resScarlet = isScarlet;
			if (isScarlet)
			{
				scarlet.Select();
				sky.Remove();
			}
			else
			{
				scarlet.Remove();
				sky.Select();
			}
			Invoke(nameof(ReturnToText), 4f);
		}

		private void ReturnToText()
		{
			GameState.Instance.YarnStartNode = resScarlet ? GameState.Instance.OutcomeScarletNode : GameState.Instance.OutcomeSkyNode;
			SceneManager.LoadScene("Dialogue");
		}
	}
}