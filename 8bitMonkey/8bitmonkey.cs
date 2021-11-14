
using MelonLoader;
using Harmony;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using System;
using System.Text.RegularExpressions;
using System.IO;
using Assets.Main.Scenes;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Simulation.Track;
using static Assets.Scripts.Models.Towers.TargetType;
using Assets.Scripts.Simulation;
using Assets.Scripts.Models.Towers.Pets;
using Assets.Scripts.Unity.Bridge;
using System.Windows;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Unity.Display;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper;
using Assets.Scripts.Models.Towers.Upgrades;
using HarmonyLib;
using BTD_Mod_Helper.Api;

namespace Tower
{
    public class bitmonkeydisplayxxx : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit000");
        }
    }

    public class bitmonkeydisplay3xx : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit300");
        }
    }
    public class bitmonkeydisplay4xx : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit400");
        }
    }
    public class bitmonkeydisplay5xx : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit500");
        }
    }

    public class bitmonkeydisplayxx3 : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit003");
        }
    }
    public class bitmonkeydisplayxx4 : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit004");
        }
    }
    public class bitmonkeydisplayxx5 : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit005");
        }
    }
    public class bitmonkeydisplayx3x : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit030");
        }
    }
    public class bitmonkeydisplayx4x : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit040");
        }
    }
    public class bitmonkeydisplayx5x : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "8bit050");
        }
    }


    public class bitMonkey : ModTower
    {
        public override string TowerSet => PRIMARY;
        public override string BaseTower => TowerType.DartMonkey;

        public override string Name => "8-bit Monkey";
        public override int Cost => 500;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "8bitmonkeyport";
        public override ParagonMode ParagonMode => ParagonMode.Base555;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        //public override bool Use2DModel => true;
        public override string Description => "Throws a 8 Peirce dart at bloons";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<bitmonkeydisplayxxx>();
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 8;
            attackModel.range = 25;
            towerModel.range = 25;
        }
    }


        public class bit1xx : ModUpgrade<bitMonkey>
        {
            public override string Name => "PlumberRange";
            public override string DisplayName => "Plumber Range";
            public override string Description => "Extra Range";
            public override int Cost => 450;
            public override int Path => TOP;
            public override int Tier => 1;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgrade1xx";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.range += 10;
                towerModel.range += 10;
            }

        }

        public class bit2xx : ModUpgrade<bitMonkey>
        {
            public override string Name => "PlumberJump";
            public override string DisplayName => "Plumber Jump";
            public override string Description => "A high damage";
            public override int Cost => 1250;
            public override int Path => TOP;
            public override int Tier => 2;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgrade1xx";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var weap = Game.instance.model.GetTowerFromId("PatFusty 2").GetAttackModel().weapons[0].Duplicate();
                weap.projectile.GetDamageModel().damage = 4f;
                weap.Rate = 1f;
                weap.projectile.scale = 0.1f;
                attackModel.AddWeapon(weap);
            }

        }

        public class bit3xx : ModUpgrade<bitMonkey>
        {
            public override string Name => "DoubleJump";
            public override string DisplayName => "Double Jump";
            public override string Description => "8-bit Monkey Attacks Two Times Faster";
            public override int Cost => 2500;
            public override int Path => TOP;
            public override int Tier => 3;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgrade1xx";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<bitmonkeydisplay3xx>();
                var attackModel = towerModel.GetAttackModel();
                foreach (WeaponModel wm in attackModel.weapons)
                {
                    wm.Rate *= 0.5f;
                }
            }

        }

        public class bit4xx : ModUpgrade<bitMonkey>
        {
            public override string Name => "TripleJump";
            public override string DisplayName => "Triple Jump";
            public override string Description => "8-bit Monkey Attacks Three Times Faster, does more Moab Damage, and stuns bloons";
            public override int Cost => 21000;
            public override int Path => TOP;
            public override int Tier => 4;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgrade1xx";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<bitmonkeydisplay4xx>();
                var attackModel = towerModel.GetAttackModel();
                foreach (WeaponModel wm in attackModel.weapons)
                {
                    wm.Rate *= 0.333f;
                    wm.projectile.AddBehavior(new DamageModifierForTagModel("Moabs", "Moabs", 1.0f, 6.0f, false, true));
                    wm.projectile.AddBehavior(Game.instance.model.GetTowerFromId("SuperMonkey-001").GetWeapon().projectile.GetBehavior<KnockbackModel>());
                }
            }

        }

        public class bit5xx : ModUpgrade<bitMonkey>
        {
            public override string Name => "BLJ";
            public override string DisplayName => "BLJ";
            public override string Description => "yah yah yah yah yah yah yahoo!";
            public override int Cost => 64000;
            public override int Path => TOP;
            public override int Tier => 5;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgrade5xx";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<bitmonkeydisplay5xx>();
                var attackModel = towerModel.GetAttackModel();
                foreach (WeaponModel wm in attackModel.weapons)
                {
                    wm.projectile.GetDamageModel().damage += 12f;
                    wm.Rate *= 0.333f;
                }
            }

        }

        public class bitxx1 : ModUpgrade<bitMonkey>
        {
            public override string Name => "HomingDarts";
            public override string DisplayName => "Homing Darts";
            public override string Description => "Darts Gain Homing Capabilities";
            public override int Cost => 700;
            public override int Path => BOTTOM;
            public override int Tier => 1;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgradexx1";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>().Duplicate());
            }

        }

        public class bitxx2 : ModUpgrade<bitMonkey>
        {
            public override string Name => "Lasers";
            public override string DisplayName => "Lasers";
            public override string Description => "Darts become Laser and can now pop lead and gain more peirce";
            public override int Cost => 500;
            public override int Path => BOTTOM;
            public override int Tier => 2;
            public override string Portrait => "8bitmonkeyport";
            public override string Icon => "upgradexx1";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                projectile.pierce += 4;
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.display = Game.instance.model.GetTowerFromId("SuperMonkey-100").GetAttackModel().weapons[0].projectile.display;
        }

    }

    public class bitxx3 : ModUpgrade<bitMonkey>
    {
        public override string Name => "MegaMonkey";
        public override string DisplayName => "MegaMonkey";
        public override string Description => "8-bit Monkey shoots faster and deals more damage";
        public override int Cost => 4400;
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradexx1";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<bitmonkeydisplayxx3>();
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            attackModel.weapons[0].Rate -= 0.3f;
            projectile.GetDamageModel().damage += 2f;
        }

    }

    public class bitxx4 : ModUpgrade<bitMonkey>
    {
        public override string Name => "DoomMonkey";
        public override string DisplayName => "DoomMonkey";
        public override string Description => "Lasers Explode on contanct with bloons";
        public override int Cost => 9500;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradexx1";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<bitmonkeydisplayxx4>();
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
            projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
            projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
            projectile.AddBehavior(new DamageModifierForTagModel("Moabs", "Moabs", 1.0f, 14.0f, false, true));
            projectile.pierce += 6;
            attackModel.range += 5;
            towerModel.range += 5;
        }

    }

    public class bitxx5 : ModUpgrade<bitMonkey>
    {
        public override string Name => "MonkeyCheif";
        public override string DisplayName => "MonkeyCheif";
        public override string Description => "The Master of Shoots 3 lasers at a time and deals more Damage";
        public override int Cost => 40000;
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradexx5";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<bitmonkeydisplayxx5>();
            towerModel.GetWeapon().emission = new ArcEmissionModel("MonkeyCheif3", 3, 0, 20, null, false);
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDamageModel().damage += 12f;
            attackModel.range += 10;
            towerModel.range += 10;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetect", true));
        }

    }

    public class x1x : ModUpgrade<bitMonkey>
    {
        public override string Name => "Haste";
        public override string DisplayName => "Haste";
        public override string Description => "8-bit Monkey Attacks Faster";
        public override int Cost => 150;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradex1x";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            foreach (WeaponModel wm in attackModel.weapons)
            {
                wm.Rate -= 0.1f;
            }
        }

    }

    public class x2x : ModUpgrade<bitMonkey>
    {
        public override string Name => "Haste II";
        public override string DisplayName => "Haste II";
        public override string Description => "The Factories Act 1844 banned women and young adults from working more than 12-hour days and children from the ages 9 to 13 from working 9-hour days. The Factories Act 1847, also known as the Ten Hours Act, made it illegal for women and young people (13-18) to work more than 10 hours and maximum 63 hours a week in textile mills. The last two major factory acts of the Industrial Revolution were introduced in 1850 and 1856. Factories could no longer dictate work hours for women and children, who were to work from 6 a.m. to 6 p.m. in the summer and 7 a.m. to 7 p.m. in the winter. These acts deprived the manufacturers of a significant amount of power and authority. - lumenlearning.com";
        public override int Cost => 200;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradex1x";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            foreach (WeaponModel wm in attackModel.weapons)
            {
                wm.Rate -= 0.15f;
            }
        }

    }

    public class x3x : ModUpgrade<bitMonkey>
    {
        public override string Name => "ManicMonkey";
        public override string DisplayName => "Manic Monkey";
        public override string Description => "8-bit Monkey generates money on attack";
        public override int Cost => 900;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradex1x";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<bitmonkeydisplayx3x>();
            var attackModel = towerModel.GetAttackModel();
            var MinerCash = Game.instance.model.GetTowerFromId("BananaFarm-003").GetWeapon().projectile.GetBehavior<CashModel>().Duplicate<CashModel>();
            var MinerText = Game.instance.model.GetTowerFromId("BananaFarm-003").GetWeapon().projectile.GetBehavior<CreateTextEffectModel>().Duplicate<CreateTextEffectModel>();
            MinerCash.minimum = 5f;
            MinerCash.maximum = 5f;
            attackModel.weapons[0].projectile.AddBehavior(MinerCash);
            attackModel.weapons[0].projectile.AddBehavior(MinerText);
        }

    }

    public class MineDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Mines");
        }
    }

    public class x4x : ModUpgrade<bitMonkey>
    {
        public override string Name => "MonkeySweeper";
        public override string DisplayName => "Monkey Sweeper";
        public override string Description => "8-bit Monkey generates more money on attack and drops emotional support mines on the track";
        public override int Cost => 9500;
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradex1x";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            towerModel.ApplyDisplay<bitmonkeydisplayx4x>();
            attackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 15;
            attackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 15;
            var weapon1 = Game.instance.model.GetTowerFromId("SpikeFactory-400").GetAttackModel().weapons[0].Duplicate();
            weapon1.projectile.ApplyDisplay<MineDisplay>();
            weapon1.projectile.GetDamageModel().damage = 1f;
            attackModel.AddWeapon(weapon1);
            attackModel.range += 5;
            towerModel.range += 5;
        }

    }

    public class x5x : ModUpgrade<bitMonkey>
    {
        public override string Name => "Monkey Craft";
        public override string DisplayName => "Monkey Craft";
        public override string Description => "8-bit Monkey generates even more money and attacks faster";
        public override int Cost => 35000;
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override string Portrait => "8bitmonkeyport";
        public override string Icon => "upgradex5x";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 100;
            attackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 100;
            towerModel.ApplyDisplay<bitmonkeydisplayx5x>();
            foreach (WeaponModel wm in attackModel.weapons)
            {
                wm.Rate -= 0.4f;
            }
            attackModel.range += 5;
            towerModel.range += 5;
        }

    }

    public class UpscaledDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "upscaled");
        }
    }


    public class Upscaled : ModParagonUpgrade<bitMonkey>
    {
        public override int Cost => 4000000;
        public override string Description => "A Powerful Monkey With The Power of Upscaling";
        public override string DisplayName => "256-bit Upscaled";
        public override string Icon => "bitparagon";
        public override string Portrait => "8bitmonkeyport";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<UpscaledDisplay>();
            towerModel.GetBehavior<ParagonTowerModel>().displayDegreePaths.ForEach(path => path.assetPath = ModContent.GetDisplayGUID<UpscaledDisplay>());
        }
    }
}