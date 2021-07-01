using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

namespace GameJam
{
	public class YarnCommands : MonoBehaviour
	{
		// =========================================================
		// Variables
		// =========================================================

		public DialogueRunner dialogueRunner;
		public AudioSource speakerSfx;
		public PortraitControl portraitControl;
		public BackgroundControl backgroundControl;
		public MusicBox musicBox;
		public GameObject vesselPrefab;
		public Transform vesselLocation;

		[Space]
		public GameObject layoutNormal;
		public GameObject layoutFocus;

		private GameObject[] layouts;
		private VesselModel vesselInstance;

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
			dialogueRunner.AddCommandHandler("s", PaintSpeaker);
			Bind(PaintBackground);

			Bind(PlaySound);
			Bind(PlayMusic);

			Bind(LoadScene);

			Bind(ChangeTokens);

			Bind(Vessel);

			layouts = new GameObject[] { layoutNormal, layoutFocus };
		}

		// =========================================================
		// Art
		// =========================================================

		public void PaintSpeaker(string[] args) => portraitControl.SetPortrait(args);

		public void PaintBackground(string[] args) => backgroundControl.SetBackground(args);

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
				GameState.Instance.SoulTokens += delta;
			}
		}

		// =========================================================
		// Plumbing
		// =========================================================

		public void Vessel(string[] args)
		{
			switch (args[0].ToLower())
			{
				case "spawn":
					vesselLocation.gameObject.SetActive(true);
					vesselInstance = Instantiate(vesselPrefab, vesselLocation).GetComponent<VesselModel>();
					vesselInstance.InitSides(args.Length == 2 ? int.Parse(args[1]) : 3);
					break;
				case "bias":
					vesselInstance.Bias(int.Parse(args[1]));
					break;
				case "scarlet":
					vesselInstance.Bias(5);
					break;
				case "sky":
					vesselInstance.Bias(1);
					break;
				case "roll":
					vesselInstance.Roll();
					break;
				case "choose":
					vesselInstance.Choose();
					break;
				case "hide":
					vesselLocation.gameObject.SetActive(false);
					break;
				case "show":
					vesselLocation.gameObject.SetActive(true);
					break;
				case "destroy":
					Util.DestroyChildObjects(vesselLocation);
					break;
				default:
					Debug.LogWarning("Unknown flag " + args[0]);
					break;
			}
		}
	}
}