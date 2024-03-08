using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreColision : MonoBehaviour
{
    public CircleCollider2D circle;


    private void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Player"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
    }


}
