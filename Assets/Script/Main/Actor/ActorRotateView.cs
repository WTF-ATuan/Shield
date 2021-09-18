using UnityEngine;

namespace Script.Main{
	public class ActorRotateView : MonoBehaviour{
		public Vector3 SelfViewAngle{
			get => transform.eulerAngles;
			private set => transform.eulerAngles = value;
		}

		public void Rotate(Vector3 inputAngle, float viewRotateSpeed){
			var rotateAngleY = inputAngle.y;
			var rotateAngleX = -inputAngle.x;
			var rotateAngle = new Vector3(rotateAngleX , rotateAngleY , 0f) * viewRotateSpeed;
			SelfViewAngle += rotateAngle;
			// SelfViewAngle += Vector3.up * rotateAngleY;
			// SelfViewAngle += Vector3.right * rotateAngleX;
		}
	}
}