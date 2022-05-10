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
    ReactiveProperty<Vector3> Position { get; set; }
    /// <summary>
    /// 体力
    /// </summary>
    /// <value></value>
    IntReactiveProperty Hp { get; set; }
    /// <summary>
    /// 攻撃力
    /// </summary>
    /// <value></value>
    IntReactiveProperty Attack { get; set; }
}

public class Player : IObservablePlayer
{
    public ReactiveProperty<Vector3> Position { get; set; } = new ReactiveProperty<Vector3>();
    public IntReactiveProperty Hp {get;set;}
    public IntReactiveProperty Attack { get; set; }

}