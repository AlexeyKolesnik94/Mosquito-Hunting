using UI.TimerScripts;
using Zenject;

namespace Common
{
    public class UIInstaller : MonoInstaller
    {
        public Timer timer;
        
        public override void InstallBindings()
        {
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
    }
}