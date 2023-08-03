using _Demo.Scripts.EazyEngine.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Demo.Scripts
{
    public class MapController : Singleton<MapController>
    {
        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public Grid grid;
        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public Transform destination;
    }
}