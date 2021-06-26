using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	internal class VesselModel : MonoBehaviour
	{
		public static VesselModel Instance { get; private set; }

		public VesselSocket[] icons;
		public bool triggerAnim;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			BiasEqual();
		}

		private void Update()
		{
			if (triggerAnim)
			{
				triggerAnim = false;
				foreach (var item in GetComponentsInChildren<VesselHinge>())
				{
					item.Animate();
				}
			}
		}

		public void BiasEqual()
		{
			icons[0].Set(true);
			icons[1].Set(true);
			icons[2].Set(true);
			icons[3].Set(false);
			icons[4].Set(false);
			icons[5].Set(false);
		}

		public void BiasScarlet()
		{
			icons[0].Set(true);
			icons[1].Set(true);
			icons[2].Set(true);
			icons[3].Set(true);
			icons[4].Set(true);
			icons[5].Set(false);
		}

		public void BiasSky()
		{
			icons[0].Set(true);
			icons[1].Set(false);
			icons[2].Set(false);
			icons[3].Set(false);
			icons[4].Set(false);
			icons[5].Set(false);
		}
	}
}