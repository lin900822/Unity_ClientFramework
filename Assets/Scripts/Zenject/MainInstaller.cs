using UIFramework;

namespace Zenject
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UISystem>().AsSingle().NonLazy();
        }
    }
}