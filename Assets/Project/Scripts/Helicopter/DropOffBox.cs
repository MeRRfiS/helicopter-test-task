using HelicopterTest.Scripts.UI;
using UnityEngine;

namespace Helicopter.Scripts.Helicopter
{
    public class DropOffBox : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _boxRigidbody;

        private float _xDropPosition = 0;

        private void Start()
        {
            EventIcon.OnChangeXPosition += ChangeDropPosition;
        }

        private void Update()
        {
            CheckDropPosition();
        }

        private void CheckDropPosition()
        {
            if(transform.position.x >= _xDropPosition)
            {
                Drop();
            }
        }

        private void Drop()
        {
            _boxRigidbody.gravityScale = 1;
            _boxRigidbody.transform.SetParent(transform.parent);
        }

        private void ChangeDropPosition(float newX)
        {
            _xDropPosition = newX;
        }

        private void OnDestroy()
        {
            EventIcon.OnChangeXPosition -= ChangeDropPosition;
        }
    }
}