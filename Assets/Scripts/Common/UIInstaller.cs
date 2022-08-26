using UI.ScoreScripts;
using UI.TimerScripts;
using Zenject;

namespace Common
{
    public class UIInstaller : MonoInstaller
    {

        public Timer timer;
        
        public override void InstallBindings()
        {
            ScoreBind();
            TimerBind();
        }

        private void TimerBind()
        {
            Container
                .Bind<Timer>()
                .FromInstance(timer)
                .AsSingle()
                .NonLazy();
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