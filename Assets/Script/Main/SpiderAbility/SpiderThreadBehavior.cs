using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadBehavior : MonoBehaviour{
		private Vector3 threadAttachPosition;
		private Vector3 threadOriginPosition;

		[SerializeField] private ActorMovement actorMovement;
		private SpringJoint springJoint;

		private void Start(){
			actorMovement = GetComponentInParent<ActorMovement>();
			EventBus.Subscribe<SpiderTreadCreated>(OnTreadCreated);
		}

		private void Update(){
			if(Input.GetMouseButton(0)){
				FixThreadPoint();
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
			Destroy(springJoint);
		}

		private void StartSwingBehavior(Vector3 attachPosition, float distance){
			springJoint = actorMovement.gameObject.AddComponent<SpringJoint>();
			springJoint.autoConfigureConnectedAnchor = false;
			springJoint.connectedAnchor = attachPosition;
			springJoint.maxDistance = distance * 0.8f;
			springJoint.minDistance = distance * 0.25f;
			springJoint.spring = 9f; // Runtime set 依照一些data 來判斷
			springJoint.damper = 14f;
			springJoint.massScale = 9f;
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