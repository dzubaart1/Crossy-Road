using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public TerrainGenerator terrainGenerator;
        public GameObject character;
        public override void InstallBindings()
        {
            TerrainGenerator gen1 = Container.InstantiatePrefabForComponent<TerrainGenerator>(terrainGenerator);
            Container.Bind<TerrainGenerator>().FromInstance(gen1).AsSingle();
            GameObject player = Container.InstantiatePrefab(character);


        }
    }
}