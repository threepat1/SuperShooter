using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SuperShooter
{

    public class Enemy : MonoBehaviour
    {

        public int health = 100;
        public int damage = 25;

        public float attackDelay = 10;
        float lastAttacked = -10;

        public FPSController player;
        public Transform target;
        private NavMeshAgent nav;
        float targetDistance;

        // ------------------------------------------------- //

        public void DealDamage(int amount)
        {
            // Deal DMG
            health -= amount;

            // Dead
            if (health <= 0)
                Destroy(gameObject);
        }


        // ------------------------------------------------- //
        public void Start()
        {
            nav = GetComponent<NavMeshAgent>();
        }


        void Update()
        {
            if (targetDistance < 30f)
            {
                nav.SetDestination(target.position);
            }

            targetDistance = Vector3.Distance(target.position, transform.position);
            if (targetDistance < 1.4f)
            {
                Attack();
            }
        }
        public void Attack()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {

                    if (Time.time > lastAttacked + attackDelay)
                    {

                        if (player.health > 0)
                        {
                            player.TakeDamage(10); //make player take damage    
                        }
                        lastAttacked = Time.time;
                    }
                }
            }




        }
    }
}
