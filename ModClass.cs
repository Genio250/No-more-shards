using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;

namespace Nomoreshards
{
    public class Nomoreshards : Mod
    {
        //int lb = 0;
        public Nomoreshards() : base("No More Shards") { }
        public override string GetVersion() => "1.0";
        public override void Initialize()
        {
            ModHooks.GetPlayerIntHook += ModHooks_GetPlayerIntHook;
            ModHooks.GetPlayerBoolHook += ModHooks_GetPlayerBoolHook;
            ModHooks.LanguageGetHook += ModHooks_LanguageGetHook;
        }

        private string ModHooks_LanguageGetHook(string key, string sheetTitle, string orig)
        {
            //Custom text for the Ancient Mask.
            if (key == "INV_DESC_HEARTPIECE_ALL") return "An ancient artifact that brings unrestrained protection to its wearer, shielding the true form beneath.\n\nTo power it, collect the broken shards of its replicas scattered throughout the world.";
            else return orig;
        }

        private int ModHooks_GetPlayerIntHook(string name, int orig)
        {
            if (name == "MPReserveCap") return 132; //Makes it so Ancient Vessel with appear at 4 vessels
            if (name == "MPReserveMax" && orig > 132) return 132; //Caps vessels at 4 since the fifth breaks the game
            if (name == "heartPieces") return 3; //Sets mask shards constantly at 3 so pickups will always be the 4th
            else if (name == "vesselFragments") return 3; //Same with vessels, but idk why 2 didn't work and had to be 3
            else return orig;
        }
        private bool ModHooks_GetPlayerBoolHook(string name, bool orig)
        {
            if (name == "heartPieceMax") return true; //This makes Ancient Mask always show up
            else return orig;
        }
    }
}