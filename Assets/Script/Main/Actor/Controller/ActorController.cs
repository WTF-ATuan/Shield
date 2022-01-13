using System.Collections.Generic;

namespace Script.Main.Actor.Controller{
	public class ActorController<TR> where TR : IRepository{
		private IRepository Repository{ get; }
		private IList<IUseCase<TR>> UseCases{ get; }

		public ActorController(IRepository repository, IList<IUseCase<TR>> useCases){
			Repository = repository;
			UseCases = useCases;
		}
		
	}

	public interface IUseCase<TR> where TR : IRepository{ }

	public interface IRepository{ }
}