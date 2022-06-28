using UnityEngine;
using Zenject;

public class PlayerSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IObservableInputProvider>()
            .To<InputProvider>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<IObservablePlayer>()
            .To<Player>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}