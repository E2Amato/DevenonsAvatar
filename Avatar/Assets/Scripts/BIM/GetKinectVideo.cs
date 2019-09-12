﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKinectVideo : MonoBehaviour {

    // get current scenario item and wait for "Project User"
    // copy material of videoCameraPlane into ui image

    // then record KinectVideo zone !!
    // script BlackMagic (qui utilise Rock.VR) sur objet SensorRecorderManager
    // changer camera

    // doute : changer texture du material ou changer image de l'objet Image (UI) ??
    // possibilité d'afficher la vidéo Kinect dès le lancement de l'app pour prévisualiser le placement de l'utilisateur

    public CharacterControllerBasedOnAxis characterController;
    public GameObject videoCameraPlane;
    public Image image;
    Sprite _currentSprite;

	// Use this for initialization
	void Start () {
        DisplayKinectVideo();
    }

    // Update is called once per frame
    void Update () {
		/*if (CharacterControllerBasedOnAxis.currentScenarioItem == 1)
        {
            if (videoCameraPlane != null)
            {
                image.material.mainTexture = videoCameraPlane.GetComponent<Renderer>().material.mainTexture;
            }
        }*/
	}

    // Display Kinect video from the beginning
    // Si ne marche pas à cause de l'initialisation du manager faire Coroutine
    private void DisplayKinectVideo()
    {
        KinectManager manager = KinectManager.Instance;
        Debug.Log(manager);
        if (manager && manager.IsInitialized())
        {
            image.material.mainTexture = manager.GetUsersClrTex();
        }
        
    }
}