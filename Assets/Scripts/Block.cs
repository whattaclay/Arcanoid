﻿using Configs;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class Block : MonoBehaviour
    {
        public ElementName Element => _elementName;
        
        [SerializeField] private ElementName _elementName;
        [SerializeField] private int _hp = 5;
        public bool IsDestroyed { get; private set; } = false;
        public void Damage(int damage)
        {
            _hp-= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
    }
}