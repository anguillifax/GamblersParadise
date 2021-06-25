using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SimpleTimer {

	public float duration;
	public float current;

	public bool Done {
		get {
			return current <= 0;
		}
	}

	public bool Running {
		get {
			return current > 0;
		}
	}

	public float Progress {
		get {
			return 1 - Mathf.Clamp01(current / duration);
		}
	}

	public SimpleTimer(float duration) {
		this.duration = duration;
	}

	public void Set() {
		current = duration;
	}

	public void End() {
		current = 0;
	}

	public void Update(bool fixedUpdate = false) {
		Update(fixedUpdate ? Time.fixedDeltaTime : Time.deltaTime);
	}

	public void Update(float delta) {
		if (current >= 0) current -= delta;
	}

	public SimpleTimer Copy() {
		return new SimpleTimer(duration);
	}

}
