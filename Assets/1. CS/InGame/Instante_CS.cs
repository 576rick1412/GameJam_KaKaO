using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instante_CS : MonoBehaviour
{
    GameManager gm = GameManager.instance;
    [SerializeField] GameObject[] Stage;
    private void Awake() { Stage[gm.clearIdx].SetActive(true); }
    
}
