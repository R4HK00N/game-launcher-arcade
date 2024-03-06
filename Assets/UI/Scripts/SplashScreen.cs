using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(GoToBrowser());
    }
    public IEnumerator GoToBrowser()
    {
        yield return new WaitForSeconds(3.1f);
        SceneManager.LoadScene(1);
    }
}
