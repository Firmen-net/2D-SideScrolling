using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement move;
    private float cooldownTimer = Mathf.Infinity;
    private EnemyMeleeAttack enemy;

    //untukFireball
    [SerializeField] private Transform firepoint;

    [SerializeField] private GameObject[] fireballs;

    private void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.B) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        Debug.Log("Attack");

        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //fireball
        fireballs[CheckFireball()].transform.position = firepoint.position;
        fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int CheckFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}