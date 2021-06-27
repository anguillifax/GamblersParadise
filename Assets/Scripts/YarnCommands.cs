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
		public Image[] backgroundPanels;
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

		private void RevealLayout(GameObject show)
		{
			foreach (var item in layouts) item.SetActive(false);
			show.SetActive(true);
		}

		private void SetBackgroundPanels(Sprite sprite)
		{
			if (sprite == null)
			{
				foreach (var item in backgroundPanels)
				{
					item.gameObject.SetActive(false);
				}
			}
			else
			{
				foreach (var item in backgroundPanels)
				{
					item.sprite = sprite;
					item.gameObject.SetActive(true);
				}
			}
		}

		public void PaintBackground(string[] args)
		{
			string id = args[0].ToLower();
			switch (id)
			{
				case "focus":
					RevealLayout(layoutFocus);
					break;
				case "vessel":
					RevealLayout(layoutNormal);
					SetBackgroundPanels(args[1] == "none" ? null : Resources.Load<Sprite>("Backgrounds/" + args[1]));
					break;
				default:
					RevealLayout(layoutNormal);
					SetBackgroundPanels(Resources.Load<Sprite>("Backgrounds/" + id));
					break;
			}
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
					break;
				case "scarlet":
					vesselInstance.BiasScarlet();
					break;
				case "sky":
					vesselInstance.BiasSky();
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