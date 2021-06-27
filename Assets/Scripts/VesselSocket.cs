using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	public class VesselSocket : MonoBehaviour
	{
		public SpriteRenderer icon;
		public Sprite scarlet;
		public Sprite sky;

		public bool IsScarlet => icon.sprite == scarlet;

		public void Set(bool isScarlet)
		{
			icon.sprite = isScarlet ? scarlet : sky;
		}
	}
}