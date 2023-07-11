using _Scripts.Helpers;
using UnityEngine;

namespace _Scripts.UI
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        public void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
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