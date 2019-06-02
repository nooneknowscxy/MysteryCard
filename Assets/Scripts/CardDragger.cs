using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{

	public Camera mainCamera;
	public RectTransform canvasRect, startRectTrans;
	private Image cardImg;
	private Vector2 startDragPos, stopDragPos;
	[SerializeField]
	private float radius, targetAngel;
	public float maxAngel = 15.0f, angelDamp = 0.5f, offest = 3.0f, dragOffsetDis, maxOffset = 5.0f;
	private bool isDrag2Right;
	private void Start() {
		cardImg = GetComponent<Image>();
		radius = Mathf.Abs(cardImg.rectTransform.anchoredPosition.y);
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        startDragPos = new Vector2(startRectTrans.anchorMin.x, 0.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {	
		//将屏幕坐标转化为UI坐标
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, mainCamera, out stopDragPos);
		float dragDistance = Mathf.Abs(stopDragPos.x - startDragPos.x);
		dragOffsetDis = dragDistance * offest;
		targetAngel = Mathf.Atan(dragDistance / radius) * 180.0f;
		targetAngel = Mathf.Clamp(targetAngel, 0.0f, maxAngel);
		dragOffsetDis = Mathf.Clamp(dragOffsetDis, 0.0f, maxOffset);
		isDrag2Right = mainCamera.ScreenToWorldPoint(Input.mousePosition).x > 0;
		
		//旋转卡面
		cardImg.rectTransform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, targetAngel * angelDamp * (isDrag2Right ? -1 : 1)));
		//偏移卡面
		cardImg.rectTransform.anchoredPosition = new Vector2(dragOffsetDis * (isDrag2Right ? 1 : -1), cardImg.rectTransform.anchoredPosition.y);
	}

    public void OnEndDrag(PointerEventData eventData)
    {
		isDrag2Right = mainCamera.ScreenToWorldPoint(Input.mousePosition).x > 0;
        StartCoroutine(RecoverAnim());
    }

	IEnumerator RecoverAnim(){
		//每一步恢复的偏移量
		float recoverPerFrame = dragOffsetDis;
		while(targetAngel > 0.0f){
			yield return null;
			targetAngel -= 1;
			recoverPerFrame -= dragOffsetDis / targetAngel;
			recoverPerFrame = Mathf.Clamp(recoverPerFrame, 0.0f, dragOffsetDis);
			cardImg.rectTransform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, targetAngel * angelDamp * (isDrag2Right ? -1 : 1)));
			cardImg.rectTransform.anchoredPosition = new Vector2(recoverPerFrame * (isDrag2Right ? 1 : -1), cardImg.rectTransform.anchoredPosition.y);
		}
		//恢复初始值
		dragOffsetDis = 0.0f;
		targetAngel = 0.0f;
	}
}
