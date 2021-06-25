using UnityEngine;

[System.Serializable]
public abstract class SubAction<T> : SubBehaviour<T> where T : MonoBehaviour {

	public abstract void Update();

}

[System.Serializable]
public abstract class SubBehaviour<T> where T : MonoBehaviour {
	protected T super;
	protected GameObject gameObject;
	protected Transform transform;

	public virtual void Init(T super) {
		this.super = super;
		gameObject = super.gameObject;
		transform = super.transform;
	}
}
