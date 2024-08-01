﻿using BepInEx;
using GorillaWatch.Patches;
using System;
using UnityEngine;
using Utilla;

namespace GorillaWatch
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.GorillaDaan.gorillatag.GorillaWatch", "GorillaWatch", "1.0.0")]
    public class Mod : BaseUnityPlugin
    {
        bool inRoom;

        public static int counter;

        public static float PageCoolDown;

        public static bool ToggleMod1;

        public static bool ToggleMod2;
        
        public static bool ToggleMod3;        
        
        public static bool ToggleMod4;
        
        public static bool ToggleMod5;
        
        public static bool ToggleMod6;

        public static GameObject leftplat = null;

        public static GameObject rightplat = null;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            if (inRoom)
            {
                GorillaTagger.Instance.offlineVRRig.EnableHuntWatch(true);
                GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().enabled = false;
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().material);
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().badge);
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().leftHand);
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().rightHand);
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().hat);
                GameObject.Destroy(GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().face);
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= .5f && Time.time > PageCoolDown + 0.5)
                {
                    PageCoolDown = Time.time;
                    counter++;
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, true, 1f);
                }
                if (ControllerInputPoller.instance.leftControllerIndexFloat >= .5f && Time.time > PageCoolDown + 0.5)
                {
                    PageCoolDown = Time.time;
                    counter--;
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, true, 1f);
                }
                if (counter < 0)
                {
                    counter = 6;
                }
                if (counter > 6)
                {
                    counter = 0;
                }
                if (counter == 0)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "GorillaWatch!";
                }
                if (counter == 1)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "PlatformGuy- " + ToggleMod1.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        ToggleMod1 = !ToggleMod1;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                    }
                }  
                if (counter == 2)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "HoverMonke-- " + ToggleMod6.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                        ToggleMod6 = !ToggleMod6;
                    }
                }                
                if (counter == 3)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "VelocityFly-- " + ToggleMod2.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        ToggleMod2 = !ToggleMod2;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                    }
                } 
                if (counter == 4)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "NoGravity-- " + ToggleMod5.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        ToggleMod5 = !ToggleMod5;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                    }
                }                
                if (counter == 5)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "BigMonkers---" + ToggleMod3.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        ToggleMod3 = !ToggleMod3;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                    }
                }                
                if (counter == 6)
                {
                    GorillaTagger.Instance.offlineVRRig.huntComputer.GetComponent<GorillaHuntComputer>().text.text = "SmallMonkers--" + ToggleMod4.ToString();
                    if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > PageCoolDown + .5)
                    {
                        PageCoolDown = Time.time;
                        ToggleMod4 = !ToggleMod4;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(69, true, 1f);
                    }
                }
                if (ToggleMod1)
                {
                    Vector3 leftOffset = new Vector3(0f, -0.06f, 0f);
                    Vector3 rightOffset = new Vector3(0f, -0.06f, 0f);

                    if (ControllerInputPoller.instance.leftGrab)
                    {
                        if (leftplat == null)
                        {
                            leftplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            leftplat.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                            leftplat.transform.position = GorillaTagger.Instance.leftHandTransform.position + leftOffset;
                            leftplat.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                            leftplat.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                            leftplat.GetComponent<Renderer>().material.color = Color.black;
                        }
                    }
                    else
                    {
                        if (leftplat != null)
                        {
                            GameObject.Destroy(leftplat, .2f);
                            leftplat = null;
                        }
                    }
                    if (ControllerInputPoller.instance.rightGrab)
                    {
                        if (rightplat == null)
                        {
                            rightplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            rightplat.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                            rightplat.transform.position = GorillaTagger.Instance.rightHandTransform.position + rightOffset;
                            rightplat.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                            rightplat.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                            rightplat.GetComponent<Renderer>().material.color = Color.black;
                        }
                    }
                    else
                    {
                        if (rightplat != null)
                        {
                            GameObject.Destroy(rightplat, .2f);
                            rightplat = null;
                        }
                    }
                }
                if (ToggleMod6)
                {
                    if (ControllerInputPoller.instance.leftControllerGripFloat > .5)
                    {
                        GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(10 * GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").right, ForceMode.Acceleration);
                        GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                    }
                    if (ControllerInputPoller.instance.rightControllerGripFloat > .5)
                    {
                        GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(10 * -GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").right, ForceMode.Acceleration);
                        GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                    }
                }
                if (ToggleMod2)
                {
                    if (ControllerInputPoller.instance.leftControllerSecondaryButton)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 1400f;
                    }
                }
                if (ToggleMod5)
                {
                    if (ControllerInputPoller.instance.rightControllerSecondaryButton)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Acceleration);
                    }
                }
                if (ToggleMod3)
                {
                        GorillaLocomotion.Player.Instance.scale = 2f;
                }
                if (ToggleMod4)
                {
                        GorillaLocomotion.Player.Instance.scale = .5f;
                }
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            //Activate your mod here
            //ModName();

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            //Deactivate your mod here
            //!ModName();

            inRoom = false;
        }

        
    }
}
