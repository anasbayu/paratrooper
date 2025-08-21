using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CanvasGroup panelPaused;
    public CanvasGroup panelGameOver;
    public CanvasGroup loadingScreen;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PauseGame()
    {

        panelPaused.DOFade(1, 0.2f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            panelPaused.interactable = true;
            panelPaused.blocksRaycasts = true;
            Time.timeScale = 0;
        });
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        panelPaused.DOFade(0, 0.2f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            panelPaused.interactable = false;
            panelPaused.blocksRaycasts = false;
        });
    }

    public void RetryGame()
    {
        Time.timeScale = 1;

        loadingScreen.blocksRaycasts = true;

        loadingScreen.DOFade(1, 0.5f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            panelGameOver.alpha = 0;
            panelGameOver.interactable = false;
            panelGameOver.blocksRaycasts = false;

            loadingScreen.DOFade(0, 0.5f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                loadingScreen.interactable = false;
                loadingScreen.blocksRaycasts = false;

                LiveManager.Instance.RetryGame();
                ScoreManager.Instance.ResetScore();

                Spawner.Instance.StartSpawning();
            });
        });
    }

    public void DestroyAllEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
