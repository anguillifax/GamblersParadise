using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	internal class QuitGizmo : MonoBehaviour
	{
		public float duration = 5;
		public float current = float.NaN;
		public Canvas canvas;

		private void Awake()
		{
			current = float.NaN;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				current = duration;
				canvas.gameObject.SetActive(true);
			}

			if (!float.IsNaN(current))
			{
				if (Input.GetKey(KeyCode.Escape))
				{
					current -= Time.deltaTime;

					if (current < 0)
					{
						Application.Quit();
						Debug.Log("Quit.");
					}
				}
				else
				{
					current = float.NaN;
					canvas.gameObject.SetActive(false);
				}
			}
		}
	}
}