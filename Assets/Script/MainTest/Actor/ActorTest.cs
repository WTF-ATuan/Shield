﻿using System;
using NUnit.Framework;
using Script.Main.Actor.Event;
using UnityEngine;

namespace Script.MainTest.Actor{
	public class ActorTest{
		[Test]
		public void Create_Actor(){
			var actor = new Main.Actor.Entity.Actor("123");
			var actorCreatedEvents = actor.GetEvent<ActorCreated>();
			var eventCount = actorCreatedEvents.Count;
			Assert.GreaterOrEqual(eventCount, 1);
		}

		[Test]
		public void Move_Actor_Forward(){
			var actor = new Main.Actor.Entity.Actor("123");
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
			var actor = new Main.Actor.Entity.Actor("123");
			var weapon = new Main.Weapon.Entity.Weapon(30);
			actor.Equip(weapon);
			var actorWeapon = actor.CurrentWeapon;
			Assert.AreEqual(weapon, actorWeapon);
		}
	}
}