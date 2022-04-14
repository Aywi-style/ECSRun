using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class InitPlayerSystem : IEcsInitSystem
    {
        public void Init (EcsSystems systems)
        {
            var go = GameObject.FindGameObjectWithTag("Player");

            var world = systems.GetWorld();
            var entity = world.NewEntity();

            world.GetPool<PlayerComponent>().Add(entity);

            ref var speedComponent = ref world.GetPool<SpeedComponent>().Add(entity);
            speedComponent.Speed = 5;

            ref var viewComponent = ref world.GetPool<ViewComponent>().Add(entity);
            viewComponent.Transform = go.transform;

            ref var directionCpmponent = ref world.GetPool<DirectionComponent>().Add(entity);
            directionCpmponent.Direction = go.transform.position;

            ref var characterController = ref world.GetPool<MovableComponent>().Add(entity);
        }
    }
}