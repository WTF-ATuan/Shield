using NUnit.Framework;
using Script.Main.Actor.Repository;
using Script.Main.Actor.UseCase;

namespace Script.MainTest.Actor{
	public class ActorUseCaseTest{
		[Test]
		public void Create_Actor(){
			var actorUseCase = new ActorUseCase();
			var actor = actorUseCase.CreateActor("123");
			Assert.NotNull(actor);
		}

		[Test]
		public void Actor_Created_Should_Add_To_Repository(){
			var actorUseCase = new ActorUseCase();
			var actorRepository = new ActorRepository();
			var actor = actorUseCase.CreateActor("123");
			actorRepository.Save(actor);
			var actorCount = actorRepository.ActorCount;
			Assert.GreaterOrEqual(actorCount, 1);
		}
	}
}