using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public interface IObservableInputProvider
{
    /// <summary>
    /// ユーザーの入力が入ったらその方向のベクトルを返す
    /// </summary>
    /// <returns></returns>
    IObservable<Vector3> OnVectorInput();
}

public class InputProvider : IObservableInputProvider
{
    public IObservable<Vector3> OnVectorInput()
    => Observable.EveryUpdate()
        .Select(_ => new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")))
        .Where(inputVector => inputVector != Vector3.zero);
}
