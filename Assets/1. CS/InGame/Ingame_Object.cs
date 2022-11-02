using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ingame_Object : MonoBehaviour, IDragHandler,IDropHandler,IBeginDragHandler
{
    // 캔버스에서 해당 오브젝트의 이미지 넘버를 입력
    [SerializeField] int object_Number;

    // 제 위치에 놓을 시 참이 되며, 드래그가 불가능 하도록
    bool AllowDrag;

    GameObject UP_Canvas;
    GameObject Image_Hub;

    Image Image;
    RectTransform rect;
    private void Start()
    {
        Image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        UP_Canvas = GameObject.FindWithTag("UP_Canvas");
        Image_Hub = GameObject.FindWithTag("Image_Hub");
    }

    private void Update() { if (AllowDrag) Image.raycastTarget = false; }  // 드래그중 다른 오브젝트가 눌리지 않도록

    public void OnDrag() { if (AllowDrag) return; All_In_One.ALO.Drag_Image(object_Number); }
    public void OnDrop() { if (AllowDrag) return; AllowDrag = All_In_One.ALO.Drop_Image(object_Number); }

    public void OnDrag(PointerEventData eventData)
    {
        OnDrag();
        //throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDrop();
        rect.SetParent(Image_Hub.transform);
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.SetParent(UP_Canvas.transform);
        //throw new System.NotImplementedException();
    }
}