using System;
using System.Collections.Generic;
using System.Linq;
using Actor.Entity.Behavior;
using Actor.ResponseDTO;

namespace Actor.Entity{
	public class Actor{
		public string ActorID{ get; }

		private readonly List<IActorMoveCondition> _moveConditions = new List<IActorMoveCondition>();

		public Actor(string actorID){
			ActorID = actorID;
		}

		public void Move(float horizontal, float vertical, bool isJump){
			foreach(var moveCondition in _moveConditions){
				moveCondition.Condition(horizontal, vertical, isJump);
			}
		}

		public ActorMoveData GetMoveData(){
			var moveDataList = _moveConditions.Select(moveCondition => moveCondition.GetConditionData()).ToList();
			// ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
			foreach(var moveData in moveDataList){
				var horizontal = moveData.Horizontal;
				var vertical = moveData.Vertical;
				var isJump = moveData.IsJump;
				if(horizontal == 0 || vertical == 0 || !isJump){
					return moveData;
				}
			}

			var firstMoveData = moveDataList.First();
			return firstMoveData;
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