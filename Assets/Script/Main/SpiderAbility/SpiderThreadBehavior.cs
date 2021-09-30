using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadBehavior : MonoBehaviour{
		private Vector3 threadAttachPosition;
		private Vector3 threadOriginPosition;
		private SpiderTreadDetector spiderTreadDetector;
		private ActorMovement actorMovement;
		
		private void Start(){
			actorMovement = GetComponentInParent<ActorMovement>();
			spiderTreadDetector = GetComponent<SpiderTreadDetector>();
			EventBus.Subscribe<SpiderTreadCreated>(OnTreadCreated);
		}

		private void Update(){
			if(Input.GetMouseButton(0)){
				FixThreadPoint();
			}

			if(Input.GetMouseButtonDown(0)){
				spiderTreadDetector.CreateTreadData(transform.forward);
			}

			if(Input.GetMouseButtonUp(0)){
				StopSwingBehavior();
			}
		}

		private void OnTreadCreated(SpiderTreadCreated obj){
			threadAttachPosition = obj.AttachPosition;
			threadOriginPosition = obj.OriginPosition;
			StartSwingBehavior(threadAttachPosition, obj.Distance);
		}

		private void StopSwingBehavior(){
		}

		private void StartSwingBehavior(Vector3 attachPosition, float distance){
		}

		private void FixThreadPoint(){
			var position = transform.position;
			var treadUpdated = new SpiderTreadUpdated(position, threadAttachPosition);
			EventBus.Post(treadUpdated);
		}
	}

	public class SpiderTreadUpdated{
		public Vector3 OriginPosition{ get; }
		public Vector3 AttachPosition{ get; }

		public SpiderTreadUpdated(Vector3 originPosition, Vector3 attachPosition){
			OriginPosition = originPosition;
			AttachPosition = attachPosition;
		}
	}
}