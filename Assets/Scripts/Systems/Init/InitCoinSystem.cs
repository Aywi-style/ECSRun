using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class InitCoinSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var go = GameObject.FindGameObjectsWithTag("Coin");

            var world = systems.GetWorld();

            foreach (var i in go)
            {
                var entity = world.NewEntity();

                world.GetPool<CoinComponent>().Add(entity);

                ref var speedComponent = ref world.GetPool<SpeedComponent>().Add(entity);
                speedComponent.Speed = 0.5f;

                ref var viewComponent = ref world.GetPool<ViewComponent>().Add(entity);
                viewComponent.Transform = i.transform;

                ref var coinUpComponent = ref world.GetPool<CoinUpComponent>().Add(entity);
                coinUpComponent._coinUp = true;
            }
        }
    }
}