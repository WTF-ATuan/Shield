using UnityEngine;

namespace Script.Main.SpiderAbility{
	public class SpiderThreadDrawer : MonoBehaviour{
		private LineRenderer lineRenderer;

		private void Start(){
			lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.positionCount = 2;
			EventBus.Subscribe<SpiderTreadCreated>(OnSpiderThreadCreated);
			EventBus.Subscribe<SpiderTreadUpdated>(OnSpiderThreadUpdated);
		}

		private void OnSpiderThreadUpdated(SpiderTreadUpdated obj){
			var originPosition = obj.OriginPosition;
			var attachPosition = obj.AttachPosition;
			DrawSpiderThread(originPosition, attachPosition);
		}


		private void OnSpiderThreadCreated(SpiderTreadCreated obj){
			var originPosition = obj.OriginPosition;
			var attachPosition = obj.AttachPosition;
			DrawSpiderThread(originPosition, attachPosition);
		}

		private void DrawSpiderThread(Vector3 originPosition, Vector3 attachPosition){
			var vertexPosition = new[]{ originPosition, attachPosition };
			lineRenderer.SetPositions(vertexPosition);
		}
	}
}