using System;
using UnityEngine;

namespace Almond {
	[AttributeUsage(AttributeTargets.Field)]
	public class RangeFloatPropertyAttribute : PropertyAttribute {
		public string TargetName { get; }
		public float Left { get; }
		public float Right { get; }

		public RangeFloatPropertyAttribute(string targetName, float left, float right) {
			TargetName = targetName;
			Left = left;
			Right = right;
		}
	}
}