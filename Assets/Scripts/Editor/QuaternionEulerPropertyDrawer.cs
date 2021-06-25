using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyEditors {

	[CustomPropertyDrawer(typeof(Quaternion))]
	public class QuaternionEulerPropertyDrawer : PropertyDrawer {

		public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label) {

			EditorGUI.BeginProperty(pos, label, prop);

			var euler = prop.quaternionValue.eulerAngles;
			euler = EditorGUI.Vector3Field(pos, label, euler);
			prop.quaternionValue = Quaternion.Euler(euler);

			EditorGUI.EndProperty();

		}

	}

}