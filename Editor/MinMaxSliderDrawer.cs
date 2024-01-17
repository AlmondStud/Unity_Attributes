using System;
using UnityEngine;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Almond {
#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
	public class MinMaxSliderDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var fieldAttribute = (attribute as MinMaxSliderAttribute);
			var target = property.serializedObject.targetObject;
			var type = target.GetType();

			var targetProperty = type.GetField(property.name);
			if(targetProperty.FieldType != typeof(Vector2) && targetProperty.FieldType != typeof(Vector2Int)) {
				GUI.Label(position, $"Use Vector2 or Vector2Int :: {label}");
				return;
			}
			var min = fieldAttribute.min;
			var max = fieldAttribute.max;
			var rangeAttribute = fieldInfo.GetAttribute<RangeAttribute>();
			if(rangeAttribute != null) {
				min = rangeAttribute.min;
				max = rangeAttribute.max;
			}
			if(min > max) {
				var temp = min;
				min = max;
				max = temp;
			}

			EditorGUILayout.BeginVertical();
			EditorGUILayout.BeginHorizontal();
			if(targetProperty.FieldType == typeof(Vector2)) {
				var currentValue = (Vector2)targetProperty.GetValue(target);
				var temp = currentValue;
				EditorGUILayout.MinMaxSlider(label, ref temp.x, ref temp.y, min, max);
				temp = EditorGUILayout.Vector2Field("", temp, GUILayout.Width(150));
				temp.x = Mathf.Clamp(temp.x, min, max);
				temp.y = Mathf.Clamp(temp.y, min, max);

				if(temp.x > temp.y)
					temp.x = temp.y;
				targetProperty.SetValue(target, temp);
			}
			else {
				var currentValue = (Vector2Int)targetProperty.GetValue(target);
				var temp = (Vector2)currentValue;
				EditorGUILayout.MinMaxSlider(label, ref temp.x, ref temp.y, min, max);
				var vector2Int = new Vector2Int((int)temp.x, (int)temp.y);
				vector2Int = EditorGUILayout.Vector2IntField("", vector2Int, GUILayout.Width(150));
				vector2Int.x = Mathf.Clamp(vector2Int.x, (int)min, (int)max);
				vector2Int.y = Mathf.Clamp(vector2Int.y, (int)min, (int)max);

				if(vector2Int.x > vector2Int.y)
					vector2Int.x = vector2Int.y;
				targetProperty.SetValue(target, vector2Int);
			}
			EditorGUILayout.EndHorizontal();
			var rightAlign = new GUIStyle();
			rightAlign.alignment = TextAnchor.MiddleRight;
			rightAlign.normal.textColor = Color.gray;
			EditorGUILayout.LabelField($"Range : {min} ~ {max}", rightAlign);
			EditorGUILayout.EndVertical();
		}
	}
#endif
}