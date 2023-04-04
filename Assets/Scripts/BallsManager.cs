using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DefaultNamespace
{
    public class BallsManager : MonoBehaviour
    {
        private HashSet<Ball> _balls = new HashSet<Ball>();
        [SerializeField] private GameStateManager _gameStateManager;
        private void Awake()
        {
            _balls = FindObjectsOfType<Ball>().ToHashSet();
        }

        public void DestroyBall(Ball ball)
        {
            Destroy(ball.gameObject);
            _balls.Remove(ball);

            if (_balls.Count == 0)
            {
                _gameStateManager.Lose();
            }
        }
    }
}