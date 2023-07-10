#region

using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace _Scripts.UI
{
    public class GameLooseUI : UIBase
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private GameObject handle;

        private void Start()
        {
            restartButton.onClick.AddListener(() =>
            {
                // SceneLoader.Instance.LoadMainMenuScene();
                InvokeOnUIPressed();
                SceneLoader.Instance.LoadGameScene();
            });
            mainMenuButton.onClick.AddListener(() =>
            {
                InvokeOnUIPressed();
                SceneLoader.Instance.LoadLevel1();
            });

            GameManager.OnBeforeStateChanged += GameMasterOnBeforeStateChanged;

            Hide();
        }

        private void GameMasterOnBeforeStateChanged(GameState newGameState)
        {
            if (newGameState == GameState.PlayerLoose)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Hide()
        {
            handle.SetActive(false);
        }

        private void Show()
        {
            handle.SetActive(true);
        }
    }
}