using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Fireball"))
        {
            anim.SetTrigger("Die");
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}