using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraps : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}