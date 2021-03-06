using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        EcsSystems _systems;

        void Start ()
        {        
            // register your shared data here, for example:
            // var shared = new Shared ();
            // systems = new EcsSystems (new EcsWorld (), shared);
            _systems = new EcsSystems (new EcsWorld ());
            _systems
                // register your systems here, for example:
                .Add(new InitPlayerSystem())
                /*.Add(new InitEnemySystem())*/
                .Add(new InitCoinSystem())
                .Add(new PlayerAlwaysRunSystem())
                .Add(new PlayerIntupSystem())
                .Add(new PlayerRotateSystem())
                .Add(new PlayerControleSystem())
                .Add(new CoinMovableSystem())

                // register additional worlds here, for example:
                // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
                // add debug systems for custom worlds here, for example:
                // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Init ();
        }

        void Update ()
        {
            _systems?.Run ();
        }

        void OnDestroy ()
        {
            if (_systems != null)
            {
                _systems.Destroy ();
                // add here cleanup for custom worlds, for example:
                // _systems.GetWorld ("events").Destroy ();
                _systems.GetWorld ().Destroy ();
                _systems = null;
            }
        }
    }
}