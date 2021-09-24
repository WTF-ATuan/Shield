using System;
using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class TreadTension{
		private float Mass{ get; }
		private float Gravity{ get; }
		private Vector3 previousPosition = Vector3.zero;
		private float previousTime;

		public TreadTension(float mass, float gravity){
			Mass = mass;
			Gravity = gravity;
		}

		public float Tension(Vector3 originPosition, Vector3 attachPosition, Vector3 originDirection){
			// Tension = L(((m(v*v))/r)) + (mg* sin * angle)
			var currentTime = Time.time;
			var time = currentTime - previousTime;
			var vector = Acceleration(previousPosition, originPosition, time);
			var lenght = Vector3.Distance(attachPosition , originPosition);
			var centripetalAcceleration = lenght * (Mass * (vector * vector)/ lenght);
			return 0;
		}

		private float Acceleration(Vector3 originPosition, Vector3 targetPosition, float time){
			var vector = targetPosition - originPosition;
			return vector.magnitude / time;
		}
	}
}