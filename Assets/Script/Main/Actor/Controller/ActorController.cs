using System.Collections.Generic;

namespace Script.Main.Actor.Controller{
	public class ActorController{
		public IRepository Repository{ get; }
		public IList<IUseCase> UseCases{ get; }

		public ActorController(IRepository repository, IList<IUseCase> useCases){
			Repository = repository;
			UseCases = useCases;
		}

		public ActorController(){ }
		
		
		
	}

	public interface IUseCase{ }

	public interface IRepository{ }
}