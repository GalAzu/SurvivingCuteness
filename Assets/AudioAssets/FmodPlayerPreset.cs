using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creating the possibility to export it as an asset.
[CreateAssetMenu(menuName = "SO/Audio/Player", fileName = "New Player Sheet")]
public class AudioDataPreset : ScriptableObject
{
    [Header("BGM and Ambiance")]
    [FMODUnity.EventRef]
    public string bgm = null;
    [FMODUnity.EventRef]
    public string Ambiance = null;
    [Header("Movement")]
    [FMODUnity.EventRef]
    public string Jump = null;
    [FMODUnity.EventRef]
    public string Landing = null;


    [Header("Casual SFX")]
    [FMODUnity.EventRef]
    public string TrapTrigger = null;
    [FMODUnity.EventRef]
    public string CoinSound = null;
    [FMODUnity.EventRef]
    public string Hit = null;

    [Header("Attack")]
    [FMODUnity.EventRef]
    public string Magic = null;
    [FMODUnity.EventRef]
    public string Melee = null;

    [Header("PowerUps")]
    [FMODUnity.EventRef]
    public string Shield = null;

    [Header("Buffs")]
    [FMODUnity.EventRef]
    public string SlowBuff = null;

}
