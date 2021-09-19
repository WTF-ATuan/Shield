using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main{
	public class ActorCollision : MonoBehaviour{
		private void Start(){
			gameObject.OnCollisionEnterAsObservable().Subscribe(OnActorCollisionEnter);
			gameObject.OnCollisionExitAsObservable().Subscribe(OnActorCollisionExit);
		}

		private void OnActorCollisionEnter(Collision other){
			EventBus.Post(new ActorCollided(true, other));
		}

		private void OnActorCollisionExit(Collision other){
			EventBus.Post(new ActorCollided(false, other));
		}
	}

	public class ActorCollided{
		public bool EnterOrExit{ get; }
		public Collision Other{ get; }

		public ActorCollided(bool enterOrExit, Collision other){
			EnterOrExit = enterOrExit;
			Other = other;
		}
	}
}