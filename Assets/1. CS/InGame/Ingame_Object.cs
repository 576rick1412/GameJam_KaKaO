using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ingame_Object : MonoBehaviour, IDragHandler,IDropHandler,IBeginDragHandler
{
    // ĵ�������� �ش� ������Ʈ�� �̹��� �ѹ��� �Է�
    [SerializeField] int object_Number;

    // �� ��ġ�� ���� �� ���� �Ǹ�, �巡�װ� �Ұ��� �ϵ���
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

    private void Update() { if (AllowDrag) Image.raycastTarget = false; }  // �巡���� �ٸ� ������Ʈ�� ������ �ʵ���

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