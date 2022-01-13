using System.Collections.Generic;

namespace Script.Main.Actor.Controller{
	public class ActorController<TR> where TR : IRepository{
		private IRepository Repository{ get; }
		private IList<IUseCase> UseCases{ get; }

		public ActorController(IRepository repository, IList<IUseCase> useCases){
			Repository = repository;
			UseCases = useCases;
		}
		
	}

	public interface IUseCase{ }

	public interface IRepository{ }
}