using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IObservablePlayer
{
    /// <summary>
    /// Playerの現在のX,Y,Zの座標
    /// </summary>
    /// <value></value>
    ReactiveProperty<Vector3> Position { get; }
    /// <summary>
    /// 体力
    /// </summary>
    /// <value></value>
    ReactiveProperty<int> Hp { get; }
    /// <summary>
    /// 攻撃力
    /// </summary>
    /// <value></value>
    ReactiveProperty<int> Attack { get; }
}

public class Player : IObservablePlayer
{
    public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
    public ReactiveProperty<int> Hp { get; }
    public ReactiveProperty<int> Attack { get; }

}