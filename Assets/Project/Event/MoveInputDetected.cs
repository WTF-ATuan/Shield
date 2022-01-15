namespace Project.Event{
	public class MoveInputDetected{
		public float HorizontalValue{ get; }
		public float VerticalValue{ get; }
		public bool IsJump{ get; }

		public MoveInputDetected(float horizontalValue ,float verticalValue, bool isJump){
			HorizontalValue = horizontalValue;
			VerticalValue = verticalValue;
			IsJump = isJump;
		}
	}
}