using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public interface IObservableInputProvider
{
    /// <summary>
    /// キーボードの上下左右キーが押下された時
    /// </summary>
    /// <returns></returns>
    IObservable<Unit> OnArrowKeyDown();

    /// <summary>
    /// キーボードの上下左右キーの押下が終了した時
    /// </summary>
    /// <returns></returns>
    IObservable<Unit> OnArrowKeyUp();
}

public class InputProvider : IObservableInputProvider
{
    public IObservable<Unit> OnArrowKeyDown()
    => Observable.EveryUpdate()
        .Where(_ =>
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        .AsUnitObservable();

    public IObservable<Unit> OnArrowKeyUp()
    => Observable.EveryUpdate()
        .Where(_ =>
            Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow))
        .AsUnitObservable();
}
