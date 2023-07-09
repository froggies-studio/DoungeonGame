using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        
        private void Start()
        {
            playButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadGameScene();
            });
            
            quitButton.onClick.AddListener(Application.Quit);
        }
        
    }
}