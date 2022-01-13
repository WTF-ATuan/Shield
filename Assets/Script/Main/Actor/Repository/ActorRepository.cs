using System;
using System.Collections.Generic;
using Script.Main.Actor.Controller;

namespace Script.Main.Actor.Repository{
	public class ActorRepository : IRepository{
		private readonly List<Entity.Actor> _actorList = new List<Entity.Actor>();

		public void Save(Entity.Actor actor){
			if(actor == null) throw new NullReferenceException($"Can,t Save Empty Actor");
			_actorList.Add(actor);
		}

		public int ActorCount => _actorList.Count;

		public Entity.Actor Find(string uid){
			var actor = _actorList.Find(actor => actor.Uid == uid);
			return actor;
		}
	}
}