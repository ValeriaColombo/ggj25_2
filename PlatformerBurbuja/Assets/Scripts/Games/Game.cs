using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private BasicCameraTracker camera;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform character;
    [SerializeField] private string SceneWhenWin = "Win";
    [SerializeField] private string SceneWhenLost = "Lost";

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
        SceneManager.LoadScene(SceneWhenWin);
    }

    public void GameOver()
    {
        Debug.Log("Ouch!!");
        SceneManager.LoadScene(SceneWhenLost);
    }

    public void OnFinishGameBtnClick(int points)
    {
        OnFinishGame.Invoke(points);
    }
}
