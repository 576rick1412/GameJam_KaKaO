using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class All_In_One : MonoBehaviour
{
    public static All_In_One ALO;
    GameManager gm = GameManager.instance;

    [Header("클리어 오브젝트")][SerializeField] GameObject ClearObbj;

    // 원활한 사용을 위해 모래 / 체크 오브젝트의 레이케스트 타겟을 꺼놔야함
    [Header("드롭 좌표 허용 범위")][SerializeField] float DistanceRange = 0; // 드롭 좌표 허용 범위

    [Header("시간 표시")] [SerializeField] TextMeshProUGUI Time_Text;
    private float CurTime;

    int Check_Num = 0; //성공한 수
    [SerializeField] TextMeshProUGUI Piece_Amount;
    bool Game_Claer;

    [Header("오브젝트")]
    [SerializeField] GameObject[] Image_Objects; //이동오브제
    [SerializeField] GameObject[] Set_Objects; // 빈칸
    public Vector3[] target_POS;


    void Awake()
    {
        ALO = this;

        ClearObbj.SetActive(false);
        Game_Claer = false;
        CurTime = 0f;
        Check_Num = 0;

        for (int i = 0; i < Image_Objects.Length; i++)
        {
            Array.Resize(ref target_POS, target_POS.Length + 1);
            target_POS[i] = Image_Objects[i].transform.position;
        }
    }
    void Update()
    {
        if(!Game_Claer) CurTime += Time.deltaTime * 1;

        if((int)CurTime % 60 >= 10) { Time_Text.text = ((int)CurTime / 60).ToString() + " : " + ((int)CurTime % 60).ToString(); }
        else Time_Text.text = ((int)CurTime / 60).ToString() + " : 0" + ((int)CurTime % 60).ToString();

        Piece_Amount.text = (Image_Objects.Length - Check_Num).ToString();

    }
    public void Drag_Image(int i)
    {
        
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f);
        Image_Objects[i].transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
    public bool Drop_Image(int i)
    {
        float Distance = Vector3.Distance(Image_Objects[i].transform.position, Set_Objects[i].transform.position);
        if (Distance < DistanceRange)
        {
            if (Image_Objects.Length - 1 <= Check_Num)
            {
                // 마지막 조각을 놓았을 때
                // 대충 이쯤에 클리어 창이 뜨도록 추가
                ClearObbj.SetActive(true);
                gm.isClear = true;
                Game_Claer = true;
                StartCoroutine("scenemove");
                Debug.Log("클리어");
                Sound_Manager.SM.Clear();
            }

            Check_Num++;
            if (Image_Objects.Length - 1 >= Check_Num) Sound_Manager.SM.Right();
            Image_Objects[i].transform.position = Set_Objects[i].transform.position;
            return true;
        }
        Sound_Manager.SM.Wrong();
        return false;
    }
    IEnumerator scenemove()
    {
        yield return new WaitForSeconds(4f);
        GameManager.instance.Fade(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Title");
    }
}
