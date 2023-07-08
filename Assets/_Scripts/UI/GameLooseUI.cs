#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace _Scripts.UI
{
    public class GameLooseUI : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            restartButton.onClick.AddListener(() => { });
            mainMenuButton.onClick.AddListener(() => { });
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}