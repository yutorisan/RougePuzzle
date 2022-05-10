using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class PlayerNavigator : MonoBehaviour
{
    #region injection
    Player player;
    InputProvider inputProvider;
    #endregion

    #region component
    // TODO Actorの方に
    Transform transformCache;

    void Awake()
    {
        // ほんとはinjectionでやる
        inputProvider = new InputProvider();
        player = new Player();
        // component
        transformCache = GetComponent<Transform>();
    }
    #endregion

    const float MOVETIME = 0.2f;
    Vector3 inputVector = new Vector3();
    bool isMoving;

    void Start()
    {
        inputProvider.OnArrowKeyDown()
            .Subscribe(Unit =>
            {
                if (CanMove() && !isMoving) { Move(); }
            });

        inputProvider.OnArrowKeyUp()
            .Subscribe(Unit =>
            {
                InitInputVector();
            });
    }

    private void InitInputVector()
    {
        inputVector = Vector3.zero;
    }

    private bool CanMove()
    {
        bool isHit = true;//TODO
        
        return isHit;
    }

    private void Move()
    {
        isMoving = true;
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");
        player.Position.Value += inputVector;
        transformCache
            .DOMove(transformCache.position + inputVector, MOVETIME)
            .OnComplete(() => { isMoving = false; });
#if DEBUG
        Debug.Log("Player:" + player.Position.Value);
#endif
    }
}
