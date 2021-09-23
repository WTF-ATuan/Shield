using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadDrawer : MonoBehaviour{
		private LineRenderer lineRenderer;
		private void Start(){
			lineRenderer = GetComponent<LineRenderer>();
			EventBus.Subscribe<RaycastData>(DrawSpiderThread);
		}

		private void DrawSpiderThread(RaycastData obj){
			var vertexPosition = new[]{ obj.OriginPosition, obj.AttachPosition };
			lineRenderer.SetPositions(vertexPosition);
		}
		
		
		
	}
}