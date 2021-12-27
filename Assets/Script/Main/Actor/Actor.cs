using System.Collections.Generic;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor{
	public class Actor{
		private List<CustomEvent> eventBufferList;

		private void SaveEvent<T>(T eventData) where T : CustomEvent{ }

		public List<T> GetEvent<T>() where T : CustomEvent{
			return null;
		}
		

		public void Move(Vector3 direction){ }
	}
}