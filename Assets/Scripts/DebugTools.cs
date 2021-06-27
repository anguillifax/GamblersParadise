using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace GamblersParadise
{
	internal class DebugTools : MonoBehaviour
	{
		public DialogueRunner dialogueRunner;

		public void PlayNode(string node)
		{
			dialogueRunner.StartDialogue(node);
		}
	}
}