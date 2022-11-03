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
    private bool isClear;
    void Start()
    {
        StartCoroutine(FadeInOut());
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
                if (hit.collider.gameObject == spawnObject[GameManager.instance.clearIdx])
                    SceneManager.LoadScene("InGame");
            }
        }
    }
    void SpawnObejct()
    {
        for (int i = GameManager.instance.clearIdx; i < maxCount; i++)
        {
            spawnObject[i].SetActive(true);
        }
        if (GameManager.instance.isClear == true)
        {
            StartCoroutine(HamerSwing());
            if (GameManager.instance.clearIdx++ >= 4)
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
