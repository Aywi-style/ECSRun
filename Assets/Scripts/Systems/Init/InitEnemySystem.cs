using UnityEngine;
using Leopotam.EcsLite;

namespace Client {
    sealed class InitEnemySystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var go = GameObject.FindGameObjectsWithTag("Enemy");

            var world = systems.GetWorld();

            foreach (var i in go)
            {
                var entity = world.NewEntity();

                world.GetPool<EnemyComponent>().Add(entity);

                ref var speedComponent = ref world.GetPool<SpeedComponent>().Add(entity);
                speedComponent.Speed = 2;

                ref var viewComponent = ref world.GetPool<ViewComponent>().Add(entity);
                viewComponent.Transform = i.transform;
            }
        }
    }
}