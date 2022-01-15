using Actor.EventHandler;
using Project;
using UnityEngine;

namespace Actor{
	public class ActorInstaller : MonoBehaviour{
		private void Awake(){
			SingleRepository.Create<ActorDomainEventHandler>();
		}
	}
}