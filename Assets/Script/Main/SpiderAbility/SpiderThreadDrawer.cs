using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadDrawer : MonoBehaviour{
		private LineRenderer lineRenderer;

		private void Start(){
			lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.positionCount = 2;
			EventBus.Subscribe<SpiderTreadUpdated>(DrawSpiderThread);
		}

		private void DrawSpiderThread(SpiderTreadUpdated obj){
			var vertexPosition = new[]{ obj.OriginPosition, obj.AttachPosition };
			lineRenderer.SetPositions(vertexPosition);
		}
	}
}