using System.Collections.Generic;
using Script.Main.Utility;

namespace Script.Main.Actor.UseCase{
	public class ActorUseCase{
		public Entity.Actor CreateActor(string uid){
			var actor = new Entity.Actor(uid);
			var viewEvents = actor.GetAllViewEvent();
			var domainEvents = actor.GetAllDomainEvent();
			PostAllEvents(domainEvents);
			PostAllEvents(viewEvents);
			return actor;
		}

		private void PostAllEvents<T>(List<T> customEvents)where T : CustomEvent{
			foreach(var customEvent in customEvents){
				EventBus.Post(customEvent);
			}
		}
		
	}
}