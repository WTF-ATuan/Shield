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
			EventBus.Subscribe<ActorCollided>(OnCollided);
		}
		
		private void Update(){
			RotateActorView();
		}

		private void FixedUpdate(){
			MoveActor();
		}

		private void MoveActor(){
			var inputData = inputDetector.GetInput();
			var targetDirection = new Vector3(inputData.Move, 0, inputData.Strafe);
			movement.Move(targetDirection , moveSpeed);
		}

		private void RotateActorView(){
			var inputData = inputDetector.GetInput();
			var targetViewAngle = new Vector3(inputData.RotateY, inputData.RotateX, 0);
			rotateView.Rotate(targetViewAngle , viewRotateSpeed);
		}
		private void OnCollided(ActorCollided dto){
			var enterOrExit = dto.EnterOrExit;
			Debug.Log($"enterOrExit = {enterOrExit}");
		}
	}
}