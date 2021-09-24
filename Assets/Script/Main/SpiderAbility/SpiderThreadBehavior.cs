using System;
using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadBehavior : MonoBehaviour{
		private Vector3 threadAttachPosition;
		private float threadDistance;
		private Vector3 threadOriginPosition;

		private void Start(){
			EventBus.Subscribe<SpiderTreadUpdated>(OnTreadCreated);
		}

		private void Update(){
			if(Input.GetMouseButton(0)){
				FixThreadPoint();
			}
		}

		private void OnTreadCreated(SpiderTreadUpdated obj){
			threadAttachPosition = obj.AttachPosition;
			threadDistance = obj.Distance;
			threadOriginPosition = obj.OriginPosition;
		}

		public void FixThreadPoint(){
			if(threadOriginPosition == transform.position) return;
			var position = transform.position;
			var distance = Vector3.Distance(position, threadAttachPosition);
			var treadUpdated = new SpiderTreadUpdated(distance, position, threadAttachPosition);
			EventBus.Post(treadUpdated);
		}
	}
}