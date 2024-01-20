using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelarator : MonoBehaviour
{
    public float duration = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            FindObjectOfType<GameManager>().WalkOnAccelarator(this);
        }
    }
}
