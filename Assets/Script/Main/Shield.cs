using System;
using UnityEngine;

namespace Script.Main{
	public class Shield : MonoBehaviour{
		private ShieldMovement movement;
		private Vector3 originalPosition;
		private Transform originalParent;

		private void Start(){
			movement = GetComponent<ShieldMovement>();
			originalPosition = transform.localPosition;
			originalParent = transform.parent;
		}

		private void Update(){
			if(Input.GetMouseButton(0)){
				ThrowShield();
			}

			if(Input.GetMouseButton(1)){
				ReturnShield(originalParent);
			}
		}

		public void ThrowShield(){
			transform.SetParent(null);
			movement.Throw(transform.forward, 10f);
		}

		public void ReturnShield(Transform actor){
			transform.SetParent(actor);
			movement.Return(originalPosition, 1f);
		}
	}
}