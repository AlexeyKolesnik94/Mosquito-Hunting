using UniRx;

namespace UI.ScoreScripts
{
    public class Score
    {
        public IntReactiveProperty score = new IntReactiveProperty();
        private Score _scoreScript;

        public void AddScore() => 
            score.Value++;
    }
}