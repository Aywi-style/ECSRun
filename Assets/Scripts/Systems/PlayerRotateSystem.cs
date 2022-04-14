using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class PlayerRotateSystem : IEcsRunSystem
    {
        private int minPlayerShift = -2;
        private int maxPlayerShift = 2;
        private int rotateSpeed = 130;
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var filter = world
                .Filter<PlayerComponent>()
                .Inc<DirectionComponent>()
                .Inc<ViewComponent>()
                .End();

            var directionPool = world.GetPool<DirectionComponent>();
            var viewPool = world.GetPool<ViewComponent>();

            foreach (int entity in filter)
            {
                ref DirectionComponent directionComponent = ref directionPool.Get(entity);
                ref ViewComponent viewComponent = ref viewPool.Get(entity);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref viewComponent.Transform;

                if ((transform.position.x >= maxPlayerShift && direction.x > 0) || (transform.position.x <= minPlayerShift && direction.x < 0))
                {
                    Debug.Log("���� - " + direction.x);
                    direction.x = 0;
                    Debug.Log("����� - " + direction.x);
                }

                transform.Rotate(Vector3.up, direction.x * Time.deltaTime * rotateSpeed);
            }
        }
    }
}