using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

namespace GamblersParadise
{
	public class YarnCommands : MonoBehaviour
	{
		// =========================================================
		// Variables
		// =========================================================

		public DialogueRunner dialogueRunner;
		public AudioSource speakerSfx;

		public PortraitControl portraitControl;
		public MusicBox musicBox;
		public Image backgroundPanel;


		// =========================================================
		// Functions
		// =========================================================

		public void Awake()
		{
			void Bind(DialogueRunner.CommandHandler func)
			{
				dialogueRunner.AddCommandHandler(func.Method.Name, func);
			}

			Bind(PaintSpeaker);
			dialogueRunner.AddCommandHandler("sp", PaintSpeaker);
			dialogueRunner.AddCommandHandler("S", PaintSpeaker);
			Bind(PaintBackground);

			Bind(PlaySound);
			Bind(PlayMusic);

			Bind(LoadScene);

			Bind(ChangeTokens);
		}

		// =========================================================
		// Art
		// =========================================================

		public void PaintSpeaker(string[] args)
		{
			if (string.Equals(args[0], "none", StringComparison.OrdinalIgnoreCase))
			{
				portraitControl.ClearPortrait();
				//speakerName.text = "";
				//dialoguePanel.sprite = basePanel;
			}
			else
			{
				portraitControl.SetPortrait(args[0], args.Length == 1 ? "default" : args[1]);
			}
		}

		public void PaintBackground(string[] args)
		{
			var sprite = Resources.Load<Sprite>("Backgrounds/" + args[0].ToLower());
			backgroundPanel.sprite = sprite;
		}

		// =========================================================
		// Sound
		// =========================================================

		public void PlaySound(string[] args)
		{
			AudioClip sound = Resources.Load<AudioClip>("Sounds/" + args[0].ToLower());
			if (sound != null)
			{
				speakerSfx.PlayOneShot(sound);
			}
		}

		public void PlayMusic(string[] args)
		{
			musicBox.Play(args[0]);
		}

		// =========================================================
		// Transitions
		// =========================================================

		public void LoadScene(string[] args)
		{
			SceneManager.LoadScene(args[0].ToLower());
		}

		// =========================================================
		// Miscellaneous
		// =========================================================

		public void ChangeTokens(string[] args)
		{
			if (int.TryParse(args[0], out int delta))
			{
				Debug.LogWarning("TODO change player health by " + delta);
			}
		}
	}
}