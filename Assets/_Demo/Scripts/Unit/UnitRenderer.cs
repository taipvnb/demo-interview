using Sirenix.OdinInspector;
using UnityEngine;

namespace _Demo.Scripts
{
    public enum FACETYPE
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public class UnitRenderer : MonoBehaviour
    {
        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public FACETYPE currentFaceType;


        [BoxGroup("References", ShowLabel = false)] [TitleGroup("References/References")]
        public Animator animator;

        public void UpdateDirection(FACETYPE _faceType)
        {
            currentFaceType = _faceType;
            switch (_faceType)
            {
                case FACETYPE.UP:
                    animator.SetInteger("State",1);
                    break;
                case FACETYPE.DOWN:
                    animator.SetInteger("State",2);
                    break;
                case FACETYPE.RIGHT:
                    animator.SetInteger("State",3);
                    break;
                case FACETYPE.LEFT:
                    animator.SetInteger("State",4);
                    break;
            }
           
        }
    }
}