using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
	public class CrossfadeControl : MonoBehaviour
	{
		public enum Direction
		{
			ToTransparent, ToSolid
		}

		public Image image;
		public Direction direction;
		public float speed = 1f;
		public bool running;

		private void Start()
		{
			running = false;
		}

		private void Update()
		{
			if (running)
			{
				float alpha = image.color.a;
				alpha = Mathf.MoveTowards(alpha, direction == Direction.ToTransparent ? 0 : 1, speed * Time.deltaTime);
				image.color = Util.SetAlpha(image.color, alpha);
			}
		}

		public void Run()
		{
			running = true;
		}
	}
}