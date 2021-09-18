using UnityEngine;

namespace Script.Main{
	public class ActorMovement : MonoBehaviour{
		public Vector3 SelfPosition => transform.position;

		private Rigidbody movementRigidbody;

		private void Start(){
			movementRigidbody = GetComponent<Rigidbody>();
		}

		public void Move(Vector3 targetPosition, float moveSpeed){
			var moveDirection = targetPosition.normalized;
			var moveWorldDirection = transform.TransformDirection(moveDirection) * moveSpeed;
			var movementVelocity = movementRigidbody.velocity;
			var moveForce = new Vector3(moveWorldDirection.x - movementVelocity.x, 0f,
				moveWorldDirection.z - movementVelocity.z);
			movementRigidbody.AddForce(moveForce, ForceMode.VelocityChange);
		}
	}
}