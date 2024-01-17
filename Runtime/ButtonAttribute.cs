using UnityEngine;

namespace Almond {
	public class ButtonAttribute : PropertyAttribute {
		public string MethodName { get; }
		public ButtonAttribute(string methodName) {
			MethodName = methodName;
		}
	}
}