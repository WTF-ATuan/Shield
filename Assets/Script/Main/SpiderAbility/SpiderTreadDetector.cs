using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderTreadDetector : MonoBehaviour{
		[SerializeField] private float treadMaxDistance;

		private void Update(){
			if(Input.GetMouseButtonDown(0)){
				CreateTreadData(transform.forward, treadMaxDistance);
			}
		}

		public void CreateTreadData(Vector3 direction, float maxDistance){
			var ray = new Ray(transform.position, direction);
			if(!Physics.Raycast(ray, out var hitInfo, maxDistance)) return;
			var attachPosition = hitInfo.point;
			var position = transform.position;
			var distance = Vector3.Distance(position, attachPosition);
			var treadUpdated = new SpiderTreadUpdated(distance, position, attachPosition);
			EventBus.Post(treadUpdated);
		}
	}

	public class SpiderTreadUpdated{
		public float Distance{ get; }
		public Vector3 OriginPosition{ get; }
		public Vector3 AttachPosition{ get; }

		public SpiderTreadUpdated(float distance, Vector3 originPosition, Vector3 attachPosition){
			Distance = distance;
			OriginPosition = originPosition;
			AttachPosition = attachPosition;
		}
	}
}