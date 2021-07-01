using System;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

namespace GameJam
{
	public class RandomSoundPlayer : MonoBehaviour
	{
		public AudioClip[] clips;
		public Vector2 pitchJitter = new Vector2(0.8f, 1.2f);
		public Vector2 volumeJitter = new Vector2(0.8f, 1f);

		private AudioSource source;

		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}

		public void PlaySound()
		{
			if (clips.Length == 0)
			{
				Debug.LogWarning("Must assign audio clips to play", this);
				return;
			}

			AudioClip clip = clips[URandom.Range(0, clips.Length)];

			source.pitch = URandom.Range(pitchJitter.x, pitchJitter.y);
			source.volume = URandom.Range(volumeJitter.x, volumeJitter.y);
			source.PlayOneShot(clip);
		}
	}
}