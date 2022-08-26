using System;
using UI.PauseMenu;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace MosquitoesScripts
{
    public class MosquitoesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject parentSpawn;
        [SerializeField] private int countMosquitoes;
        [SerializeField] private float timeSpawn;
        [SerializeField] private GameObject[] spawnPoints;
        
        public bool IsFoolListMosquitoes { get; private set; }

        private DiContainer _container;
        private Pause _pause;

        [HideInInspector]
        public IntReactiveProperty mosquitoesCounts = new IntReactiveProperty();
        [HideInInspector]
        public BoolReactiveProperty isSpawn = new BoolReactiveProperty(true);

        [Inject]
        private void Construct(DiContainer diContainer, Pause pause)
        {
            _container = diContainer;
            _pause = pause;
        }

        private void Start()
        {
            SpawnMosquitoes();
        }

        private void SpawnMosquitoes()
        {
            Observable.Timer(TimeSpan.FromSeconds(timeSpawn))
                .Repeat()
                .Subscribe(_ =>
                {
                    if (mosquitoesCounts.Value < countMosquitoes && isSpawn.Value && !_pause.IsPaused.Value)
                    {
                        int rand = Random.Range(0, spawnPoints.Length - 1);
                        
                        _container.InstantiatePrefab(prefab, spawnPoints[rand].transform.position, Quaternion.identity,
                            parentSpawn.transform);
                        mosquitoesCounts.Value++;
                    }
                    if (mosquitoesCounts.Value == countMosquitoes) IsFoolListMosquitoes = true;
                }).AddTo(this);
        }
    }
}