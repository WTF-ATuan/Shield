using System;
using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class RaycastPoster : MonoBehaviour{
		private void Update(){
			if(Input.GetMouseButton(0)){
				CreateRaycast(transform.forward, 10f);
			}
		}

		public void CreateRaycast(Vector3 direction, float maxDistance){
			var ray = new Ray(transform.position, direction);
			if(!Physics.Raycast(ray, out var hitInfo, maxDistance)) return;
			var attachPosition = hitInfo.normal;
			var position = transform.position;
			var distance = Vector3.Distance(position, attachPosition);
			var raycastData = new RaycastData(distance, position, attachPosition);
			EventBus.Post(raycastData);
		}
	}

	public class RaycastData{
		public float Distance{ get; }
		public Vector3 OriginPosition{ get; }
		public Vector3 AttachPosition{ get; }

		public RaycastData(float distance, Vector3 originPosition, Vector3 attachPosition){
			Distance = distance;
			OriginPosition = originPosition;
			AttachPosition = attachPosition;
		}
	}
}