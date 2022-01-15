using Project.Event;
using UnityEngine;

namespace Project.Component{
	public class InputDetector : MonoBehaviour{
		private void Update(){
			DetectMoveInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			var isJump = Input.GetKeyDown(KeyCode.Space);
			var moveInputDetected = new MoveInputDetected(horizontalValue , verticalValue , isJump);
			EventBus.Post(moveInputDetected);
		}
		
	}
}