using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class MusicBox : MonoBehaviour
	{
		public AudioSource source;
		public float speed = 2;
		public AudioClip next;

		// =========================================================

		private void Start()
		{
			Change(null);
		}

		public void Play(string id)
		{
			id = id.ToLower();
			if (id == "none")
			{
				Change(null);
				return;
			}

			Change(Resources.Load<AudioClip>("Music/" + id));
		}

		private void Update()
		{
			if (source.clip != next)
			{
				source.volume = Mathf.MoveTowards(source.volume, 0, speed * Time.deltaTime);
				if (source.volume == 0)
				{
					source.clip = next;
					source.Play();
				}
			}
			else
			{
				float target = source.clip == null ? 0 : 1;
				source.volume = Mathf.MoveTowards(source.volume, target, speed * Time.deltaTime);
			}
		}

		private void Change(AudioClip to)
		{
			next = to;
		}
	}
}