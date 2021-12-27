using System;
using System.Collections.Generic;
using System.Linq;
using Script.Main.Actor.Event;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor{
	public class Actor{
		private readonly Dictionary<Type, List<CustomEvent>> _eventBuffer = new Dictionary<Type, List<CustomEvent>>();

		private void SaveEvent<T>(T eventData) where T : CustomEvent{
			var eventType = typeof(T);
			var containsKey = _eventBuffer.ContainsKey(eventType);
			if(containsKey){
				_eventBuffer[eventType].Add(eventData);
			}
			else{
				var customEvents = new List<CustomEvent>{ eventData };
				_eventBuffer.Add(eventType, customEvents);
			}
		}

		public List<T> GetEvent<T>() where T : CustomEvent{
			var eventType = typeof(T);
			var containsKey = _eventBuffer.ContainsKey(eventType);
			if(containsKey){
				var customEvents = _eventBuffer[eventType];
				var typeEvents = customEvents.Cast<T>().ToList();
				return typeEvents;
			}
			var events = new List<T>();
			return events;
		}


		public void Move(Vector3 direction){
			var actorMoved = new ActorMoved(direction);
			SaveEvent(actorMoved);
		}
	}
}