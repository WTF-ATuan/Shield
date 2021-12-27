using System;
using System.Collections.Generic;
using System.Linq;

namespace Script.Main.Utility.Base{
	public abstract class AggregateRoot : IAggregateRoot{
		private readonly Dictionary<Type, List<CustomEvent>> _eventBuffer = new Dictionary<Type, List<CustomEvent>>();

		protected void SaveEvent<T>(T eventData) where T : CustomEvent{
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

		public bool RemoveEvent<T>(){
			var type = typeof(T);
			var containsKey = _eventBuffer.ContainsKey(type);
			if(!containsKey) return false;
			_eventBuffer[type].Clear();
			return true;
		}

		public void RemoveAllEvent(){
			_eventBuffer.Clear();
		}
	}

	public interface IAggregateRoot{
		List<T> GetEvent<T>() where T : CustomEvent;
		bool RemoveEvent<T>();
		void RemoveAllEvent();
	}
}