using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	public class MusicBox : MonoBehaviour
	{
		public AudioSource source;
		public float speed = 2;

		// =========================================================

		public void Play(string id)
		{
			id = id.ToLower();
			if (id == "none")
			{
				StartCoroutine(ChangeCR(null));
				return;
			}

			var clip = Resources.Load<AudioClip>("Music/" + id);
			if (clip != null)
			{
				StartCoroutine(ChangeCR(clip));
			}
		}

		private IEnumerator ChangeCR(AudioClip to)
		{
			if (source.clip != null)
			{
				while (source.volume != 0)
				{
					source.volume = Mathf.MoveTowards(source.volume, 0, speed * Time.deltaTime);
					yield return new WaitForEndOfFrame();
				}
			}
			source.volume = 0;
			source.clip = to;
			source.Play();
			while (source.volume != 1)
			{
				source.volume = Mathf.MoveTowards(source.volume, 1, speed * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}
	}
}