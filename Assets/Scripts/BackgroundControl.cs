using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class BackgroundControl : MonoBehaviour
	{
		private enum Layout
		{
			Normal, Focus
		}

		public PortraitControl portraitControl;
		public SpriteRenderer sr;
		[Space]
		public GameObject canvasLayoutNormal;
		public GameObject canvasLayoutFocus;

		public void SetBackground(string[] args)
		{
			string id = args[0].ToLower();

			switch (id)
			{
				case "focus":
					RevealLayout(Layout.Focus);
					portraitControl.ClearPortrait();
					break;

				case "vessel":
					RevealLayout(Layout.Normal);
					PaintImage(null);
					break;

				default:
					RevealLayout(Layout.Normal);
					PaintImage(Resources.Load<Sprite>("Backgrounds/" + id));
					break;
			}
		}

		private void PaintImage(Sprite sprite)
		{
			sr.sprite = sprite;
		}

		private void RevealLayout(Layout layout)
		{
			canvasLayoutFocus.SetActive(false);
			canvasLayoutNormal.SetActive(false);
			sr.gameObject.SetActive(false);

			switch (layout)
			{
				case Layout.Normal:
					canvasLayoutNormal.SetActive(true);
					sr.gameObject.SetActive(true);
					break;

				case Layout.Focus:
					canvasLayoutFocus.SetActive(true);
					break;
			}
		}
	}
}