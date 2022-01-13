using NUnit.Framework;
using Script.Main.Actor.Event;
using Script.Main.Actor.Repository;
using Script.Main.Actor.UseCase;
using UnityEngine;

namespace Script.MainTest.Actor{
	public class ActorUseCaseTest{
		[Test]
		public void Actor_Created_Should_Add_To_Repository(){
			var actorRepository = new ActorRepository();
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.CreateActor("123", 100);
			var actorCount = actorRepository.ActorCount;
			Assert.GreaterOrEqual(actorCount, 1);
		}

		[Test]
		public void Make_Actor_Move(){
			const string actorID = "123";
			var actor = new Main.Actor.Entity.Actor(actorID, 100);
			var actorRepository = new ActorRepository();
			var actorUseCase = new ActorUseCase(actorRepository);
			actorRepository.Save(actor);
			actorUseCase.MoveActor(actorID, Vector3.forward);
			var viewEvents = actor.GetAllViewEvent();
			var viewEventsCount = viewEvents.Count;
			Assert.Greater(viewEventsCount, 0);
		}

		[Test]
		public void Make_Actor_Jump(){
			const string actorID = "123";
			var actor = new Main.Actor.Entity.Actor(actorID, 100);
			var actorRepository = new ActorRepository();
			var actorUseCase = new ActorUseCase(actorRepository);
			actorRepository.Save(actor);
			actorUseCase.MoveActor(actorID, Vector3.up);
			var actorMovedEventList = actor.GetEvent<ActorMoved>();
			var actorMovedEvent = actorMovedEventList[0];
			var isJump = actorMovedEvent.IsJump;
			Assert.AreEqual(true, isJump);
		}

		[Test]
		public void Make_Actor_Hurt(){
			const string actorID = "123";
			var defaultHealth = 100;
			var actor = new Main.Actor.Entity.Actor(actorID, defaultHealth);
			var actorRepository = new ActorRepository();
			actorRepository.Save(actor);
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.ModifyActorHealth(actorID, -10);
			var expectHealth = defaultHealth - 10;
			Assert.AreEqual(expectHealth, actor.Health);
		}

		[Test]
		public void Make_Actor_Heal(){
			const string actorID = "123";
			var defaultHealth = 100;
			var actor = new Main.Actor.Entity.Actor(actorID, defaultHealth);
			var actorRepository = new ActorRepository();
			actorRepository.Save(actor);
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.ModifyActorHealth(actorID, +10);
			var expectHealth = defaultHealth + 10;
			Assert.AreEqual(expectHealth, actor.Health);
		}

		[Test]
		public void Make_Actor_Fire(){
			const string actorID = "123";
			var actor = new Main.Actor.Entity.Actor(actorID, 100);
			var weapon = new Main.Weapon.Entity.Weapon("123",30);
			var actorRepository = new ActorRepository();
			actorRepository.Save(actor);
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.EquipWeapon(actorID, weapon);
			actorUseCase.MakeActorFire(actorID);
			var viewEvents = weapon.GetAllViewEvent();
			Assert.Greater(viewEvents.Count, 0);
		}

		[Test]
		public void Make_Actor_Switch_Weapon(){
			const string actorID = "123";
			var actor = new Main.Actor.Entity.Actor(actorID, 100);
			var firstWeapon = new Main.Weapon.Entity.Weapon("123",30);
			var secondWeapon = new Main.Weapon.Entity.Weapon("123",7);
			var actorRepository = new ActorRepository();
			actorRepository.Save(actor);
			var actorUseCase = new ActorUseCase(actorRepository);
			actorUseCase.EquipWeapon(actorID, firstWeapon);
			actorUseCase.EquipWeapon(actorID, secondWeapon);
			var viewEvent = actor.GetEvent<WeaponSwiped>();
			Assert.AreEqual(viewEvent.Count , 1);
		}
	}
}