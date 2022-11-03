using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StageEffcet : MonoBehaviour
{
    [SerializeField] private GameObject clearPanel;

    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private GameObject hamerObjcet;

    [SerializeField] private int maxCount;
    private int clearCount;
    private bool isClear;
    void Start()
    {
        StartCoroutine(FadeInOut());
        clearCount = GameManager.instance.clearIdx;
        SpawnObejct();
    }
    private void Update()
    {
        ClickStage();
    }
    void ClickStage()
    {
        if (!isClear && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == spawnObject[clearCount])
                    SceneManager.LoadScene("InGame");
            }
        }
    }
    void SpawnObejct()
    {
        for (int i = clearCount; i < maxCount; i++)
        {
            spawnObject[i].SetActive(true);
        }
        if (GameManager.instance.isClear == true)
        {
            StartCoroutine(HamerSwing());
            if(clearCount++ >= 4)
            {
                isClear = true;
            }
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
}
