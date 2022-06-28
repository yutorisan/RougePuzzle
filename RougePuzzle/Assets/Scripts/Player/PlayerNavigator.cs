using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Zenject;

public interface IPlayerNavigator
{

}

public class PlayerNavigator : MonoBehaviour, IPlayerNavigator
{

    [SerializeField]
    private const float MOVETIME = 0.2f;
    private bool isMoving;

    private IObservablePlayer player;
    private IObservableInputProvider inputProvider;
    
    // zenjectによるDI、コンストラクタっぽく書くとエラーがでるらしい
    [Inject]
    public void Constructor (
        IObservablePlayer p,
        IObservableInputProvider iip)
    {
        player = p;
        inputProvider = iip;
    }

    void Start()
    {
        inputProvider.OnVectorInput()
            .Where(_ => CanMove() && !isMoving)
            .Subscribe(inputVector => Move(inputVector));
    }

    private bool CanMove()
    {
        bool isHit = true;//TODO
        
        return isHit;
    }

    private void Move(Vector3 inputVector)
    {
        isMoving = true;
        player.Position.Value += inputVector;
        transform
            .DOMove(transform.position + inputVector, MOVETIME)
            .OnComplete(() => { isMoving = false; });
#if DEBUG
        Debug.Log("Player:" + player.Position.Value);
#endif
    }
}
