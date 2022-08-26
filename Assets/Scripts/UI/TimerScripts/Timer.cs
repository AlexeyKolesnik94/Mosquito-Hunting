using MosquitoesScripts;
using TMPro;
using UI.PauseMenu;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace UI.TimerScripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float gameTime;
        
        private TextMeshProUGUI _text;
        private MosquitoesSpawner _spawner;
        private Pause _pause;

        public BoolReactiveProperty isTimerOff = new BoolReactiveProperty(false);
        
        [Inject]
        private void Construct(MosquitoesSpawner spawner, Pause pause)
        {
            _spawner = spawner;
            _pause = pause;
        }
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = gameTime.ToString();

            this.UpdateAsObservable()
                .Subscribe(_ => { GameTimer(); }).AddTo(this);
        }

        private void GameTimer()
        {
            if (gameTime <= 0)
            {
                gameTime = 0;
                isTimerOff.Value = true;
                _spawner.isSpawn.Value = false;
            }

            if (!_pause.IsPaused.Value)
            {
                gameTime -= Time.deltaTime;
                _text.text = Mathf.Round(gameTime).ToString();
            }
        }
    }
}
