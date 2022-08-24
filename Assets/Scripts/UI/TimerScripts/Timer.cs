using MosquitoesScripts;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace UI.TimerScripts
{
    public class Timer : MonoBehaviour
    {
        public FloatReactiveProperty gameTime = new FloatReactiveProperty();
        
        private TextMeshProUGUI _text;
        private MosquitoesSpawner _spawner;


        [Inject]
        private void Construct(MosquitoesSpawner spawner)
        {
            _spawner = spawner;
        }
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = gameTime.Value.ToString();

            this.UpdateAsObservable()
                .Subscribe(_ => { GameTimer(); }).AddTo(this);
        }

        private void GameTimer()
        {
            if (gameTime.Value <= 0)
            {
                gameTime.Value = 0;
                _spawner.isSpawn.Value = false;
            }
            
            gameTime.Value -= Time.deltaTime;
            _text.text = Mathf.Round(gameTime.Value).ToString();
        }
    }
}
