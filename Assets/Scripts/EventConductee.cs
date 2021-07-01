using UnityEngine;
using UnityEngine.Events;

namespace ZTools
{
	public class EventConductee : MonoBehaviour, IConductee
	{
		public UnityEvent start;
		public UnityEvent exit;

		public float destroyDelay = 5;

		private void Start()
		{
			start.Invoke();
		}

		public void OnExit()
		{
			exit.Invoke();
			Destroy(gameObject, destroyDelay);
		}
	}
}