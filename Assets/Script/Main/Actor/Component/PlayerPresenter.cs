using Script.Main.Weapon.Component;
using UnityEngine;

namespace Script.Main.Actor.Component{
	public class PlayerPresenter : MonoBehaviour{
		private ActorController _actorController;
		private WeaponController _weaponController;
		private void Start(){
			_weaponController = GetComponent<WeaponController>();
			_actorController = GetComponent<ActorController>();
		}
	}
}