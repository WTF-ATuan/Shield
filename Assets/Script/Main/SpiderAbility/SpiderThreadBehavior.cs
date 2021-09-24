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
			springJoint.enablePreprocessing = false;
		}

		private void StartSwingBehavior(Vector3 attachPosition, float distance){
			springJoint.enablePreprocessing = true;
			springJoint.autoConfigureConnectedAnchor = false;
			springJoint.connectedAnchor = attachPosition;
			springJoint.maxDistance = distance * 0.8f;
			springJoint.minDistance = distance * 0.25f;
			springJoint.spring = 4.5f;
			springJoint.damper = 7f;
			springJoint.massScale = 4.5f;
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