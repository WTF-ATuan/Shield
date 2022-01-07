using NUnit.Framework;
using Script.Main.Actor.Repository;
using Script.Main.Actor.UseCase;
using UnityEngine;

namespace Script.MainTest.Actor{
	public class ActorUseCaseTest{
		[Test]
		public void Actor_Created_Should_Add_To_Repository(){
			var actorRepository = new ActorRepository();
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.CreateActor("123");
			var actorCount = actorRepository.ActorCount;
			Assert.GreaterOrEqual(actorCount, 1);
		}

		[Test]
		public void Make_Actor_Move(){
			const string actorID = "123";
			var actor = new Main.Actor.Entity.Actor(actorID);
			var actorRepository = new ActorRepository();
			actorRepository.Save(actor);
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.CreateActor(actorID);
			actorUseCase.MoveActor(actorID, Vector3.forward);
			var viewEvents = actor.GetAllViewEvent();
			var viewEventsCount = viewEvents.Count;
			Assert.Greater(viewEventsCount, 0);
		}
	}
}