using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get; private set; }
    public bool isClear;
    public int clearIdx;

    //���̵� �� �ƿ�
    [Header("���̵� �� �ƿ�")]
    public Image Panel; // ������ ȭ���� �� ä��� �̹��� / �ʼ�
    public float F_time = 0.2f; // ���̵� �ð�
    float FM_time = 0f; // �ǵ�����!!
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fade()
    {
        StartCoroutine(FadeEffect());
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

    IEnumerator FadeEffect()
    {
        Panel.gameObject.SetActive(true);
        FM_time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            FM_time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, FM_time);
            Panel.color = alpha;

            yield return null;
        }

        FM_time = 0f;
        yield return null;


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
    IEnumerator FadeEffect(GameObject CurObj, GameObject NextObj)
    {
        Panel.gameObject.SetActive(true);
        FM_time = 0f;
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
        FM_time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
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