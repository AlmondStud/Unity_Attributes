using System;
using UnityEngine;

namespace Almond {
	[AttributeUsage(AttributeTargets.Field)]
	public class ToggleButtonAttribute : PropertyAttribute {
		public string TargetName { get; }

		/// <summary>
		/// is bool property toggle button on inspector
		/// </summary>
		/// <param name="targetName"> must be a bool type </param>
		public ToggleButtonAttribute(string targetName) {
			TargetName = targetName;
		}
	}
}