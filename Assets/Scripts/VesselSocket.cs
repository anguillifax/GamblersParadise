using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class VesselSocket : MonoBehaviour
	{
		public SpriteRenderer icon;
		public Sprite scarlet;
		public Sprite sky;

		public bool IsScarlet => icon.sprite == scarlet;

		public void Init(bool isScarlet)
		{
			icon.sprite = isScarlet ? scarlet : sky;
		}

		public void Change(bool isScarlet)
		{
			icon.sprite = isScarlet ? scarlet : sky;
		}
	}
}