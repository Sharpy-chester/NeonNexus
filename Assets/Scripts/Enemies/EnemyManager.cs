using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        public List<Enemy> enemies;
        public float enemyRenderDist = 40.0f;

        private static EnemyManager _instance;
        public static EnemyManager Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

        }


        void Start()
        {
            StartCoroutine(TurnEnemiesOnAndOff());
        }

        private IEnumerator TurnEnemiesOnAndOff()
        {
            yield return null;
            while (enemies.Count > 0)
            {
                List<Enemy> enemiesToTurnOff = enemies.Where(enemy => enemy.gameObject.activeSelf && enemy.DistToPlayer() > enemyRenderDist).ToList();
                if (enemiesToTurnOff != null)
                {
                    foreach (Enemy e in enemiesToTurnOff)
                    {
                        e.gameObject.SetActive(false);
                    }
                }
                List<Enemy> enemiesToTurnOn = enemies.Where(enemy => !enemy.gameObject.activeSelf && enemy.DistToPlayer() <= enemyRenderDist).ToList();
                if (enemiesToTurnOn != null)
                {
                    foreach (Enemy e in enemiesToTurnOn)
                    {
                        e.gameObject.SetActive(true);
                        yield return null;
                    }
                }
                enemiesToTurnOff.Clear();
                enemiesToTurnOn.Clear();
                yield return null;
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }
    }
}

