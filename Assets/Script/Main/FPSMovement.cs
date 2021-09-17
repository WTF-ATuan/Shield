using UnityEngine;

namespace Script{
	public class FPSMovement : MonoBehaviour{

		public Vector3 SelfPosition{
			get => transform.position;
			set => transform.position = value;
		}

		public void Move(Vector3 targetPosition){
			SelfPosition += targetPosition;
		}
	}
}