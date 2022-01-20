using UnityEngine;

namespace Project.Event{
	public class DirectionInputDetected{
		public Vector3 TargetPosition{ get; }
		public Vector3 TargetDirection{ get; }

		public DirectionInputDetected(Vector3 targetPosition , Vector3 targetDirection){
			TargetPosition = targetPosition;
			TargetDirection = targetDirection;
		}
	}
}