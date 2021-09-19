using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    Toggle genitiv;
    [SerializeField]
    Toggle genus;
    [SerializeField]
    Toggle firstStammform;
    [SerializeField]
    Toggle secondStammform;

    [SerializeField]
    Toggle pppStammform;

    [SerializeField]
    Toggle adjectiveGenitiv;

    void Awake()
    {
        PlayerPrefs.SetInt("Genitiv",0);
        PlayerPrefs.SetInt("Genus",0);
        PlayerPrefs.SetInt("FirstStammform",0);
        PlayerPrefs.SetInt("SecondStammform",0);
        PlayerPrefs.SetInt("PPPStammform",0);
        PlayerPrefs.SetInt("AdjektivGenitiv",0);
    }


    public void ToggleGenitiv()
    {
        if(genitiv.isOn)
        {
            PlayerPrefs.SetInt("Genitiv",1);
        
        }else
        {
            PlayerPrefs.SetInt("Genitiv",0);
        }
    }
    public void ToggleGenus(){
        if(genus.isOn)
        {
            PlayerPrefs.SetInt("Genus",1);
        
        }else
        {
            PlayerPrefs.SetInt("Genus",0);
        }

    }
    public void ToggleFirstStammform(){
        if(firstStammform.isOn)
        {
            PlayerPrefs.SetInt("FirstStammform",1);
        
        }else
        {
            PlayerPrefs.SetInt("FirstStammform",0);
        }
    }
    public void ToggleSecondStammform(){
        if(secondStammform.isOn)
        {
            PlayerPrefs.SetInt("SecondStammform",1);
        
        }else
        {
            PlayerPrefs.SetInt("SecondStammform",0);
        }
    }
    public void TogglePPPStammform(){
        if(pppStammform.isOn)
        {
            PlayerPrefs.SetInt("PPPStammform",1);
        
        }else
        {
            PlayerPrefs.SetInt("PPPStammform",0);
        }
    }

    public void ToggleAdjectivGenitiv(){
        if(adjectiveGenitiv.isOn)
        {
            PlayerPrefs.SetInt("AdjektivGenitiv",1);
        }else{
            PlayerPrefs.SetInt("AdjektivGenitiv",0);
        }
    }
}
