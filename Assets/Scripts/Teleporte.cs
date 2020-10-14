using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Teleporte : MonoBehaviour
{
    public Transform destino;
    public AudioClip audioTeleporte;
    public bool destruirAoColidir = false;
    AudioSource emissorDeSom;
    bool rotinaIniciada = false;

    void Awake(){
        emissorDeSom = GetComponent<AudioSource> ();
        emissorDeSom.playOnAwake = false;
        emissorDeSom.loop = false;
        GetComponent<BoxCollider> ().isTrigger = true;  
    }

    void OnTriggerEnter(Collider other){
        if(destino && !rotinaIniciada){
            other.transform.position = destino.position;
            other.transform.rotation = destino.rotation;
        }

        if(audioTeleporte){
            emissorDeSom.clip = audioTeleporte;
            emissorDeSom.PlayOneShot (emissorDeSom.clip);
        }
    }
}
