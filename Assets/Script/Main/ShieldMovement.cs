using UnityEngine;

namespace Script.Main{
	public class ShieldMovement : MonoBehaviour{
		private Rigidbody shieldRigidbody;

		private void Start(){
			shieldRigidbody = GetComponent<Rigidbody>();
		}

		public void Throw(Vector3 direction , float force){
			var throwDirection = transform.TransformDirection(direction) * force;
			shieldRigidbody.isKinematic = false;
			shieldRigidbody.AddForce(throwDirection , ForceMode.Impulse);
		}

		public void Return(Vector3 originalLocalPosition , float speed){
			transform.localPosition = originalLocalPosition;
			shieldRigidbody.isKinematic = true;
		}

	}
}