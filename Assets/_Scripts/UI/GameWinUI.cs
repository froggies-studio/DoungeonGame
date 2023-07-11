using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameWinUI : UIBase
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button lvlOne;

        private void Start()
        {
            mainMenuButton.onClick.AddListener(() =>
            {
                InvokeOnUIPressed();
                SceneLoader.Instance.LoadMainMenuScene();
            });

            if (lvlOne != null)
            {
                lvlOne.onClick.AddListener(() =>
                {
                    InvokeOnUIPressed();
                    SceneLoader.Instance.LoadLevel1();
                });
            }
            
            
            GameManager.OnAfterStateChanged += GameMasterOnBeforeStateChanged;
            Hide();
        }

        private void GameMasterOnBeforeStateChanged(GameState newGameState)
        {
            if (newGameState == GameState.PlayerWin)
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
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.OnAfterStateChanged -= GameMasterOnBeforeStateChanged;
        }
    }
}