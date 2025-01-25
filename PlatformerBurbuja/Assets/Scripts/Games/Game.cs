using System;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private BasicCameraTracker camera;
    [SerializeField] private JustOnceTrigger startFallingTrigger;
    [SerializeField] private JustOnceTrigger animatePurgatoryChangeTrigger;
    [SerializeField] private JustOnceTrigger finishFallingTrigger;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform character;

    [SerializeField] private GameObject AliveAnimator;
    [SerializeField] private GameObject DeadAnimator;

    public UnityEvent<int> OnFinishGame { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        OnFinishGame = new UnityEvent<int>();

        StartLevel();
    }

    private void StartsFall()
    {
        startFallingTrigger.onTrigger.RemoveAllListeners();
        camera.ChangeCameraBounds(13.5f, 13.5f, -82.5f, 4.7f);
    }

    private void StartLevel()
    {
        AliveAnimator.SetActive(true);
        DeadAnimator.SetActive(false);

        startFallingTrigger.gameObject.SetActive(true);
        startFallingTrigger.onTrigger.AddListener(StartsFall);

        animatePurgatoryChangeTrigger.gameObject.SetActive(true);
        animatePurgatoryChangeTrigger.onTrigger.AddListener(AnimateGoingToPurgatory);        

        finishFallingTrigger.gameObject.SetActive(true);
        finishFallingTrigger.onTrigger.AddListener(FinishesFall);

        camera.ChangeCameraBounds(-0.5f, 18.5f, 4.7f, 4.7f);
        character.position = startPoint.position;
    }

    public void Get2ndChance()
    {
        Debug.Log("You did it!");
        StartLevel();
    }

    private void AnimateGoingToPurgatory()
    {
        animatePurgatoryChangeTrigger.onTrigger.RemoveAllListeners();
        AliveAnimator.SetActive(false);
        DeadAnimator.SetActive(true);
    }

    private void FinishesFall()
    {
        finishFallingTrigger.onTrigger.RemoveAllListeners();
        camera.ChangeCameraBounds(20f, 78f, -82.5f, -36f);
    }

    public void OnFinishGameBtnClick(int points)
    {
        OnFinishGame.Invoke(points);
    }
}
