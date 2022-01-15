using Project.Event;
using UnityEngine;

namespace Project.Component{
	public class InputDetector : MonoBehaviour{
		private void Update(){
			DetectMoveInput();
			DetectRightMouseButton();
			DetectLeftMouseButton();
			DetectMousePosition();
		}

		private void DetectMousePosition(){
			if(Camera.main == null) return;
			var mousePos = Input.mousePosition;
			mousePos.z = Camera.main.nearClipPlane;
			var worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
			worldPosition.z = 0;
			var mousePositionDetected = new MousePositionDetected(worldPosition);
			EventBus.Post(mousePositionDetected);
		}

		private void DetectRightMouseButton(){
			var rightMouseButtonDown = Input.GetMouseButtonDown(0);
			var rightMouseButton = Input.GetMouseButton(0);
			var rightMouseButtonUp = Input.GetMouseButtonUp(0);
			var rightMouseInputDetected =
					new MouseInputDetected(true, rightMouseButtonDown, rightMouseButton, rightMouseButtonUp);
			EventBus.Post(rightMouseInputDetected);
		}

		private void DetectLeftMouseButton(){
			var leftMouseButtonDown = Input.GetMouseButtonDown(1);
			var leftMouseButton = Input.GetMouseButton(1);
			var leftMouseButtonUp = Input.GetMouseButtonUp(1);
			var leftMouseInputDetected =
					new MouseInputDetected(false, leftMouseButtonDown, leftMouseButton, leftMouseButtonUp);
			EventBus.Post(leftMouseInputDetected);
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			var isJump = Input.GetKeyDown(KeyCode.Space);
			var moveInputDetected = new MoveInputDetected(horizontalValue, verticalValue, isJump);
			EventBus.Post(moveInputDetected);
		}
	}
}