using Actor.EventHandler;
using Project;
using UnityEngine;

namespace Actor.Component.Application{
	public class ActorInstaller : MonoBehaviour{
		private void Awake(){
			SingleRepository.Create<ActorDomainEventHandler>();
		}
	}
}