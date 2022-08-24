using UI.ScoreScripts;
using UI.TimerScripts;
using Zenject;

namespace Common
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ScoreBind();
        }

        private void ScoreBind()
        {
            Container
                .Bind<Score>()
                .AsSingle()
                .NonLazy();
        }
    }
}