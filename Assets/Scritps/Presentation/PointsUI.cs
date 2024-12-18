using System;
using TMPro;
using UnityEngine;

namespace Presentation
{
    public class PointsUI : MonoBehaviour
    {
        [SerializeField] private GameplayRuntime runtime;
        
        [SerializeField] private TMP_Text text;

        private void Update()
        {
            text.text = runtime.points.ToString();
        }
    }
}