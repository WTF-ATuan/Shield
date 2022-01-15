using UnityEngine;

namespace Project.Event{
	public class MousePositionDetected{
		public Vector3 MousePosition{ get; }

		public MousePositionDetected(Vector3 mousePosition){
			MousePosition = mousePosition;
		}
	}
}