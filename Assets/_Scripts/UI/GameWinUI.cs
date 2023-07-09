using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameWinUI : UI
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button lvlOne;
        [SerializeField] private GameObject handle;

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
            
            
            GameMaster.Instance.OnStateChanged += GameMasterOnStateChanged;
            Hide();
        }

        private void GameMasterOnStateChanged(GameMaster.State newState)
        {
            if (newState == GameMaster.State.PlayerWin)
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