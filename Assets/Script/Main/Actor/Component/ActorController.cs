using Script.Main.Actor.Repository;
using Script.Main.Actor.UseCase;
using UnityEngine;

namespace Script.Main.Actor.Component{
	public class ActorController : MonoBehaviour{
		private ActorRepository _actorRepository;
		private ActorUseCase _actorUseCase;

		private void Awake(){
			_actorRepository = new ActorRepository();
			_actorUseCase = new ActorUseCase(_actorRepository);
		}

		public void CreateActor(string uid, int defaultHealth){
			_actorUseCase.CreateActor(uid, defaultHealth);
		}

		public void MoveActor(string uid, Vector3 inputValue){
			_actorUseCase.MoveActor(uid, inputValue);
		}

		public void EquipWeapon(string uid, Weapon.Entity.Weapon weapon){
			_actorUseCase.EquipWeapon(uid, weapon);
		}

		public void ActorFire(string uid){
			_actorUseCase.MakeActorFire(uid);
		}
	}
}