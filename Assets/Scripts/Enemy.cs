using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform attackBaseSpawnPoint;
    private float attackTimer = 50f;
    private bool isAttacking;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerTransform != null && !isAttacking)
        {
            if (Random.Range(1, 300) == (int)attackTimer)
            {
                isAttacking = true;
                TriggerAttack();
            }
        }
    }
    
    private void TriggerAttack()
    {
        int attackType = Random.Range(1, 3);
        switch (attackType)
        {
            case 1:
                animator.SetTrigger("AttackBase");
                break;
            case 2:
                animator.SetTrigger("AttackTriple");
                break;
            case 3:
                animator.SetTrigger("AttackUp");
                break;
        }
    }

    public void Attack()
    {
        GameObject go = Instantiate(bulletPrefab, attackBaseSpawnPoint.position, Quaternion.identity);
        go.GetComponent<Bullet>().SetPlayerTransform(playerTransform);
        go.GetComponent<Bullet>().Shoot();
    }

    public void AttackEnd()
    {
        isAttacking = false;
    }
}
