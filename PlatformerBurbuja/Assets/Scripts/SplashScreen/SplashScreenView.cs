using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenView : MonoBehaviour
{
    void Start()
    {
        Context.Instance.Hello();
    }

    public void Continue()
    {
        SceneManager.LoadScene("Home");
    }
}
