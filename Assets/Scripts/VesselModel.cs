using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class VesselModel : MonoBehaviour
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

			while (true)
			{
				body.AddTorque(force, ForceMode.Acceleration);
				yield return new WaitForFixedUpdate();
			}

		}

		public void InitSides(int scarletCount)
		{
			for (int i = 0; i < 6; i++)
			{
				icons[i].Init(i < scarletCount);
			}
		}

		public void Bias(int scarletCount)
		{
			for (int i = 0; i < 6; i++)
			{
				icons[i].Change(i < scarletCount);
			}
		}

		public void Choose()
		{
			StopAllCoroutines();

			int val = UnityEngine.Random.Range(0, 6);
			bool isScarlet = icons[val].IsScarlet;
			Instantiate(isScarlet ? effectScarlet : effectSky, transform.position, Quaternion.identity, transform.parent);
			if (GameState.Instance) GameState.Instance.LastRollWasScarlet = isScarlet;

			Destroy(gameObject);
		}
	}
}