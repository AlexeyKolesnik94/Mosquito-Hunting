using System;
using MosquitoesScripts;
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

        private MosquitoesSpawner _spawner;
        private Timer _timer;

        [Inject]
        private void Construct(MosquitoesSpawner spawner, Timer timer)
        {
            _timer = timer;
            _spawner = spawner;
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
        }
    }
}