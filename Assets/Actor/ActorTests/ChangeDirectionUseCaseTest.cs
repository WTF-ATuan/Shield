using NUnit.Framework;
using UnityEngine;

namespace Actor.ActorTests{
	public class ChangeDirectionUseCaseTest{
		[Test]
		public void Change_Actor_Face_Direction_Right(){
			var actor = new Entity.Actor("123");
			var positionInput = Vector3.right;
			actor.ChangeDirection(positionInput);
			var actorDirectionData = actor.GetDirectionData();
			var direction = actorDirectionData.Direction;
			var strength = actorDirectionData.Strength;
			Assert.AreEqual(positionInput.normalized , direction);
			Assert.AreEqual(positionInput.magnitude , strength);
		}
	}
}