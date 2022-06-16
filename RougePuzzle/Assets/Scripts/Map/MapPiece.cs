using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RougePuzzle.Map
{
    public interface IMapPiece
    {
        void Effect();
    }
    public abstract class MapPiece : MonoBehaviour, IMapPiece
    {
        void Start()
        {

        }
        public abstract void Effect();
    }
}