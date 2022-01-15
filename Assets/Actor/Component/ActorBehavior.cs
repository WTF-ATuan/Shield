using UnityEngine;

namespace Actor.Component{
	public class ActorBehavior : MonoBehaviour{
		[SerializeField] private float moveSpeed;
		[SerializeField] private float jumpForce;
		

		private Rigidbody _rigidbody;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void MoveActor(Vector3 direction , bool isJump){
			var currentVelocityOffsetY = _rigidbody.velocity.y;
			var moveVelocity = new Vector3(direction.x , currentVelocityOffsetY , direction.z);
			_rigidbody.velocity = moveVelocity;
		}

		public void SetFaceDirection(){
			
		}
	}

}
