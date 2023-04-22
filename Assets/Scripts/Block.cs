﻿using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    
    public class Block : MonoBehaviour
    {
        public ElementName Element => _elementName;
        
        [SerializeField] private ElementName _elementName;
        [SerializeField] private int _hp = 5;
        [SerializeField] private TextMeshPro _hpText;
        public bool IsDestroyed { get; private set; } = false;

        private void Awake()
        {
            _hpText.text = _hp.ToString();
        }

        public void Damage(int damage)
        {
            _hp-= damage;
            _hpText.text = _hp.ToString();
            if (_hp <= 0)
            {
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
    }
}