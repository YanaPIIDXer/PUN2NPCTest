using UnityEngine;
using Zenject;

namespace Input
{
    public class KeyInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputEvent>()
                     .To<KeyInput>()
                     .FromNewComponentOnNewGameObject()
                     .AsCached();
        }
    }
}
