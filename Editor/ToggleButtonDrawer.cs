using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Almond {
#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(ToggleButtonAttribute))]
	public class ToggleButtonDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var propertyName = (attribute as ToggleButtonAttribute).TargetName;
			var target = property.serializedObject.targetObject;
			var type = target.GetType();

			var targetProperty = type.GetProperty(propertyName);
			if(targetProperty != null) {
				if(targetProperty.PropertyType != typeof(bool)) {
					GUI.Label(position, "TargetMember must be a bool type.");
					return;
				}

				var currentValue = (bool)targetProperty.GetValue(target);
				var buttonText = $"{propertyName} :: {currentValue}";

				if(GUI.Button(position, buttonText)) {
					targetProperty.SetValue(target, !currentValue);
				}
			}
			else {
				GUI.Label(position, $"Is not property type. {propertyName}");
			}
		}
	}
#endif
}