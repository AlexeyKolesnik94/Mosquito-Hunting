using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.ScoreScripts
{
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private Score _score;

        [Inject]
        private void Construct(Score score)
        {
            _score = score;
        }

        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreText.text = "0";

            _score.score
                .Subscribe(_ => { ScoreTextView(); }).AddTo(this);
        }

        private void ScoreTextView() =>
            _scoreText.text = _score.score.Value.ToString();
    }
}