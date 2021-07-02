using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

namespace GameJam
{
	internal class DialogueController : MonoBehaviour
	{
		public UnityEvent onClick;
		public DialogueUI dialogue;
		public SimpleTimer delay = new SimpleTimer(0.4f);
		public SimpleTimer deadzone = new SimpleTimer(10f);
		public Animator continueAnim;

		private bool clickDone;

		private void Start()
		{
			deadzone.Set();
			continueAnim.SetBool("CanContinue", false);
			clickDone = false;
		}

		private void Update()
		{
			delay.Update(Time.deltaTime);
			deadzone.Update(Time.deltaTime);

			if (deadzone.Done)
			{
				continueAnim.SetBool("CanContinue", !clickDone);
			}

			if (Input.GetMouseButtonUp(0))
			{
				if (deadzone.Done && delay.Done)
				{
					dialogue.MarkLineComplete();
					onClick.Invoke();
					delay.Set();
					clickDone = true;
				}
				else
				{
					Debug.Log("Click before deadzone over");
				}
			}
		}
	}
}