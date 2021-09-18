using UnityEngine;

namespace Script.Main{
	public class ActorMovement : MonoBehaviour{
		public Transform SelfPosition => transform;

		private Rigidbody movementRigidbody;

		private void Start(){
			movementRigidbody = GetComponent<Rigidbody>();
		}

		public void Move(Vector3 targetPosition){
			var moveDirection = targetPosition.normalized;
			var moveWorldDirection = SelfPosition.TransformDirection(moveDirection) * 5f;
			var movementVelocity = movementRigidbody.velocity;
			var moveForce = new Vector3(moveWorldDirection.x - movementVelocity.x, 0f,
				moveWorldDirection.z - movementVelocity.z);
			movementRigidbody.AddForce(moveForce, ForceMode.VelocityChange);
		}
	}
}