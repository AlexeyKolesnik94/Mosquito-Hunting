using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MosquitoesScripts
{
    public class KillMosquitoes : MonoBehaviour, IPointerClickHandler
    {
        private MosquitoesSpawner _mosquitoesSpawner;

        [Inject]
        private void Construct(MosquitoesSpawner mosquitoesSpawner)
        {
            _mosquitoesSpawner = mosquitoesSpawner;
        }
   
        public void OnPointerClick(PointerEventData eventData)
        {
            _mosquitoesSpawner.mosquitoesCounts.Value--;
            Destroy(gameObject);
        }
    }
}