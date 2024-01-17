using UnityEngine;

namespace Almond {
	public class MinMaxSliderAttribute : PropertyAttribute {
		public float min;
		public float max;
		public MinMaxSliderAttribute(float a, float b) {
			this.min = a;
			this.max = b;
		}
		public MinMaxSliderAttribute(int a, int b) {
			this.min = a;
			this.max = b;
		}
		public MinMaxSliderAttribute() { }
	}
}