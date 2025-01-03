using DG.Tweening;
using UnityEngine;

namespace HelicopterTest.Scripts.Helicopter
{
    public class HelicopterMovement : MonoBehaviour
    {
        [SerializeField] private float _startXPosition;
        [SerializeField] private float _endXPosition;
        [SerializeField] private float _time;

        private void Start()
        {
            StartMovement();
        }

        private void StartMovement()
        {
            transform.DOLocalMoveX(_endXPosition, _time).SetEase(Ease.Linear).OnComplete(() =>
            {
                var oldPosition = transform.localPosition;
                transform.localPosition = new Vector3(_startXPosition, oldPosition.y, oldPosition.z);
            }).SetLoops(-1, LoopType.Restart);
        }
    }
}