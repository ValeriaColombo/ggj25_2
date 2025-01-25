using System;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private BasicCameraTracker camera;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform character;

    [SerializeField] private GameObject AliveAnimator;

    public UnityEvent<int> OnFinishGame { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        OnFinishGame = new UnityEvent<int>();

        StartLevel();
    }

    private void StartLevel()
    {
        AliveAnimator.SetActive(true);

        camera.ChangeCameraBounds(-0.5f, 79.5f, 4.7f, 4.7f);
        character.position = startPoint.position;
    }

    public void Get2ndChance()
    {
        Debug.Log("You did it!");
        StartLevel();
    }

    public void OnFinishGameBtnClick(int points)
    {
        OnFinishGame.Invoke(points);
    }
}
