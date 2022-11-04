using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject p;
    [SerializeField] Image i;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    void Start()
    {
        for(int ia = 0;ia < sprites.Count;ia++)
        {
            Image ii = Instantiate(i, p.transform);
            i.sprite = sprites[ia];
        }
    }
}
