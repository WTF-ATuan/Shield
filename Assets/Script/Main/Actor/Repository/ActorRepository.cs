using System;
using System.Collections.Generic;

namespace Script.Main.Actor.Repository{
	public class ActorRepository{
		private readonly List<Entity.Actor> _actorList = new List<Entity.Actor>();

		public void Save(Entity.Actor actor){
			if(actor == null) throw new NullReferenceException($"Can,t Save Empty Actor");
			_actorList.Add(actor);
		}

		public int ActorCount => _actorList.Count;
	}
}