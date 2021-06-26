using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamblersParadise
{
	public class PortraitControl : MonoBehaviour
	{
		public GameObject spirits;
		public Image spriteScarlet;
		public Image spriteSky;
		public GameObject centered;
		public Sprite miniSky;
		public Sprite miniScarlet;
		public TextMeshProUGUI speakerField;
		public string[] speakerDisplayNames;
		private Dictionary<string, string> speakerMap;

		private void Awake()
		{
			speakerMap = speakerDisplayNames.ToDictionary(x => x.Split(';')[0], x => x.Split(';')[1]);
		}

		public void ClearPortrait()
		{
			centered.SetActive(false);
			spirits.SetActive(false);
			speakerField.gameObject.SetActive(false);
		}

		public void SetPortrait(string id, string portrait)
		{
			id = id.ToLower();
			portrait = portrait.ToLower();

			string basepath = $"Portraits/{id}/";
			var sprite = Resources.Load<Sprite>(basepath + portrait);
			if (sprite == null)
			{
				sprite = Resources.Load<Sprite>(basepath + "default");
			}
			if (sprite == null)
			{
				Debug.LogWarning("Sprite " + id + " " + portrait + " not found");
			}

			if (id == "scarlet" || id == "sky")
			{
				spirits.SetActive(true);
				centered.SetActive(false);
				if (id == "scarlet")
				{
					spriteScarlet.sprite = sprite;
					spriteSky.sprite = miniSky;
				}
				else
				{
					spriteScarlet.sprite = miniScarlet;
					spriteSky.sprite = sprite;
				}
			}
			else
			{
				spirits.SetActive(false);
				centered.SetActive(true);
				centered.GetComponent<Image>().sprite = sprite;
			}

			if (speakerMap.TryGetValue(id, out string displayName))
			{
				speakerField.text = displayName;
				speakerField.gameObject.SetActive(true);
			}
			else
			{
				Debug.LogWarning("Display name not found for " + id);
			}
		}
	}
}