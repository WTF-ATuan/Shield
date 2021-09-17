using UnityEngine;

namespace Script{
	public class FPSViewAngle : MonoBehaviour{
		public Vector3 SelfViewAngle{
			get => transform.eulerAngles;
			private set => transform.eulerAngles = value;
		}

		public void Rotate(Vector3 rotateAngle){
			var rotateAngleY = rotateAngle.y;
			var rotateAngleX = -rotateAngle.x;
			SelfViewAngle += Vector3.up * rotateAngleY;
			SelfViewAngle += Vector3.right * rotateAngleX;
		}
	}
}