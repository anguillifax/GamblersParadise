using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace GamblersParadise
{
	public class YarnCommands : MonoBehaviour
	{
		[Serializable]
		public struct RollParams
		{
			public string scarletOptionText;
			public string scarletOutcome;
			public string towardScarletRebuke;

			public string skyOptionText;
			public string skyOutcome;
			public string towardSkyRebuke;
		}

		// =========================================================
		// Variables
		// =========================================================

		public DialogueRunner dialogueRunner;

		public PortraitControl portraitControl;
		public Image backgroundPanel;
		public RollParams rollParams;

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
			Bind(PaintBackground);

			Bind(LoadScene);

			Bind(ConfigScarletText);
			Bind(ConfigSkyText);
			Bind(ConfigOutcomes);
			Bind(ConfigRebukes);
			Bind(BeginRoll);

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

		// =========================================================
		// Transitions
		// =========================================================

		public void LoadScene(string[] args)
		{
			SceneManager.LoadScene(args[0]);
		}

		// =========================================================
		// Vessel Roll
		// =========================================================

		public void ConfigScarletText(string[] args)
		{
			rollParams.scarletOptionText = string.Join(" ", args);
		}

		public void ConfigSkyText(string[] args)
		{
			rollParams.skyOptionText = string.Join(" ", args);
		}

		public void ConfigOutcomes(string[] args)
		{
			rollParams.scarletOutcome = args[0];
			rollParams.skyOutcome = args[1];
		}

		public void ConfigRebukes(string[] args)
		{
			rollParams.towardScarletRebuke = args[0];
			rollParams.towardSkyRebuke = args[1];
		}

		public void BeginRoll(string[] args)
		{
			Debug.LogWarning("Roll not implemented yet");
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