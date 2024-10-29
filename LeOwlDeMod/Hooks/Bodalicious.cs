using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace LeOwlDeMod.Hooks
{
    public class Bodalicious : MonoBehaviour
    {
        internal static void Initialize(ref AssetBundle bundle, AssetBundle setBundle)
        {
            bundle = setBundle;

            if (bundle == null)
            {
                LeOwlDeMod.Logger.LogInfo($"custom assets file 'bodalicious' not found!");

                return;
            }

            int rarity = 100;
            int price = 10;

            //Register as a spawnable item.
            Item customItem = bundle.LoadAsset<Item>("BodaGrab.asset");
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(customItem.spawnPrefab);
            LethalLib.Modules.Items.RegisterScrap(customItem, rarity, LethalLib.Modules.Levels.LevelTypes.All);

            //Register into the shop.
            TerminalNode terminal = bundle.LoadAsset<TerminalNode>("TerminalNode.asset");
            LethalLib.Modules.Items.RegisterShopItem(customItem, null, null, terminal, price);
        }
    }
}
