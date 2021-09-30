using System;
using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadBehavior : MonoBehaviour{
		private Vector3 threadAttachPosition;
		private SpiderTreadDetector spiderTreadDetector;
		private ActorMovement actorMovement;
		
		private void Start(){
			actorMovement = GetComponentInParent<ActorMovement>();
			spiderTreadDetector = GetComponent<SpiderTreadDetector>();
			EventBus.Subscribe<SpiderTreadCreated>(StartSwingBehavior);
		}

		private void Update(){
			if(Input.GetMouseButtonDown(0)){
				spiderTreadDetector.CreateTreadData(transform.forward);
			}

			if(Input.GetMouseButtonUp(0)){
				StopSwingBehavior();
			}

			if(Input.GetMouseButton(0)){
				FixThreadPoint();
			}
		}

		private void StartSwingBehavior(SpiderTreadCreated obj){
			// Tension = L(((m(v*v))/r)) + (mg* sin * angle)
			threadAttachPosition = obj.AttachPosition;
			var originPosition = obj.OriginPosition;
			var objDistance = obj.Distance;
			var angle = Vector3.Angle(originPosition, threadAttachPosition);
			var velocity = actorMovement.Velocity;
			actorMovement.AddForce(transform.forward + Vector3.up , objDistance);
		}

		private void StopSwingBehavior(){
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