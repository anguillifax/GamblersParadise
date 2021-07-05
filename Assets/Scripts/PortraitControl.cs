using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZTools;

namespace GameJam
{
	public class PortraitControl : MonoBehaviour
	{
		public SpriteRenderer portraitRenderer;
		public TextMeshProUGUI speakerField;
		public string[] speakerDisplayNames;
		public string[] creditNames;
		public string[] miscNames;
		public string lastPortrait;

		private Dictionary<string, string> speakerMap;
		private Dictionary<string, string> creditMap;
		private Dictionary<string, string> miscMap;

		private void Awake()
		{
			speakerMap = speakerDisplayNames.ToDictionary(x => x.Split(';')[0], x => x.Split(';')[1]);
			creditMap = creditNames.ToDictionary(x => x.Split(';')[0], x => x.Split(';')[1]);
			miscMap = miscNames.ToDictionary(x => x.Split(';')[0], x => x.Split(';')[1]);
			lastPortrait = string.Empty;
		}

		public void SetPortrait(string[] args)
		{
			if (string.Equals(args[0], "none", StringComparison.OrdinalIgnoreCase))
			{
				ClearPortrait();
			}
			else
			{
				SetPortrait(args[0], args.Length == 1 ? "default" : args[1]);
			}
		}

		public void ClearPortrait()
		{
			portraitRenderer.sprite = null;
			speakerField.text = string.Empty;
			lastPortrait = string.Empty;
		}

		public void SetPortrait(string id, string portrait)
		{
			id = id.ToLower();
			portrait = portrait.ToLower();

			//if (id == lastPortrait)
			//{
			//	return;
			//}
			//lastPortrait = id;

			string basepath = $"Portraits/{id}/";
			Sprite sprite = Resources.Load<Sprite>(basepath + portrait);
			if (sprite == null)
			{
				sprite = Resources.Load<Sprite>(basepath + "default");
			}

			if (sprite == null)
			{
				Debug.LogWarning($"No sprite and no fallback sprite found for {id}");
			}

			portraitRenderer.sprite = sprite;

			switch (id)
			{
				case "misc":
					speakerField.text = miscMap[portrait];
					break;

				case "credits":
					speakerField.text = creditMap[portrait];
					break;

				default:
					if (speakerMap.TryGetValue(id, out string displayName))
					{
						speakerField.text = displayName;
					}
					else
					{
						Debug.LogWarning("Display name not found for " + id);
						speakerField.text = string.Empty;
					}
					break;
			}
		}
	}
}