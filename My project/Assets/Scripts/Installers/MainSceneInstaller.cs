using Cinemachine;
using Cntrls;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public TerrainGenerator terrainGenerator;
        public GameObject playerObject;
        public GameObject virtualCamera;
        public CollectionParams collectionParams;
        public override void InstallBindings()
        {
            BindBorder();
            BindCollectionParams();
            BindTerGen();
            PlayerCntrl player = BindPlayer();
            CinemachineVirtualCamera cam = InstVirtCam();
            SettingsVirtCam(player, cam);
        }

        private void BindCollectionParams()
        {
            RoadsCollection roadsCollection = new RoadsCollection(collectionParams);
            Container.Bind<RoadsCollection>().FromInstance(roadsCollection).AsSingle();
        }
        private void BindBorder()
        {
            Border border = new Border();
            border._upperBound = 11;
            border._lowerBound = -11;
            Container.Bind<Border>().FromInstance(border).AsSingle();
        }
        private void BindTerGen()
        {
            TerrainGenerator gen = Container.InstantiatePrefabForComponent<TerrainGenerator>(terrainGenerator);
            Container.Bind<TerrainGenerator>().FromInstance(gen).AsSingle();
        }
        private PlayerCntrl BindPlayer()
        {
            PlayerCntrl player = Container.InstantiatePrefabForComponent<PlayerCntrl>(playerObject);
            Container.Bind<PlayerCntrl>().FromInstance(player).AsSingle();
            return player;
        }

        private CinemachineVirtualCamera InstVirtCam()
        {
            return Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(virtualCamera, new Vector3(0, 1.06f, -3), Quaternion.identity, null);      
        }
        
        private void SettingsVirtCam(PlayerCntrl player, CinemachineVirtualCamera cam)
        {
            cam.Follow = player.transform.Find("CameraTarget");
        }
    }
}