using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// MainMenu class handles the main menu functionality of the game.
/// It is responsible for managing UI elements and transitions within the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    [Header("UI References")]
    public Button btnStart;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ActionStart()
    {
        SceneLoader.Instance.LoadScene(Constants.GAME_SCENE);
    }

    public void ActionMenu()
    {
        SceneLoader.Instance.LoadScene(Constants.MAIN_MENU_SCENE);
    }

    public void ActionQuit()
    {
        Application.Quit();
    }
}
