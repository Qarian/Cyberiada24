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
            text.text = runtime?.points.ToString() ?? "N/A";
            // var = [Condition] ? [True] : [False]
            text.text = runtime ==null ? "N/A" : runtime.points.ToString();
        }
    }
}