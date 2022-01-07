using System.Collections.Generic;
using Script.Main.Actor.Repository;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor.UseCase{
	public class ActorUseCase{
		private ActorRepository Repository{ get; }

		public ActorUseCase(ActorRepository repository){
			Repository = repository;
		}
		
		public void CreateActor(string uid){
			var actor = new Entity.Actor(uid);
			Repository.Save(actor);
			var viewEvents = actor.GetAllViewEvent();
			var domainEvents = actor.GetAllDomainEvent();
			PostAllEvents(domainEvents);
			PostAllEvents(viewEvents);
		}

		public void MoveActor(string uid, Vector3 direction){
			var actor = Repository.Find(uid);
			actor.Move(direction);
			var viewEvents = actor.GetAllViewEvent();
			PostAllEvents(viewEvents);
		}

		private void PostAllEvents<T>(List<T> customEvents) where T : CustomEvent{
			foreach(var customEvent in customEvents){
				EventBus.Post(customEvent);
			}
		}
	}
}