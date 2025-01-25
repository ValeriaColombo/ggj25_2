using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private BasicCameraTracker camera;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform character;

    public UnityEvent<int> OnFinishGame { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        OnFinishGame = new UnityEvent<int>();

        StartLevel();
    }

    private void StartLevel()
    {
        character.position = startPoint.position;
    }

    public void Get2ndChance()
    {
        Debug.Log("You did it!");
        SceneManager.LoadScene("Win");
    }

    public void OnFinishGameBtnClick(int points)
    {
        OnFinishGame.Invoke(points);
    }
}
