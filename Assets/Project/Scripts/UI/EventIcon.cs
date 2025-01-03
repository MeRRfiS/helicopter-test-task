using System;
using UnityEngine;
using UnityEngine.UI;

namespace HelicopterTest.Scripts.UI
{
    public class EventIcon : MonoBehaviour
    {
        [SerializeField] private Transform _handlerTransform;
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private LineRenderer _dottedLine;

        public static event Action<float> OnChangeXPosition;

        private void Start()
        {
            _scrollbar.onValueChanged.AddListener(OnChangeIconPosition);
        }

        private void OnChangeIconPosition(float _)
        {
            float newXPosition = _handlerTransform.position.x;
            for (int i = 0; i < _dottedLine.positionCount; i++)
            {
                var oldPosition = _dottedLine.GetPosition(i);
                _dottedLine.SetPosition(i, new Vector3(newXPosition, oldPosition.y, oldPosition.z));
            }

            OnChangeXPosition?.Invoke(newXPosition);
        }

        private void OnDestroy()
        {
            _scrollbar.onValueChanged.RemoveAllListeners();
        }
    }
}