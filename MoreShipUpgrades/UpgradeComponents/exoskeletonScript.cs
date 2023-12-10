﻿using GameNetcodeStuff;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MoreShipUpgrades.UpgradeComponents
{
    internal class exoskeletonScript : BaseUpgrade
    {
        
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            UpgradeBus.instance.UpgradeObjects.Add("Back Muscles", gameObject);
        }

        public override void Increment()
        {
            UpgradeBus.instance.backLevel++;

            foreach( CustomTerminalNode node in UpgradeBus.instance.terminalNodes )
            {
                if(node.Name.ToLower() == "back muscles")
                {
                    node.Description = $"Carry weight becomes %{Mathf.Round((UpgradeBus.instance.cfg.CARRY_WEIGHT_REDUCTION - (UpgradeBus.instance.cfg.CARRY_WEIGHT_INCREMENT * UpgradeBus.instance.backLevel)) * 100f)} of original";
                }
            }

        }

        public override void load()
        {
            UpgradeBus.instance.exoskeleton = true;
            HUDManager.Instance.chatText.text += "\n<color=#FF0000>Back Muscles is active!</color>";
        }

        public override void Register()
        {
            if(!UpgradeBus.instance.UpgradeObjects.ContainsKey("Back Muscles")) { UpgradeBus.instance.UpgradeObjects.Add("Back Muscles", gameObject); }
        }
    }
}
