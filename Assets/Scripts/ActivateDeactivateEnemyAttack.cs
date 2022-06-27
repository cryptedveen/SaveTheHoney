using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateEnemyAttack : MonoBehaviour
{
    [SerializeField] BoxCollider2D ArrowHitbox;
    private void Start()
    {
        ArrowHitbox.enabled = false;
    }

    public void activateAttackHitbox()
    {
        ArrowHitbox.enabled = true;
    }
    public void deactivateAttackHitbox()
    {
        ArrowHitbox.enabled = false;
    }
}
