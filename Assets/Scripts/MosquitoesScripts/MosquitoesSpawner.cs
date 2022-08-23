using System;
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
        [SerializeField] private GameObject[] spawnPoints;

        public bool IsFoolListMosquitoes { get; private set; }

        private DiContainer _container;

        [HideInInspector]
        public IntReactiveProperty mosquitoesCounts = new IntReactiveProperty();

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }

        private void Start()
        {
            SpawnMosquitoes();
        }

        private void SpawnMosquitoes()
        {
            Observable.Timer(TimeSpan.FromSeconds(3))
                .Repeat()
                .Subscribe(_ =>
                {
                    if (mosquitoesCounts.Value < countMosquitoes)
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