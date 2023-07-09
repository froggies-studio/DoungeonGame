using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameWinUI : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private GameObject handle;

        private void Start()
        {
            mainMenuButton.onClick.AddListener(() => {SceneLoader.Instance.LoadMainMenuScene(); });
            
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