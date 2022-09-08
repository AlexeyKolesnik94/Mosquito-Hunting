using UniRx;
using UnityEngine;

namespace UI.PauseMenu.Button
{
    public class RestartBtn : MonoBehaviour
    {
        [SerializeField] private Canvas pauseCanvas;
        [SerializeField] private GameObject mosquitoesContainer;
        
        private UnityEngine.UI.Button _restartBtn;
        private const string sceneName = "Game";
        

        private void Start()
        {
            _restartBtn = GetComponent<UnityEngine.UI.Button>();

            _restartBtn.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    SceneTransition.SceneTransition.SwitchToScene(sceneName);
                    pauseCanvas.gameObject.SetActive(false);
                    mosquitoesContainer.SetActive(false);
                }).AddTo(this);
        }
    }
}