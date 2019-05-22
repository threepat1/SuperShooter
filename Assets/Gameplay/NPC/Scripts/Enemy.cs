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
        float timer;
        public float timeBetweenAttacks = 1f;

        public Transform playPos;
        private NavMeshAgent nav;

        public GameObject player;

        bool playerInRange;
 
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
        public void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            nav = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == ("Player"))
            {
                
                print("yes!!");
                playerInRange = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject.tag == "Player")
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }

        }
        void Update()
        {
            nav.SetDestination(playPos.position);
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && playerInRange) // && enemyHealth.currentHealth > 0
            {
                // ... attack.
                Attack();
            }

            // If the player has zero or less health...
            if (health <= 0)
            {
                // ... tell the animator the player is dead.
                //  anim.SetTrigger("PlayerDead");
            }
        }


        void Attack()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if (health > 0)
            {
                // ... damage the player.
                DealDamage(damage);
            }
        }
    }


    }

