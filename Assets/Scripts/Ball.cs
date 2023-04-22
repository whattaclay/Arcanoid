using System;
using Configs;
using UnityEngine;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private ElementsConfig _elements;
        [SerializeField] private ElementName _firstElement = ElementName.Water;
        [SerializeField] private float _constantSpeed = 10f;

        private Rigidbody2D _rigidbody;
        
        private ElementConfig _currentElement;

        private void Awake()
        {
            ChangeElement(_firstElement);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            /*var otherBlock = collision.transform.GetComponent<Block>();
            if (otherBlock == null) return;*/

            if (collision.transform.TryGetComponent<Block>(out Block otherBlock))
            {
                if (_currentElement.Name == otherBlock.Element || otherBlock.Element == ElementName.None)
                {
                    BlockManager.Instance.DamageBlock(otherBlock);
                }
                else
                {
                    ChangeElement(otherBlock.Element);
                }
               
            }
            if (collision.transform.TryGetComponent<KillPlane>(out KillPlane _))
            {
                BallsManager.Instance.DestroyBall(this);
            }
        }

        private void FixedUpdate()
        {
            var currentVel = _rigidbody.velocity;
            if (currentVel.magnitude < _constantSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _constantSpeed;
            }
        }

        private void ChangeElement(ElementName otherElement)
        {
            var _allElements = _elements.Elements;

            ElementConfig newElementConfig = null;

            foreach (var e in _allElements)
            {
                if (e.Name == otherElement)
                {
                    newElementConfig = e;
                    break;
                }
            }

            var renderer = GetComponent<Renderer>();
            renderer.sharedMaterial = newElementConfig.Material;

            _currentElement = newElementConfig;
        }
    }
}