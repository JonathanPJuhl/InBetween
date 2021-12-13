using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
  

    public void FadeIn(GameObject blackoutSqr)
    {
        Debug.Log(blackoutSqr.ToString());
        StartCoroutine(FadeToBlack(blackoutSqr));
    }

    public void FadeOut(GameObject blackoutSqr)
    {
        StartCoroutine(FadeToBlack(blackoutSqr, false));
    }

    public IEnumerator FadeToBlack(GameObject blackoutSqr, bool fadeToBlack = true, int fadespeed = 1)
    {
        Color objColor = blackoutSqr.GetComponent<Image>().color;
        float fadeAmt;

        if(fadeToBlack)
        {
            while (blackoutSqr.GetComponent<Image>().color.a < 1)
            {
                fadeAmt = objColor.a + (fadespeed * Time.deltaTime);

                objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmt);
                blackoutSqr.GetComponent<Image>().color = objColor;
                yield return null;
            }
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            while (blackoutSqr.GetComponent<Image>().color.a > 0)
            {
                fadeAmt = objColor.a - (fadespeed * Time.deltaTime);

                objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmt);
                blackoutSqr.GetComponent<Image>().color = objColor;
                yield return null;
            }
            
        }
    }
}
