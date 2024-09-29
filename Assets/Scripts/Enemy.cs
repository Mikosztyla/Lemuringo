using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform attackBaseSpawnPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("AttackBase");
        } else if (Input.GetKeyDown(KeyCode.CapsLock)) {
            animator.SetTrigger("AttackUp");
        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("AttackTriple");
        }
    }

    public void Attack()
    {
        GameObject go = Instantiate(bulletPrefab, attackBaseSpawnPoint.position, Quaternion.identity);
        go.GetComponent<Bullet>().SetPlayerTransform(playerTransform);
        go.GetComponent<Bullet>().Shoot();
    }
}
