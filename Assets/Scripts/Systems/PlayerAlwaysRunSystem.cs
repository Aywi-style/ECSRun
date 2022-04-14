using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class PlayerAlwaysRunSystem : IEcsRunSystem
    {        
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var filter = world
                .Filter<SpeedComponent>()
                .Inc<PlayerComponent>()
                .End();

            var speedPool = world.GetPool<SpeedComponent>();
            var viewPool = world.GetPool<ViewComponent>();

            foreach (int entity in filter)
            {
                ref SpeedComponent speedComponent = ref speedPool.Get(entity);
                ref ViewComponent viewComponent = ref viewPool.Get(entity);

                ref var transform = ref viewComponent.Transform;

                transform.position += Vector3.forward * Time.deltaTime * speedComponent.Speed;
            }
        }
    }
}