using NUnit.Framework;
using Script.Main.Actor;
using Script.Main.Actor.Event;
using UnityEngine;

namespace Script.MainTest{
	public class ActorTest{
		[Test]
		public void Move_Actor_Forward(){
			var actor = new Actor();
			var forwardDirection = Vector3.forward;
			actor.Move(forwardDirection);
			var actorMovedEvents = actor.GetEvent<ActorMoved>();
			var eventCount = actorMovedEvents.Count;
			Assert.NotZero(eventCount);
		}
	}
}