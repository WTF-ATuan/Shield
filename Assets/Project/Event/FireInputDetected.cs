namespace Project.Event{
	public class FireInputDetected{
		public bool IsRight{ get; }
		public bool MouseButtonDown{ get; }
		public bool MouseButton{ get; }
		public bool MouseButtonUp{ get; }

		public FireInputDetected(bool isRight, bool mouseButtonDown, bool mouseButton,
			bool mouseButtonUp){
			IsRight = isRight;
			MouseButtonDown = mouseButtonDown;
			MouseButton = mouseButton;
			MouseButtonUp = mouseButtonUp;
		}
	}
}