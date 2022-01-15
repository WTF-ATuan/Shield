namespace Project.Event{
	public class MouseInputDetected{
		public bool IsRight{ get; }
		public bool RightMouseButtonDown{ get; }
		public bool RightMouseButton{ get; }
		public bool RightMouseButtonUp{ get; }

		public MouseInputDetected(bool isRight, bool rightMouseButtonDown, bool rightMouseButton,
			bool rightMouseButtonUp){
			IsRight = isRight;
			RightMouseButtonDown = rightMouseButtonDown;
			RightMouseButton = rightMouseButton;
			RightMouseButtonUp = rightMouseButtonUp;
		}
	}
}