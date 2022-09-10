using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float distanceCollider;

    private float updatepos;
    private float initial;
    private float pose;
    private Animator anim;
    private Health playerHealth;
    private bool right = true;
    private bool left = false;

    private bool isMoving = true;
    public bool idle = true;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

        pose = transform.position.x + 5;
        initial = transform.position.x;
        Debug.Log(pose);
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (CheckPlayer())
        {
            if (cooldownTimer >= attackCooldown)
            {
                isMoving = false;
                anim.SetBool("Moving", false);
                Debug.Log("Enemy Attack");
                cooldownTimer = 0;
                anim.SetTrigger("MeleeAttack");
            }
        }
        enemyMove();

        if (idle)
        {
            anim.SetBool("Moving", false);
            isMoving = false;
        }
    }

    private bool CheckPlayer()
    {
        //cek posisi player dengan raycast
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        //visualisasi area cek
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (CheckPlayer())
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void enemyMove()
    {
        if (isMoving)
        {
            anim.SetBool("Moving", true);
            updatepos = transform.position.x;
            if (updatepos <= pose && right)
            {
                transform.Translate(new Vector2(1, 0) * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
                if (updatepos >= pose - 1)
                {
                    right = false;
                    left = true;
                }
            }
            if (left)
            {
                transform.Translate(new Vector2(-1, 0) * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);

                if (updatepos <= initial)
                {
                    left = false;
                    right = true;
                }
            }
        }
    }

    private void moving()
    {
        isMoving = true;
        anim.SetBool("Moving", true);
    }
}