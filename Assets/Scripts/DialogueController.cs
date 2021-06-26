using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

namespace GamblersParadise
{
	internal class DialogueController : MonoBehaviour, IPointerClickHandler
	{
		public DialogueUI dialogue;

		private void Advance()
		{
			dialogue.MarkLineComplete();
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			Advance();
		}
	}
}