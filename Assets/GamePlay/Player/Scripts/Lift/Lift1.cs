using UnityEngine;

namespace Player.Lift
{
    public class Lift1 : ILift
    {
        public float Coefficient(float angle)
        {
            float res;

            if (Mathf.Abs(angle) < 15f)
                res = angle;
            else if (Mathf.Abs(angle) < 30f)
                res = Mathf.Sign(angle) * (30f - Mathf.Abs(angle));
            else
                res = 0f;

            return res;
        }
    }
}