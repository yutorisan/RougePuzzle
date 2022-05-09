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
        private IReadOnlyDictionary<MapPieceType, MapPiece> m_piecePrefabSettingTable;
        [SerializeField]
        private float m_pieceSize = 1;

        private Map<IMapPiece> m_map;

        void Start()
        {

        }

        public async UniTask InitializeMap(Map<MapPieceType> typeMap)
        {
            m_map = new Map<IMapPiece>(typeMap.ColumnCount, typeMap.RowCount);
            foreach (var cell in typeMap.GetCellEnumerable())
            {
                MapPiece instantiatedPiece = Instantiate<MapPiece>(m_piecePrefabSettingTable[cell.Value], transform);
                instantiatedPiece.transform.localPosition = new Vector3(cell.Column, cell.Row) * m_pieceSize;
                m_map[cell.Column, cell.Row] = instantiatedPiece;
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