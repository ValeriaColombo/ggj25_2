using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostScreen : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("Home");
    }
}
