using UnityEngine;

namespace GMPR2512.Lesson09Platformer
{
    public class Shooter : MonoBehaviour
    {
        private Transform _lastObjectHit;

        [SerializeField] private float _laserLength = 8;
        [SerializeField] private float _rotationSpeed = 50;
        private LineRenderer _laserLine;

        void Awake()
        {
            if(_laserLine == null)
                _laserLine = GetComponent<LineRenderer>();
            if(_laserLine != null)
                {
                    _laserLine.positionCount = 2;
                    _laserLine.useWorldSpace = true;
                    _laserLine.startWidth = 0.05f;
                    _laserLine.endWidth = 0.05f;
                }
        }

        void Update()
        {
            #region rotation
            // float rotationInput = 0;

            // if(Input.GetKey(KeyCode.Comma))
            // {
            //     rotationInput = 200;
            // }
            // else if(Input.GetKey(KeyCode.Period))
            // {
            //     rotationInput = -200;
            // }
            
            transform.parent.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
            #endregion
            
            int layerMask = LayerMask.GetMask("Player");
            RaycastHit2D rh2d =
                Physics2D.Raycast(transform.position, -transform.right, _laserLength, layerMask);
            
            Vector3 endPoint = transform.position + -transform.right * _laserLength;
            if(rh2d.collider != null)
                endPoint = rh2d.point;

            _laserLine?.SetPosition(0, transform.position);
            _laserLine?.SetPosition(1, endPoint);
            

            #region consequences of hitting things with the laser
            if(rh2d.transform != null)
                Destroy(rh2d.transform.gameObject);
            // if(rh2d.transform != null)
            // {
            //     rh2d.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;

            //     if(_lastObjectHit != null && rh2d.transform != _lastObjectHit)
            //         _lastObjectHit.gameObject.GetComponent<Renderer>().material.color = Color.white;

            //      _lastObjectHit = rh2d.transform;
            // }
            // else if(_lastObjectHit != null)
            //     _lastObjectHit.gameObject.GetComponent<Renderer>().material.color = Color.white;
            #endregion

        }

        // void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.yellowNice;
        //     Gizmos.DrawRay(transform.position, transform.right * 10);
        // }

    }
}
