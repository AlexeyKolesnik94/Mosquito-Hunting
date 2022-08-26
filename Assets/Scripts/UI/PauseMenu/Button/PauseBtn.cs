using UniRx;
using UnityEngine;
using Zenject;

namespace UI.PauseMenu.Button
{
    public class PauseBtn : MonoBehaviour
    {
        private Pause _pause;
        private UnityEngine.UI.Button _pauseBtn;

        [Inject]
        private void Construct(Pause pause)
        {
            _pause = pause;
        }
        
        private void Start()
        {
            _pauseBtn = GetComponent<UnityEngine.UI.Button>();

            _pauseBtn.OnClickAsObservable()
                .Subscribe(_ => { _pause.IsPaused.Value = true; }).AddTo(this);
        }
    }
}