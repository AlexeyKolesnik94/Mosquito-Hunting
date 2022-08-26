using UniRx;
using UnityEngine;
using Zenject;

namespace UI.PauseMenu.Button
{
    public class ResumeGameBtn : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private UnityEngine.UI.Button resumeBtn;
        
        private Pause _pause;
        private static readonly int DisablePauseMenu = Animator.StringToHash("PausePanelDisableAnim");

        [Inject]
        private void Construct(Pause pause)
        {
            _pause = pause;
        }
        
        private void Start()
        {
            resumeBtn.OnClickAsObservable()
                .Subscribe(_ => { animator.Play(DisablePauseMenu); }).AddTo(this);
        }

        public void ResumeGame()
        {
            _pause.IsPaused.Value = false;
        }
    }
}