using System;
using UnityEngine;

namespace Almond {
	[AttributeUsage(AttributeTargets.Field, Inherited = true)]
	public class SerializedPropertyAttribute : PropertyAttribute {
		public string TargetName { get; }

		/// <summary>
		/// is bool property toggle button on inspector
		/// </summary>
		/// <param name="targetName"> must be a float type </param>
		public SerializedPropertyAttribute(string targetName) {
			TargetName = targetName;
		}
	}
}