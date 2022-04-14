using UnityEngine;
using Leopotam.EcsLite;

namespace Client
{
    sealed class PlayerControleSystem : IEcsRunSystem
    {
        private int minPlayerShift = -2;
        private int maxPlayerShift = 2;

        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var filter = world
                .Filter<PlayerComponent>()
                .Inc<DirectionComponent>()
                .Inc<ViewComponent>()
                .Inc<SpeedComponent>()
                .End();

            var directionPool = world.GetPool<DirectionComponent>();
            var viewPool = world.GetPool<ViewComponent>();
            var speedPool = world.GetPool<SpeedComponent>();

            foreach (int entity in filter)
            {
                ref DirectionComponent directionComponent = ref directionPool.Get(entity);
                ref ViewComponent viewComponent = ref viewPool.Get(entity);
                ref SpeedComponent speedComponent = ref speedPool.Get(entity);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref viewComponent.Transform;
                ref var speed = ref speedComponent.Speed;

                if ((transform.position.x >= maxPlayerShift && direction.x > 0) || (transform.position.x <= minPlayerShift && direction.x < 0))
                {
                    Debug.Log("Было - "+ direction.x);
                    direction.x = 0;
                    Debug.Log("Стало - "+ direction.x);
                }

                transform.position += (transform.right * direction.x) * speed * Time.deltaTime;
            }
        }
    }
}