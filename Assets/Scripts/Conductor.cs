using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{
	public interface IConductor
	{
		GameObject Create(GameObject prefab);
		void DestroyAll();
	}

	public interface IConductee
	{
		void OnExit();
	}

	public class Conductor : MonoBehaviour, IConductor
	{
		public List<GameObject> alive = new List<GameObject>();
		private GameObject root;

		private void Awake()
		{
			root = Instantiate(new GameObject("Internal Container"), transform);
		}

		public void SetVisibility(bool shown)
		{
			root.SetActive(shown);
		}

		public GameObject Create(GameObject prefab)
		{
			var go = Instantiate(prefab, root.transform);
			alive.Add(go);
			return go;
		}

		public void DestroyAll()
		{
			foreach (var item in alive)
			{
				item.BroadcastMessage(nameof(IConductee.OnExit), SendMessageOptions.DontRequireReceiver);
			}
			alive.Clear();
		}
	}
}