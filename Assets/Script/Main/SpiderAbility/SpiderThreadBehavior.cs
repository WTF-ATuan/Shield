using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadBehavior : MonoBehaviour{
		private Vector3 threadAttachPosition;
		private Vector3 threadOriginPosition;

		[SerializeField] private ActorMovement actorMovement;
		private SpringJoint springJoint;

		private void Start(){
			actorMovement = GetComponentInParent<ActorMovement>();
			springJoint = actorMovement.gameObject.AddComponent<SpringJoint>();
			EventBus.Subscribe<SpiderTreadCreated>(OnTreadCreated);
		}

		private void Update(){
			if(Input.GetMouseButton(0)){
				FixThreadPoint();
			}
		}

		private void OnTreadCreated(SpiderTreadCreated obj){
			threadAttachPosition = obj.AttachPosition;
			threadOriginPosition = obj.OriginPosition;
		}

		public void FixThreadPoint(){
			if(threadOriginPosition == transform.position) return;
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