using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace itens
{

    public class ItemCollectableBase : MonoBehaviour
    {
        public ItemType itemType;
        public Collider Collider;

        public string compareTag = "Player";
        public ParticleSystem ParticleSystem;
        public float timeToHide = 0.1f;
        public GameObject graphicItem;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake()
        {
        
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            if (Collider != null)  { Collider.enabled = false; };
            if(graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if(ParticleSystem != null) ParticleSystem.Play();
            if(audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
        }


    }

}