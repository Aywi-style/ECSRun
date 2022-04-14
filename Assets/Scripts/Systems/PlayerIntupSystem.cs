using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class PlayerIntupSystem : IEcsRunSystem
    {
        private float moveX;

        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var filter = world
                .Filter<DirectionComponent>()
                .Inc<PlayerComponent>()
                .End();

            var directionPool = world.GetPool<DirectionComponent>();

            SetDirectionPC();

            foreach (int entity in filter)
            {
                ref DirectionComponent directionComponent = ref directionPool.Get(entity);

                ref var direction = ref directionComponent.Direction;

                direction.x = moveX;
                /*Debug.Log(direction.x);*/
            }
        }

        private void SetDirectionPC()
        {
            moveX = Input.GetAxis("Horizontal");
        }

        private void SetDirectionAndroid()
        {
            if(Input.touchCount > 0)
            {
                moveX = Input.GetAxis("Horizontal");
            }
        }
    }
}