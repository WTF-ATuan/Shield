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
			EventBus.Post(new Collided(actor));
		}
	}

	public class Collided{
		public Actor actor;

		public Collided(Actor actor){
			this.actor = actor;
		}
	}
}