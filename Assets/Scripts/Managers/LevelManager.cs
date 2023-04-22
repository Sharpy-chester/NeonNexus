using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] CanvasGroup loadingScreenGroup;
        [SerializeField] float loadingScreenFadeTime = 1.0f;

        private static LevelManager _instance;
        public static LevelManager Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {

        }

        private void OnLevelWasLoaded(int level)
        {
            Time.timeScale = 1;
            if (loadingScreenGroup.alpha == 1)
            {
                StartCoroutine(FadeLoadingScreenOut());
            }
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(SwitchLevel(levelName));
        }

        public IEnumerator SwitchLevel(string levelName)
        {
            while (loadingScreenGroup.alpha < 1)
            {
                loadingScreenGroup.alpha += loadingScreenFadeTime * Time.unscaledDeltaTime;
                yield return null;
            }
            AsyncOperation load = SceneManager.LoadSceneAsync(levelName);
            while (load.progress < 0.9)
            {
                yield return null;
            }
        }

        IEnumerator FadeLoadingScreenOut()
        {
            while (loadingScreenGroup.alpha > 0)
            {
                loadingScreenGroup.alpha -= loadingScreenFadeTime * Time.deltaTime;
                yield return null;
            }
        }
    }

}

