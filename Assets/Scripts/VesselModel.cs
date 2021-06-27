using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamblersParadise
{
	internal class VesselModel : MonoBehaviour
	{
		// =========================================================
		// Variables
		// =========================================================

		public static VesselModel Instance { get; private set; }

		public VesselSocket[] icons;
		public float animDelay = 0.5f;
		public Vector3 force;
		public bool triggerAnim;
		public GameObject effectScarlet;
		public GameObject effectSky;

		private Animator animator;
		private Rigidbody body;
		private bool doneAnim;

		// =========================================================
		// Functions
		// =========================================================

		private void Awake()
		{
			Instance = this;
			animator = GetComponent<Animator>();
			body = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			BiasEqual();
			doneAnim = false;
		}

		private void Update()
		{
			if (triggerAnim)
			{
				triggerAnim = false;
				Roll();
			}
		}

		public void Roll()
		{
			StartCoroutine(AnimCR());
		}

		private void SetAnimDone()
		{
			doneAnim = true;
		}

		private IEnumerator AnimCR()
		{
			animator.SetTrigger("Roll");
			Invoke(nameof(SetAnimDone), 2.1f);
			Destroy(animator, 2.1f);
			yield return new WaitForSeconds(animDelay);

			foreach (var item in GetComponentsInChildren<VesselHinge>())
			{
				item.Animate();
			}
			yield return new WaitUntil(() => doneAnim);

			doneAnim = false;
			Invoke(nameof(SetAnimDone), 4f);
			while (true)
			{
				body.AddTorque(force, ForceMode.Acceleration);
				if (doneAnim) break;
				yield return new WaitForFixedUpdate();
			}

			GenerateAnswer();
			Destroy(gameObject);
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

		private void GenerateAnswer()
		{
			int val = UnityEngine.Random.Range(0, 6);
			bool isScarlet = icons[val].IsScarlet;
			Instantiate(isScarlet ? effectScarlet : effectSky, transform.position, Quaternion.identity);
			VesselOutcomeControl.Instance.SelectOutcome(isScarlet);
			if (GameState.Instance) GameState.Instance.LastRollWasScarlet = isScarlet;
		}
	}
}