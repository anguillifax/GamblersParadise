using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

namespace GamblersParadise
{
	internal class DialogueController : MonoBehaviour
	{
		public DialogueUI dialogue;

		private void Advance()
		{
			dialogue.MarkLineComplete();
		}

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				Advance();
			}
		}
	}
}