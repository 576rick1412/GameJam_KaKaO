using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title1 : MonoBehaviour
{
    [SerializeField] Image titleImage;
    private bool isclick;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isclick == false)
        {
            StartCoroutine(Fade());

            isclick = true;
        }
    }
    IEnumerator Fade()
    {
        float timer = 1;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            titleImage.color = new Color(timer, timer, timer);
            yield return null;
        }
        SceneManager.LoadScene("Title");
    }
}
