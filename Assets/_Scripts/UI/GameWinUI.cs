using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameWinUI : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            mainMenuButton.onClick.AddListener(() => { });
            
            GameMaster.Instance.OnStateChanged += GameMasterOnStateChanged;
        }

        private void GameMasterOnStateChanged(GameMaster.State newState)
        {
            gameObject.SetActive(newState == GameMaster.State.PlayerWin);
        }
    }
}