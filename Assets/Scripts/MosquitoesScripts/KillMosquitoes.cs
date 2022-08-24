using UI.ScoreScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MosquitoesScripts
{
    public class KillMosquitoes : MonoBehaviour, IPointerClickHandler
    {
        private MosquitoesSpawner _mosquitoesSpawner;
        private Score _score;
        
        [Inject]
        private void Construct(MosquitoesSpawner mosquitoesSpawner, Score score)
        {
            _score = score;
            _mosquitoesSpawner = mosquitoesSpawner;
        }
   
        public void OnPointerClick(PointerEventData eventData)
        {
            _mosquitoesSpawner.mosquitoesCounts.Value--;
            _score.AddScore();
            Destroy(gameObject);
        }
    }
}