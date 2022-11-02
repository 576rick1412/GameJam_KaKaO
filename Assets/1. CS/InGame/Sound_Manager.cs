using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager SM;

    [SerializeField] GameObject Clear_Sound; 
    [SerializeField] GameObject Button_Sound; 
    [SerializeField] GameObject Right_Sound; 
    [SerializeField] GameObject Wrong_Sound;

    void Awake() { SM = this; }

    public void Clear()  { GameObject Sound = Instantiate(Clear_Sound);  Destroy(Sound.gameObject, 1f); }
    public void Button() { GameObject Sound = Instantiate(Button_Sound); Destroy(Sound.gameObject, 1f); }
    public void Right()  { GameObject Sound = Instantiate(Right_Sound);  Destroy(Sound.gameObject, 1f); }
    public void Wrong()  { GameObject Sound = Instantiate(Wrong_Sound);  Destroy(Sound.gameObject, 1f); }
}