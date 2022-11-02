using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageEffcet : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private int maxCount;
    [SerializeField] private GameObject hamerObjcet;
    void Start()
    {
        StartCoroutine(FadeInOut());
        for (int i = GameManager.instance.clearIdx;i<maxCount;i++)
        {
            spawnObject[i].SetActive(true);
        }
        if (GameManager.instance.isClear == false)
        {
            StartCoroutine(HamerSwing());
        }
    }
    private IEnumerator FadeInOut()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.Fade(false);
    }
    private IEnumerator HamerSwing()
    {
        yield return new WaitForSeconds(2f);
        hamerObjcet.transform.DORotate(new Vector3(0, 180, 0), 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
