﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperShooter
{

    public class Invisibility : MonoBehaviour
    {
        public float invisTime = 5.0f;

        private MeshRenderer playerRend;

        // ------------------------------------------------- //

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == ("Player"))
            {
                playerRend = other.gameObject.GetComponent<MeshRenderer>();
                this.gameObject.SetActive(false);
            }
        }

        // ------------------------------------------------- //

        private void Update()
        {

            if (playerRend)
            {
                playerRend.enabled = false;

                invisTime -= Time.deltaTime;

                if (invisTime <= 0)
                {
                    playerRend.enabled = true;

                    playerRend = null;
                }

            }
        }

        // ------------------------------------------------- //

        public void Pickup()
        {
            throw new System.NotImplementedException();
        }

        public void Drop()
        {
            throw new System.NotImplementedException();
        }

        public string GetDisplayName()
        {
            return "Cloaking Device";
        }

        // ------------------------------------------------- //


    }

}