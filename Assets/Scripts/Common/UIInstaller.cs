using UI.PauseMenu;
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
            PauseBind();
        }

        private void PauseBind()
        {
            Container
                .Bind<Pause>()
                .AsSingle()
                .NonLazy();
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