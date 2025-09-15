using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class LiveManager : MonoBehaviour
{
    public static LiveManager Instance { get; private set; }

    private int playerLives;
    [SerializeField] private int currentLives;

    // References.
    public TMP_Text livesText;
    public CanvasGroup panelGameOver;
    public Image live1, live2, live3;

    void Awake()
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

    void Start()
    {
        playerLives = GameConfig.Instance.PlayerLives;
        currentLives = playerLives;

        live1.color = Color.white;
        // live1.color.alpha = 1f;

        live2.color = Color.white;
        // live2..color.alpha = 1f;

        live3.color = Color.white;
        // live3..color.alpha = 1f;
    }

    public void ReduceLives()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            currentLives = 0;
            GameOver();
        }

        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        if (currentLives == 2)
        {
            live3.DOFade(0.15f, 0.5f);
        }
        else if (currentLives == 1)
        {
            live2.DOFade(0.15f, 0.5f);
        }
        else if (currentLives == 0)
        {
            live1.DOFade(0.15f, 0.5f);
        }
    }

    private void GameOver()
    {
        GameManager.Instance.DestroyAllEnemy();
        Spawner.Instance.StopSpawning();
        
        if (panelGameOver != null)
        {
            ScoreManager.Instance.CalculateEndGameScore();

            panelGameOver.DOFade(1, 0.5f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                panelGameOver.interactable = true;
                panelGameOver.blocksRaycasts = true;
            });
        }
    }

    public void RetryGame()
    {
        currentLives = playerLives;
        UpdateLivesText();
    }
}
