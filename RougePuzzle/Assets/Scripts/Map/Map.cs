using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility.Collections;
using UnityUtility;
using Sirenix.OdinInspector;
using Cysharp.Threading.Tasks;

namespace RougePuzzle.Map
{
    public interface IMap
    {

    }
    public class Map : SerializedMonoBehaviour, IMap
    {
        [SerializeField]
        private IReadOnlyDictionary<MapPieceType, MapPiece> piecePrefabSettingTable;
        [SerializeField]
        private float pieceSize = 1;

        private Map<IMapPiece> map;

        void Start()
        {

        }

        public async UniTask InitializeMap(Map<MapPieceType> typeMap)
        {
            map = new Map<IMapPiece>(typeMap.ColumnCount, typeMap.RowCount);
            foreach (var cell in typeMap.GetCellEnumerable())
            {
                MapPiece instantiatedPiece = Instantiate<MapPiece>(piecePrefabSettingTable[cell.Value], transform);
                instantiatedPiece.transform.localPosition = new Vector3(cell.Column, cell.Row) * pieceSize;
                map[cell.Column, cell.Row] = instantiatedPiece;
                // １フレーム１ピース生成
                await UniTask.Yield();
            }
        }

        // 全ピース削除する仮メソッド
        [Button]
        public void Delete()
        {
            foreach (var obj in this.Transforms())
            {
                Destroy(obj.gameObject);
            }
        }
    }
}