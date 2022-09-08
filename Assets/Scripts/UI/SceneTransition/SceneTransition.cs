using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.SceneTransition
{
    public class SceneTransition : MonoBehaviour
    {
        public Image LoadingProgressBar;
    
        private static SceneTransition instance;
        private static bool shouldPlayOpeningAnimation = false; 
    
        private Animator componentAnimator;
        private AsyncOperation loadingSceneOperation;
        private static readonly int SceneClosing = Animator.StringToHash("sceneClosing");
        private static readonly int SceneOpening = Animator.StringToHash("sceneOpening");

        public static void SwitchToScene(string sceneName)
        {
            instance.componentAnimator.SetTrigger(SceneClosing);

            instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        
            instance.loadingSceneOperation.allowSceneActivation = false;
        
            instance.LoadingProgressBar.fillAmount = 0;
        }
    
        private void Start()
        {
            instance = this;
        
            componentAnimator = GetComponent<Animator>();
        
            if (shouldPlayOpeningAnimation) 
            {
                componentAnimator.SetTrigger(SceneOpening);
                instance.LoadingProgressBar.fillAmount = 1;
            
                shouldPlayOpeningAnimation = false; 
            }
        }

        private void Update()
        {
            if (loadingSceneOperation != null)
            {
                //LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
                
                LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                    Time.deltaTime * 5);
            }
        }

        public void OnAnimationOver()
        {
            shouldPlayOpeningAnimation = true;
        
            loadingSceneOperation.allowSceneActivation = true;
        }
    }
}