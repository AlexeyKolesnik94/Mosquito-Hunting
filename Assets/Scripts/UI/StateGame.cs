using System;
using MosquitoesScripts;
using UI.PauseMenu;
using UI.TimerScripts;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StateGame : MonoBehaviour
    {
        [SerializeField] private Canvas pauseCanvas;
        [SerializeField] private Canvas endGameCanvas;

        private Pause _pause;
        private Timer _timer;

        [Inject]
        private void Construct(Pause pause, Timer timer)
        {
            _timer = timer;
            _pause = pause;
        }

        private void Start()
        {
            _timer.isTimerOff
                .Subscribe(_ =>
                {
                    if (!_timer.isTimerOff.Value) return;
                    endGameCanvas.gameObject.SetActive(true);
                    Debug.Log(_timer.isTimerOff);
                }).AddTo(this);

            _pause.IsPaused
                .Subscribe(_ =>
                {
                    switch (_pause.IsPaused.Value)
                    {
                        case true:
                            pauseCanvas.gameObject.SetActive(true);
                            break;
                        case false:
                            pauseCanvas.gameObject.SetActive(false);
                            break;
                    }
                }).AddTo(this);
        }
    }
}