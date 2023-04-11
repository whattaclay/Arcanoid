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
        public static BallsManager Instance => _instance;
        private static BallsManager _instance;
        private void Awake()
        {
            _instance = this;
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