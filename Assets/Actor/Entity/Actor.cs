using System;
using System.Collections.Generic;
using System.Linq;
using Actor.Entity.Behavior;
using Actor.ResponseDTO;

namespace Actor.Entity{
	public class Actor{
		public string ActorID{ get; }

		private readonly List<IActorMoveCondition> _moveConditions = new();
		private ActorMoveData _moveData;

		public Actor(string actorID){
			ActorID = actorID;
		}

		public void Move(float horizontal, float vertical, bool isJump){
			if(_moveConditions.Count < 1){
				var defaultMoveData = new ActorMoveData(horizontal, vertical, isJump);
				_moveData = defaultMoveData;
			}

			var moveDataList = new List<ActorMoveData>();
			foreach(var moveCondition in _moveConditions){
				moveCondition.Condition(horizontal, vertical, isJump);
				var moveData = moveCondition.GetConditionData();
				moveDataList.Add(moveData);
				_moveData = moveData;
			}

			var canJump = moveDataList.Any(x => x.IsJump == true);
			if(!canJump){
				_moveData.IsJump = false;
			}
		}

		public ActorMoveData GetMoveData(){
			return _moveData;
		}

		public void AddMoveCondition(IActorMoveCondition actorMoveCondition){
			var contains = _moveConditions.Contains(actorMoveCondition);
			if(contains) throw new Exception("Condition is Same");
			_moveConditions.Add(actorMoveCondition);
		}

		public void RemoveMoveCondition(IActorMoveCondition actorMoveCondition){
			var contains = _moveConditions.Contains(actorMoveCondition);
			if(!contains) throw new Exception("Condition is Not Found");
			_moveConditions.Remove(actorMoveCondition);
		}
	}
}