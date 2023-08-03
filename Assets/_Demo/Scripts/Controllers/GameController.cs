using System;
using System.Collections;
using UnityEngine;

namespace _Demo.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject spiderPrefab;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        public void Spawn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject unit = Instantiate(spiderPrefab);
                var pos =  new Vector2(UnityEngine.Random.Range(-4, -13), UnityEngine.Random.Range(-7, 0));
                unit.transform.position = pos;
            }
        }
    }
}