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
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    private void GameOver()
    {
        GameManager.Instance.DestroyAllEnemy();
        Spawner.Instance.StopSpawning();
        
        if (panelGameOver != null)
        {
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
