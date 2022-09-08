using System;
using UI.PauseMenu;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace MosquitoesScripts
{
    public class MosquitoMoving : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Vector3 _min, 
                        _max, 
                        _movePoint;
        private float _changeDirectionTime;
        private SpriteRenderer _sprite;
        private Pause _pause;
        

        [Inject]
        private void Construct(Pause pause)
        {
            _pause = pause;
        }
        
        private void Awake()
        {
            _changeDirectionTime = Random.Range(0.5f, 2f);

            ScreenBorders();
            RandomPoint();
        }

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            this.UpdateAsObservable()
                .Subscribe(_ => { Moving(); }).AddTo(this);
        }


        private void ScreenBorders()
        {
            _min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            _max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        }

        private void Moving()
        {
            if (_pause.IsPaused.Value) return;
            
            transform.position = 
                Vector3.MoveTowards(transform.position, _movePoint, speed * Time.deltaTime);
        }

        private void RandomPoint()
        {
            
            Observable.Timer(TimeSpan.FromSeconds(_changeDirectionTime))
                .Repeat()
                .Subscribe(_ =>
                {
                    if (!_pause.IsPaused.Value)
                    {
                        _movePoint.x = Random.Range(_min.x, _max.x);
                        _movePoint.y = Random.Range(_min.y, _max.y);
                        _sprite.flipX = Vector3.Normalize(_movePoint).x >= 0;
                    }
                }).AddTo(this);
        }
    }
}
