using System;
using System.Collections.Generic;
using System.Linq;
using Actor.Entity.Behavior;
using Actor.ResponseDTO;
using UnityEngine;

namespace Actor.Entity{
	public class Actor{
		public string ActorID{ get; }

		private readonly List<IActorMoveCondition> _moveConditions = new();
		private ActorMoveData _moveData;
		private ActorDirectionData _directionData;

		public Actor(string actorID){
			ActorID = actorID;
		}

		public void Move(float horizontal, float vertical, bool isJump){
			if(_moveConditions.Count < 1){
				var defaultMoveData = new ActorMoveData(horizontal, vertical, isJump);
				_moveData = defaultMoveData;
				return;
			}

			var moveDataList = new List<ActorMoveData>();
			foreach(var moveCondition in _moveConditions){
				moveCondition.Condition(horizontal, vertical, isJump);
				var moveData = moveCondition.GetConditionData();
				moveDataList.Add(moveData);
				_moveData = moveData;
			}

			var notJump = moveDataList.Any(x => x.IsJump == false);
			if(notJump){
				_moveData.IsJump = false;
			}
		}

		public void ChangeFaceDirection(Vector3 targetPosition){
			var targetDirection = targetPosition.normalized;
			var targetStrength = targetPosition.magnitude;
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