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
        [SerializeField] private float gameTime;
        
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
            _text.text = gameTime.ToString();

            this.UpdateAsObservable()
                .Subscribe(_ => { GameTimer(); }).AddTo(this);
        }

        private void GameTimer()
        {
            if (gameTime <= 0)
            {
                gameTime = 0;
                _spawner.isSpawn.Value = false;
            }
            
            gameTime -= Time.deltaTime;
            _text.text = Mathf.Round(gameTime).ToString();
        }
    }
}
