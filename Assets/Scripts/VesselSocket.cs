using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJam
{
	public class VesselSocket : MonoBehaviour
	{
		public SpriteRenderer icon;
		public Sprite scarlet;
		public Sprite sky;
		public GameObject particlesScarlet;
		public GameObject particlesSky;
		public UnityEvent onChange;

		public bool IsScarlet => icon.sprite == scarlet;

		private void SetStyle(bool isScarlet)
		{
			icon.sprite = isScarlet ? scarlet : sky;
			particlesScarlet.SetActive(isScarlet);
			particlesSky.SetActive(!isScarlet);
		}

		public void Init(bool isScarlet)
		{
			SetStyle(isScarlet);
		}

		public void Change(bool isScarlet)
		{
			if (isScarlet != IsScarlet)
			{
				SetStyle(isScarlet);
				onChange.Invoke();
			}
		}
	}
}