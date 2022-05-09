using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using UnityUtility.Enums;
using UnityUtility.Collections;
using Sirenix.OdinInspector;

namespace RougePuzzle.Map
{
    public interface IMapGenerator
    {
        UniTask Generate();
    }
    // 発火するためにとりあえずMonoBehaviourにする
    public class MapGenerator : MonoBehaviour, IMapGenerator
    {
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        [SerializeField]
        private Map m_map;

        [Button]
        public async UniTask Generate()
        {
            MapPieceType[,] array = new MapPieceType[WIDTH, HEIGHT];
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    // とりあえずランダム生成
                    array[i, j] = EnumUtils.Random<MapPieceType>();
                }
            }
            await m_map.InitializeMap(new Map<MapPieceType>(array));

            print("done");
        }
    }
}