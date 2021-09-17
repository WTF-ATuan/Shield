using UnityEngine;

namespace Script{
	public class FPSMovement : MonoBehaviour{

		public Vector3 SelfPosition => transform.position;

		private Rigidbody movementRigidbody;
		private void Start(){
			movementRigidbody = GetComponent<Rigidbody>();
		}

		public void Move(Vector3 targetPosition){
			movementRigidbody?.AddForce(targetPosition , ForceMode.VelocityChange);
		}
	}
}