using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class Flipper : MonoBehaviour
    {
        private HingeJoint2D _joint2D;

        void Awake()
        {
            _joint2D = GetComponent<HingeJoint2D>();
        }
        void Update()
        {
        
        }
    }
}