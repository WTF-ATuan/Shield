namespace Actor.ResponDTO{
	public class ActorMoveData{
		public float Horizontal{ get; set; }
		public float Vertical{ get; set; }
		public bool IsJump{ get; set; }

		public ActorMoveData(float horizontal, float vertical, bool isJump){
			Horizontal = horizontal;
			Vertical = vertical;
			IsJump = isJump;
		}

		public ActorMoveData(){ }
	}
}