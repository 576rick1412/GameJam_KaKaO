using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class All_In_One : MonoBehaviour
{
    public static All_In_One ALO;

    // ��Ȱ�� ����� ���� �� / üũ ������Ʈ�� �����ɽ�Ʈ Ÿ���� ��������
    [SerializeField] float DistanceRange = 0; // ��� ��ǥ ��� ����

    [SerializeField] GameObject[] Image_Objects; //�̵�������
    [SerializeField] GameObject[] Set_Objects; // ��ĭ
    // [SerializeField] GameObject[] SetImage; // ��ĭ�� ������ ������ �̹���
    [SerializeField] int Check_Num = 0; //������ ��
    [SerializeField] Vector2[] target_POS;

    RectTransform rect;

    void Awake()
    {
        ALO = this;
        Check_Num = 0;

        for (int i = 0; i < Image_Objects.Length; i++)
        {
            Array.Resize(ref target_POS, target_POS.Length + 1);
            target_POS[i] = Image_Objects[i].transform.position;

            // �Ⱥ��̰� ���ִ� �� �� ��
            // Image_Objects[i].SetActive(false);
            // SetImage[i].SetActive(false);
        }
    }
    void Update()
    {

    }

    public void Drag_Image(int i)
    {
        var screenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Image_Objects[i].transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
    public bool Drop_Image(int i)
    {
        // �̵�������(GameObject)�� ��ĭ��ǥ(target)�� OBJ_order[n]��°���� �Ÿ��� Null_Num���� �۴ٸ� true �ִٸ� false
        float Distance = Vector3.Distance(Image_Objects[i].transform.position, Set_Objects[i].transform.position);
        if (Distance < DistanceRange)
        {
            if (Image_Objects.Length <= Check_Num)
            {
                // ������ ������ ������ ��
                // ���� ���뿡 Ŭ���� â�� �ߵ��� �߰�
                Debug.Log("Ŭ����");
            }
            Check_Num++;
            // SetImage[i].SetActive(true); // ==================
            //Destroy(Image_Objects[i]);

            Image_Objects[i].transform.position = Set_Objects[i].transform.position;

            Destroy(Set_Objects[i]); return true;
        }
        Image_Objects[i].transform.position = target_POS[i];
        return false;
    }
}
