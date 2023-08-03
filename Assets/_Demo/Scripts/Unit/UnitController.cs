using System;
using System.Collections;
using _Demo.Scripts.AStar;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Demo.Scripts
{
    public class UnitController : MonoBehaviour
    {
        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public Pathfinding2D pathfinding;

        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public UnitMovement unitMovement;

        public Vector2Int startCoor;

        private void Start()
        {
            startCoor = (Vector2Int)MapController.Instance.grid.WorldToCell(transform.position);
            StartCoroutine(Run());
        }

        void FindPath(Vector3 targetPos)
        {
            pathfinding.FindPath(transform.position, targetPos);
        }

        IEnumerator Run()
        {
            yield return new WaitForEndOfFrame();
            FindPath(MapController.Instance.destination.position);

        }

        [Button("Test")]
        public void TestRun()
        {
            FindPath(MapController.Instance.destination.position);
        }
    }
}