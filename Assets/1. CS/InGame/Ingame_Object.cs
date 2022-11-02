using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingame_Object : MonoBehaviour
{
    // ĵ�������� �ش� ������Ʈ�� �̹��� �ѹ��� �Է�
    [SerializeField] int object_Number;

    // �� ��ġ�� ���� �� ���� �Ǹ�, �巡�װ� �Ұ��� �ϵ���
    [SerializeField] bool AllowDrag;

    Image Image;
    private void Start() { Image = GetComponent<Image>(); }

    private void Update() { if (AllowDrag) Image.raycastTarget = false; }  // �巡���� �ٸ� ������Ʈ�� ������ �ʵ���

    public void OnDrag() { if (AllowDrag) return; All_In_One.ALO.Drag_Image(object_Number); }
    public void OnDrop() { if (AllowDrag) return; AllowDrag = All_In_One.ALO.Drop_Image(object_Number); }
}