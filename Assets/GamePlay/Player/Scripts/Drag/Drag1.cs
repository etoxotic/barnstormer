using UnityEngine;

namespace Player.Drag
{
    public class Drag1 : IDrag
    {
        public float Coefficient(float angle)
        {
            float res;

            if (Mathf.Abs(angle) < 15f)
                res = 1f;
            else
                res = 15f;

            return res;
        }
    }
}