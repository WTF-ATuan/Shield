using UnityEngine;

namespace Actor.Component{
	public class ActorBehavior : MonoBehaviour{
		[SerializeField] private float moveSpeed;
		[SerializeField] private float jumpForce;


		private Rigidbody _rigidbody;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void MoveActor(Vector3 direction, bool isJump){
			var currentVelocityOffsetY = _rigidbody.velocity.y;
			var moveVelocity = new Vector3(direction.x, currentVelocityOffsetY, direction.z) * moveSpeed;
			_rigidbody.velocity = moveVelocity;
			if(!isJump) return;
			_rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		public void SetFaceDirection(Vector3 direction , float strength){
			var currentFaceDirection = transform.eulerAngles;
			var increasedDirection = direction * strength;
			increasedDirection.z = 0;
			var nextFaceDirection = currentFaceDirection + increasedDirection;
			transform.eulerAngles = nextFaceDirection;
		}
	}
}