using UnityEngine;

namespace Script.Main{
	public class Actor : MonoBehaviour{
		private ActorMovement movement;
		private ActorRotateView rotateView;
		private PlayerInputDetector inputDetector;
		
		[SerializeField] private float moveSpeed;
		[SerializeField] private float viewRotateSpeed;
		

		private void Start(){
			inputDetector = GetComponent<PlayerInputDetector>();
			rotateView = GetComponent<ActorRotateView>();
			movement = GetComponent<ActorMovement>();
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
			movement.Move(targetPosition , moveSpeed);
		}

		private void RotateActorView(){
			var inputData = inputDetector.GetInput();
			var targetViewAngle = new Vector3(inputData.RotateY, inputData.RotateX, 0);
			rotateView.Rotate(targetViewAngle , viewRotateSpeed);
		}

		public void CollisionEnter(){ }

		public void CollisionExit(){ }
	}
}