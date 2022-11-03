using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get; private set; }
    public bool isClear;
    public int clearIdx;

    //페이드 인 아웃
    [Header("페이드 인 아웃")]
    public Image Panel; // 검은색 화면을 꽉 채우는 이미지 / 필수
    public float F_time = 0.2f; // 페이드 시간
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fade(bool on)
    {
        StartCoroutine(FadeEffect(on));
    }
    public void Fade(GameObject CurObj, GameObject NextObj)
    {
        StartCoroutine(FadeEffect(CurObj, NextObj));
    }
    public void Fade(AsyncOperation op)
    {
        StartCoroutine(FadeEffect(op));
    }

    // ===========================================================================

    IEnumerator FadeEffect(bool on)
    {
        float FM_time = 0f;
        Color alpha = Panel.color;

        if (on)
        {
            Panel.gameObject.SetActive(true);
            while (FM_time < 1f)
            {
                FM_time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, FM_time);
                Panel.color = alpha;

                yield return null;
            }
            yield return null;
        }
        else
        {
            while (FM_time < 1f)
            {
                FM_time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(1, 0, FM_time);
                Panel.color = alpha;

                yield return null;
            }
            Panel.gameObject.SetActive(false);
            yield return null;
        }

      
    }
    IEnumerator FadeEffect(GameObject CurObj, GameObject NextObj)
    {
        Panel.gameObject.SetActive(true);
        float FM_time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            FM_time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, FM_time);
            Panel.color = alpha;

            yield return null;
        }

        FM_time = 0f;
        CurObj.SetActive(false);
        yield return null;  //yield return new WaitForSeconds(L_time);
        NextObj.SetActive(true);


        while (alpha.a > 0f)
        {
            FM_time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, FM_time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator FadeEffect(AsyncOperation op)
    {
        Panel.gameObject.SetActive(true);
        float FM_time = 0f;
        Color alpha = Panel.color;
        while (FM_time < 1f)
        {
            FM_time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, FM_time);
            Panel.color = alpha;

            yield return null;
        }

        FM_time = 0f;
        op.allowSceneActivation = true;
        yield return null;   //yield return new WaitForSeconds(L_time);

        while (alpha.a > 0f)
        {
            FM_time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, FM_time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}