using UnityEngine;

namespace _Scripts.UI
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        public void LoadMainMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        public void LoadLevel1()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}