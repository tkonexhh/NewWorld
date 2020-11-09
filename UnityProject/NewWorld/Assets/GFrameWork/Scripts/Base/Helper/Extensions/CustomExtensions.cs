/************************
	FileName:/GFrameWork/Scripts/Base/Helper/Extensions/CustomExtensions.cs
	CreateAuthor:neo.xu
	CreateTime:11/9/2020 3:08:25 PM
	Tip:11/9/2020 3:08:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class CustomExtensions
    {

        public static Vector3 CalculateScreenPosition(
                    Vector3 position,
                    Camera camera,
                    Canvas canvas,
                    RectTransform transform)
        {
            var screenPos = camera.WorldToScreenPoint(position);

            var pos = Vector3.zero;
            switch (canvas.renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    RectTransformUtility.ScreenPointToWorldPointInRectangle(
                        transform,
                        screenPos,
                        null,
                        out pos);
                    break;
                case RenderMode.ScreenSpaceCamera:
                case RenderMode.WorldSpace:
                    RectTransformUtility.ScreenPointToWorldPointInRectangle(
                        transform,
                        screenPos,
                        canvas.worldCamera,
                        out pos);
                    break;
            }

            return pos;
        }


        public static void ScenePosition2UIPosition(Camera sceneCamera, Camera uiCamera, Vector3 posInScene, Transform uiTarget)
        {
            Vector3 viewportPos = sceneCamera.WorldToViewportPoint(posInScene);
            Vector3 worldPos = uiCamera.ViewportToWorldPoint(viewportPos);
            uiTarget.position = worldPos;
            Vector3 localPos = uiTarget.localPosition;
            localPos.z = 0f;
            uiTarget.localPosition = localPos;
        }

        public static Vector3 UIPosToScenePos(Camera sceneCamera, Camera uiCamera, Vector3 uiPos)
        {
            Vector3 viewPos = uiCamera.WorldToViewportPoint(uiPos);
            Vector3 worldPos = sceneCamera.ViewportToWorldPoint(viewPos);
            worldPos.z = 0;
            return worldPos;
        }
    }

}