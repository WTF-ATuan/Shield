﻿using System;
using Script.Main.Actor.Repository;
using Script.Main.Actor.UseCase;
using UnityEngine;

namespace Script.Main.Actor.Component{
	public class ActorViewControl : MonoBehaviour{
		[SerializeField] private string actorID;

		private ActorRepository _actorRepository;
		private ActorUseCase _actorUseCase;

		private void Start(){
			_actorRepository = new ActorRepository();
			_actorUseCase = new ActorUseCase(_actorRepository);
			actorID = Guid.NewGuid().ToString();
			_actorUseCase.CreateActor(actorID);
		}

		private void Update(){
			var horizontalValue = Input.GetAxisRaw("Horizontal");
			var verticalValue = Input.GetAxisRaw("Vertical");
			var moveValue = new Vector3(horizontalValue, 0, verticalValue);
			_actorUseCase.MoveActor(actorID, moveValue);
		}
	}
}