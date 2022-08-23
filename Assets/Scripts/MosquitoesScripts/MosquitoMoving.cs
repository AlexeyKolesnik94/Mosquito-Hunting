using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MosquitoesScripts
{
    public class MosquitoMoving : MonoBehaviour
    {
        private Vector3 _min, 
                        _max, 
                        _movePoint;

        private float _changeDirectionTime;

        private void Awake()
        {
            _changeDirectionTime = Random.Range(0.5f, 2f);
            
            ScreenBorders();
            RandomPoint();
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => { Moving(); }).AddTo(this);
        }


        private void ScreenBorders()
        {
            _min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            _max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        }

        private void Moving() => 
            transform.position = Vector3.MoveTowards(transform.position, _movePoint, 0.01f);

        private void RandomPoint()
        {
            Observable.Timer(TimeSpan.FromSeconds(_changeDirectionTime))
                .Repeat()
                .Subscribe(_ =>
                {
                    _movePoint.x = Random.Range(_min.x, _max.x);
                    _movePoint.y = Random.Range(_min.y, _max.y);
                }).AddTo(this);
        }
    }
}
