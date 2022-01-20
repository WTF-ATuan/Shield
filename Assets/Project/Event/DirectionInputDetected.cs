using UnityEngine;

namespace Project.Event{
	public class DirectionInputDetected{
		public Vector3 TargetPosition{ get; }

		public DirectionInputDetected(Vector3 targetPosition){
			TargetPosition = targetPosition;
		}
	}
}