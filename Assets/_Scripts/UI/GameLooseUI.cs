#region

using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace _Scripts.UI
{
    public class GameLooseUI : UI
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

            GameMaster.Instance.OnStateChanged += GameMasterOnStateChanged;

            Hide();
        }

        private void GameMasterOnStateChanged(GameMaster.State newState)
        {
            if (newState == GameMaster.State.PlayerLoose)
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