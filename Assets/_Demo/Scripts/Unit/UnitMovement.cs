using System;
using System.Collections;
using System.Collections.Generic;
using _Demo.Scripts.AStar;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Demo.Scripts
{
    public class UnitMovement : MonoBehaviour
    {
        [BoxGroup("Data", ShowLabel = false)] [TitleGroup("Data/Cache Data")] [SerializeField]
        private UnitRenderer unitRenderer;
        
        [BoxGroup("Data", ShowLabel = false)] [TitleGroup("Data/Cache Data")] [SerializeField]
        private int movementPoints = 20;

        [BoxGroup("Config", ShowLabel = false)] [TitleGroup("Config/Config")]
        public bool isRotation;
        
        public float movement =  0.25f;

        public int MovementPoints
        {
            get => movementPoints;
        }

        private Vector3 currentTarget;
        private Queue<Node2D> pathPositions = new Queue<Node2D>();
        protected Node2D lastDestinyNode;
        public event Action<UnitMovement> MovementFinished;

        public void RemoveCurrentCoroutine()
        {
            StopAllCoroutines();
        }

        public void MoveThroughPath(List<Node2D> currentPath)
        {
            if (lastDestinyNode != null && currentPath[0] != lastDestinyNode)
            {
                currentPath.Insert(0,lastDestinyNode);
                lastDestinyNode = null;
            }
            pathPositions.Clear();
            pathPositions = new Queue<Node2D>(currentPath);
            Node2D firstNode = pathPositions.Dequeue();
            StartCoroutine(MovementCoroutine(firstNode));
        }

        private IEnumerator MovementCoroutine(Node2D targetNode)
        {
            lastDestinyNode = targetNode;
            
            var endPosition = targetNode.worldPosition;
            currentTarget = endPosition;
            Vector3 startPosition = transform.position;
            float timeElapsed = 0;

            Vector3 direction = endPosition - startPosition;

            if (isRotation)
            {
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

                if (direction == Vector3.right)
                {
                    unitRenderer.UpdateDirection(FACETYPE.RIGHT);
                }
                else if (direction == Vector3.left)
                {
                    unitRenderer.UpdateDirection(FACETYPE.LEFT);
                }
                else if (direction == Vector3.up)
                {
                    unitRenderer.UpdateDirection(FACETYPE.UP);
                }
                else if (direction == Vector3.down)
                {
                    unitRenderer.UpdateDirection(FACETYPE.DOWN);
                }
            }

            while (timeElapsed < movement)
            {
                timeElapsed += Time.deltaTime;
                float lerpStep = timeElapsed / movement;
                transform.position = Vector3.Lerp(startPosition, endPosition, lerpStep);
                yield return null;
            }

            transform.position = endPosition;

            if (pathPositions.Count > 0)
            {
                Node2D nextNode = pathPositions.Dequeue();
                
                StartCoroutine(MovementCoroutine(nextNode));
            }
            else
            {
                currentTarget = Vector3.zero;
                MovementFinished?.Invoke(this);
                gameObject.SetActive(false);
                lastDestinyNode = null;
            }
        }
    }
}