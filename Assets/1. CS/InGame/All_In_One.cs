using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class All_In_One : MonoBehaviour
{
    public static All_In_One ALO;

    // 원활한 사용을 위해 모래 / 체크 오브젝트의 레이케스트 타겟을 꺼놔야함
    [SerializeField] float DistanceRange = 0; // 드롭 좌표 허용 범위

    [SerializeField] GameObject[] Image_Objects; //이동오브제
    [SerializeField] GameObject[] Set_Objects; // 빈칸
    // [SerializeField] GameObject[] SetImage; // 빈칸에 놓으면 나오는 이미지
    [SerializeField] int Check_Num = 0; //성공한 수
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

            // 안보이게 해주는 마 ★ 법
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
        // 이동오브제(GameObject)와 빈칸좌표(target)의 OBJ_order[n]번째와의 거리가 Null_Num보다 작다면 true 멀다면 false
        float Distance = Vector3.Distance(Image_Objects[i].transform.position, Set_Objects[i].transform.position);
        if (Distance < DistanceRange)
        {
            if (Image_Objects.Length <= Check_Num)
            {
                // 마지막 조각을 놓았을 때
                // 대충 이쯤에 클리어 창이 뜨도록 추가
                Debug.Log("클리어");
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
