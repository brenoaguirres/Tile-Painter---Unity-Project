using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [Tooltip("moveSpeed / thisValue")]
    [SerializeField] private float slowDebuffDecrease = 2;
    [Tooltip("moveSpeed * thisValue")]
    [SerializeField] private float slipperyDebuffIncrease = 2; 
    private PlayerMovement playerMovement;
    private enum Effects
    {
        Normal,
        Slowed,
        Slippery,
    }
    private Effects currentEffect = Effects.Normal;
    private Effects lastEffect = Effects.Normal;

    void Awake()
    {
        currentEffect = Effects.Normal;
        lastEffect = Effects.Normal;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        UpdateEffect();
    }

    private void UpdateEffect() {
        switch(currentEffect)
        {
            case Effects.Slowed:
                if(lastEffect != Effects.Slowed)
                {
                    playerMovement.SetMoveSpeed(playerMovement.GetMoveSpeed() / slowDebuffDecrease);
                    lastEffect = Effects.Slowed;
                }
                break;
            case Effects.Slippery:
                if(lastEffect != Effects.Slippery) {
                    playerMovement.SetMoveSpeed(playerMovement.GetMoveSpeed() * slipperyDebuffIncrease);
                    lastEffect = Effects.Slippery;
                }
                break;
            default:
                if (lastEffect != Effects.Normal)
                {
                    playerMovement.ResetMoveSpeed();
                    lastEffect = Effects.Normal;
                }
                break;
        }
    }

    public void SetSlow() {
        currentEffect = Effects.Slowed;
    }

    public void SetSlippery() {
        currentEffect = Effects.Slippery;
    }

    public void SetNormalSpeed() {
        currentEffect = Effects.Normal;
    }
}
