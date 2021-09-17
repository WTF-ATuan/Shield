using UnityEngine;

namespace Script{
	public class Actor : MonoBehaviour{
		private FPSMovement movement;
		private FPSViewAngle viewAngle;
		private PlayerInputDetector inputDetector;

		private void Start(){
			inputDetector = GetComponent<PlayerInputDetector>();
			viewAngle = GetComponent<FPSViewAngle>();
			movement = GetComponent<FPSMovement>();
		}

		private void Update(){
			RotateActorView();
		}

		private void FixedUpdate(){
			MoveActor();
		}

		private void MoveActor(){
			var inputData = inputDetector.GetInput();
			var targetPosition = new Vector3(inputData.Move, 0, inputData.Strafe);
			movement.Move(targetPosition);
		}

		private void RotateActorView(){
			var inputData = inputDetector.GetInput();
			var targetViewAngle = new Vector3(inputData.RotateY, inputData.RotateX, 0);
			viewAngle.Rotate(targetViewAngle);
		}
	}
}