using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEffcet : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private int maxCount;
    [SerializeField] private GameObject hamerObjcet;
    void Start()
    {
        for(int i = GameManager.instance.clearIdx;i<maxCount;i++)
        {
            spawnObject[i].SetActive(true);
        }
        if (GameManager.instance.isClear == false)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
