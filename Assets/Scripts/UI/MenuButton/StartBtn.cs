using UniRx;
using UnityEngine;

namespace UI.MenuButton
{
    public class StartBtn : MonoBehaviour
    {
        private UnityEngine.UI.Button _startBtn;
        private const string sceneName = "Game";

        private void Start()
        {
            _startBtn = GetComponent<UnityEngine.UI.Button>();

            _startBtn.OnClickAsObservable()
                .Subscribe(_ =>
                { 
                    SceneTransition.SceneTransition.SwitchToScene(sceneName);
                    gameObject.SetActive(false);
                }).AddTo(this);
        }
    }
}