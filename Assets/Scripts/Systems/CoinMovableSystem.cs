using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class CoinMovableSystem : IEcsRunSystem
    {
        private float coinMovableSpeed;
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var filter = world
                .Filter<CoinComponent>()
                .Inc<SpeedComponent>()
                .Inc<ViewComponent>()
                .End();

            var speedPool = world.GetPool<SpeedComponent>();
            var viewPool = world.GetPool<ViewComponent>();
            var _coinUpPool = world.GetPool<CoinUpComponent>();

            foreach (int entity in filter)
            {
                ref SpeedComponent speedComponent = ref speedPool.Get(entity);
                ref ViewComponent viewComponent = ref viewPool.Get(entity);
                ref CoinUpComponent coinUpComponent = ref _coinUpPool.Get(entity);

                ref var transform = ref viewComponent.Transform;
                ref var _coinUp = ref coinUpComponent._coinUp;

                if (transform.position.y >= 0.8)
                {
                    _coinUp = false;
                }
                if(transform.position.y <= 0.3)
                {
                    _coinUp = true;
                }

                if(_coinUp)
                {
                    coinMovableSpeed = speedComponent.Speed;
                }
                else
                {
                    coinMovableSpeed = -1 * speedComponent.Speed;
                }

                transform.position += Vector3.up * Time.deltaTime * coinMovableSpeed;
            }
        }
    }
}