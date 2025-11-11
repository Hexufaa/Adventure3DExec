using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cloth
{

    public class ClothItemStrong : ClothItemBase
    {
        public float DamageMultiply = 5f;

        public override void Collect()
        {
            base.Collect();
            PlayerControllerTurning.Instance.healthBase.ChangeDamageMultiply(DamageMultiply, duration);

        }

    }
}