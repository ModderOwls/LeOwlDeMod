using System;
using UnityEngine;

namespace LeOwlDeMod.Hooks
{
    public class BodaliciousBoomBox : MonoBehaviour
    {
        internal static void BoomboxItem_Start(Action<BoomboxItem> original, BoomboxItem self)
        {
            original(self);

            Transform boda = Instantiate(LeOwlDeMod.prefabBodalicious).transform;
            boda.position = new Vector3(4.4f, 0.3f, -14);
            boda.localScale = Vector3.one;
        }
    }
}
