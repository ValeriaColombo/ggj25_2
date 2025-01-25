using System;
using UnityEngine.SceneManagement;

public class GameScreenPresenter : ClassWithContext
{
    protected GameScreenView view;
    protected bool isPaused;
    private Game gameplay;

    public GameScreenPresenter(GameScreenView view, Game gameplay)
    {
        Context.Instance.Hello();
        this.view = view;
        isPaused = false;

        this.gameplay = gameplay;
        this.gameplay.OnFinishGame.AddListener(OnGameOver);

        MySoundManager.PlayMusicLoop("Sound/music01");
    }

    private void OnGameOver(int points)
    {
        view.ShowGameOverPopup(points);
    }

    public void Pause()
    {
        isPaused = true;
        MySoundManager.PauseAll();
    }

    public void Resume()
    {
        isPaused = false;
        MySoundManager.ResumeAll();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
