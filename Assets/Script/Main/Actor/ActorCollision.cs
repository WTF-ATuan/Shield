using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main{
	public class ActorCollision : MonoBehaviour{
		private Actor actor;

		private void Start(){
			actor = GetComponent<Actor>();
			gameObject.OnCollisionEnterAsObservable().Subscribe(OnActorCollisionEnter);
			gameObject.OnCollisionExitAsObservable().Subscribe(OnActorCollisionExit);
		}

		private void OnActorCollisionExit(Collision other){
			actor.CollisionExit();
		}

		private void OnActorCollisionEnter(Collision other){
			actor.CollisionEnter();
		}
	}
}