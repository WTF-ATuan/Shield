using UnityEngine;

namespace Script.Main{
	public class ActorMovement : MonoBehaviour{

		public float Velocity{
			get{
				var rigidbodyVelocity = movementRigidbody.velocity;
				var velocityMagnitude = rigidbodyVelocity.magnitude;
				return velocityMagnitude;
			}

		}

		public double Mass => movementRigidbody.mass;

		private Rigidbody movementRigidbody;

		private void Start(){
			movementRigidbody = GetComponent<Rigidbody>();
		}

		public void BasicMove(Vector3 targetPosition, float moveSpeed){
			var moveDirection = targetPosition.normalized;
			var moveWorldDirection = transform.TransformDirection(moveDirection) * moveSpeed;
			var movementVelocity = movementRigidbody.velocity;
			var moveForce = new Vector3(moveWorldDirection.x - movementVelocity.x, 0f,
				moveWorldDirection.z - movementVelocity.z);
			movementRigidbody.AddForce(moveForce, ForceMode.VelocityChange);
		}

		public void JumpBehavior(float jumpForce){
			movementRigidbody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
		}

		public void AddForce(Vector3 direction, float forceValue){
			var force = direction * forceValue;
			Debug.Log($"force = {force}");
			movementRigidbody.AddForce(force , ForceMode.Impulse);
		}
	}
}