using UI.ScoreScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MosquitoesScripts
{
    public class KillMosquitoes : MonoBehaviour, IPointerClickHandler
    {
        private Animator _animator;
        
        private MosquitoesSpawner _mosquitoesSpawner;
        private Score _score;
        
        private static readonly int Death = Animator.StringToHash("Death");
        
        [Inject]
        private void Construct(MosquitoesSpawner mosquitoesSpawner, Score score)
        {
            _score = score;
            _mosquitoesSpawner = mosquitoesSpawner;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _animator.Play(Death);
        }

        public void Killing()
        {
            _mosquitoesSpawner.mosquitoesCounts.Value--;
            _score.AddScore();
            Destroy(gameObject);
        }
    }
}