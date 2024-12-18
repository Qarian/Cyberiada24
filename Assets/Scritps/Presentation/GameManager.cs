using System;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float customScale;
        [SerializeField] private bool pause;

        [SerializeField] private float interval = 0.5f;
        
        private List<IUnit> allUnits = new List<IUnit>();
        
        private int currentFrame = 0;

        private void Update()
        {
            if (pause) return;
            
            currentFrame++;

            if (currentFrame % interval != 0) return;

            for (int i = 0; i < 2; i++)
            {
                foreach (var unit in allUnits)
                {
                    unit.CustomUpdate(Time.deltaTime * customScale);
                }
            }
        }
    }
}