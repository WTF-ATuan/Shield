using NUnit.Framework;
using Script.Main.Actor.Event;
using UnityEngine;

namespace Script.MainTest.Actor{
	public class ActorTest{
		[Test]
		public void Move_Actor_Forward(){
			var actor = new Main.Actor.Entity.Actor();
			var forwardDirection = Vector3.forward;
			actor.Move(forwardDirection);
			var actorMovedEvents = actor.GetEvent<ActorMoved>();
			var count = actorMovedEvents.Count;
			Assert.GreaterOrEqual(1, count);
			var movedEvent = actorMovedEvents[0];
			var moveDirection = movedEvent.Direction;
			var isEquals = moveDirection.Equals(forwardDirection);
			Assert.IsTrue(isEquals);
		}

		[Test]
		public void Equip_Weapon_On_Actor(){
			var actor = new Main.Actor.Entity.Actor();
			var weapon = new Main.Actor.Entity.Weapon();
			actor.Equip(weapon);
			var actorWeapon = actor.CurrentWeapon;
			Assert.AreEqual(weapon, actorWeapon);
		}
	}
}