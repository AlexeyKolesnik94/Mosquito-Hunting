using MosquitoesScripts;
using Zenject;

namespace Common
{
    public class MosquitoesInstaller : MonoInstaller
    {
        public MosquitoesSpawner mosquitoesSpawner;
        
        public override void InstallBindings()
        {
            MosquitoesSpawnerBind();
        }

        private void MosquitoesSpawnerBind()
        {
            Container
                .Bind<MosquitoesSpawner>()
                .FromInstance(mosquitoesSpawner);
        }
    }
}