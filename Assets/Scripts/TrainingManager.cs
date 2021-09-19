using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TrainingManager : MonoBehaviour
{
    [SerializeField]
    GameObject processor;
    [Space]
    [SerializeField]
    GameObject genitivInputContainer;
    [SerializeField]
    GameObject genusInputContainer;
    [Space]
    [SerializeField]
    GameObject firstStammformInputContainer;

    [SerializeField]
    GameObject secondStammformInputContainer;

    [SerializeField]
    GameObject pppInputContainer;
    [Space]
    [SerializeField]
    GameObject GenitivAdjektivInputContainer;

    [Space]
    [SerializeField]
    GameObject substantivInputs;

    [SerializeField]
    GameObject verbInputs;

    [SerializeField]
    GameObject adjectiveInputs;
    [SerializeField]
    TMP_Text scoreText;

    [Space]
    [Header("Karteikarten Objekte")]
    [SerializeField]
    GameObject latinSide;
    [SerializeField]
    TMP_Text latinVocab;
    [SerializeField]
    [Space]
    GameObject GermanSide;
    [SerializeField]
    TMP_Text germanVocab;
    [SerializeField]
    TMP_Text genitiv;
    [SerializeField]
    TMP_Text genus;

    [Header("Vocab")]
    
    Substantiv currentSubstantiv;
    Verb currentVerb;

    Adjective currentAdjective;
    [SerializeField]
    string currentVocabType;

    [Header("Antwortfeld Texte")]
    [SerializeField]
    TMP_InputField substantivBedeutung;
    [SerializeField]
    TMP_InputField genitivText;
    [SerializeField]
    TMP_InputField genusText;

    [Space]
    [SerializeField]
    TMP_InputField verbBedeutung;
    [SerializeField]
    TMP_InputField firstStammform;
    [SerializeField]
    TMP_InputField secondStammform;
    [SerializeField]
    TMP_InputField ppp;

    [Space]
    [SerializeField]
    TMP_InputField firstGenitvInputField;
    [SerializeField]
    TMP_InputField secondGenitvInputField;
    [SerializeField]
    TMP_InputField thirdGenitvInputField;
    [SerializeField]
    TMP_InputField bedeutungAdjektivInputField;

    [Space]
    [SerializeField]
    Animator vocabCard;




    void Awake()
    {
        processor = GameObject.Find("Processor");
        InitializeTraining();
        GenerateVocab();
        if(processor == null){
            Debug.LogError("FATAL ERROR LIST NOT FOUND!");
            
        }
    }
    public void InitializeTraining()
    {
        Debug.Log("initializing Training..."); 
        //Substantiv Input Field logic
        if(PlayerPrefs.GetInt("Genitiv")== 0)
        {
            genitivInputContainer.SetActive(false);
        }else
        {
            genitivInputContainer.SetActive(true);
        }

        if(PlayerPrefs.GetInt("Genus") == 0){
            genusInputContainer.SetActive(false);
        }else
        {
            genusInputContainer.SetActive(true);
        }      
        
        //Verb Input Field logic
        if(PlayerPrefs.GetInt("FirstStammform")==0){
            firstStammformInputContainer.SetActive(false);
        }else
        {
            firstStammformInputContainer.SetActive(true);
        }

        if(PlayerPrefs.GetInt("SecondStammform")==0){
            secondStammformInputContainer.SetActive(false);
        }else
        {
            secondStammformInputContainer.SetActive(true);
        }

        if(PlayerPrefs.GetInt("PPPStammform")==0){
            pppInputContainer.SetActive(false);
        }else
        {
            pppInputContainer.SetActive(true);
        }
        if(PlayerPrefs.GetInt("AdjektivGenitiv") == 0){
            GenitivAdjektivInputContainer.SetActive(false);
        }else{
            GenitivAdjektivInputContainer.SetActive(true);
        }
        PlayerPrefs.SetInt("score" ,0);
    }
    public void CheckAnswerButtonHandler(){
        //Start Animation
        if(!GermanSide.activeSelf){
            StartCoroutine(ManageAnim());
        } 
        
        
        if(currentVocabType == "substantiv")
        {
            if(currentSubstantiv != null){
                if(currentSubstantiv.bedeutung.Contains(substantivBedeutung.text)){
                Debug.Log("Bedeutung richtig!");
                PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+2);
                }
                if(currentSubstantiv.genitiv.ToUpper() ==genitivText.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("Genitiv richtig!");
                }
                if(genusText.text.Contains("femininum") || genusText.text.Equals("f")){
                    if(currentSubstantiv.genus == Genus.femininum){
                        PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                        Debug.Log("Genus richtig!");
                    }

                }else if(genusText.text.Contains("maskulinum") ||genusText.text.Equals("m") ){
                    if(currentSubstantiv.genus == Genus.maskulinum){
                        PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                        Debug.Log("Genus richtig!");
                    }    
                }else if(genusText.text.Contains("neutrum") ||genusText.text.Equals("n") ){
                    if(currentSubstantiv.genus == Genus.neutrum){
                        PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                        Debug.Log("Genus richtig!");
                    }    
                Debug.Log(genusText.text);
                Debug.Log("Lösungen " + currentSubstantiv.bedeutung + " " + currentSubstantiv.genitiv + " " + currentSubstantiv.genus);
            }
            currentSubstantiv =null;
            }
            

        }else if(currentVocabType == "verb")
        {
            if(currentVerb != null){
                if(currentVerb.bedeutung.ToUpper() == verbBedeutung.text.ToUpper()){
                PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+2);
                Debug.Log("Bedeutung richtig");
                }
                if(currentVerb.praesensIndikativ.ToUpper() == firstStammform.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("Erste Stammform richtig");
                }
                if(currentVerb.perfektIndikativ.ToUpper() == secondStammform.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("Zweite Stammform richtig");
                }
                if(currentVerb.ppp.ToUpper() == ppp.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("dritte Stammform richtig");
                }
                currentVerb = null;
            }
            
        }else if(currentVocabType == "adjective"){
            if(currentAdjective != null){
                if(currentAdjective.bedeutung.ToUpper() == bedeutungAdjektivInputField.text.ToUpper() ){
                PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+2);
                Debug.Log("Bedeutung richtig");
                }
                if(currentAdjective.firstGenitiv.ToUpper() == firstGenitvInputField.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("M. Genitiv richtig");
                }
                if(currentAdjective.secondGenitiv.ToUpper() == secondGenitvInputField.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("N. Genitiv richtig");
                }
                if(currentAdjective.thirdGenitiv.ToUpper() == thirdGenitvInputField.text.ToUpper()){
                    PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1);
                    Debug.Log("F. Genitiv richtig");
                }
            }
            
            currentAdjective = null;
        }

        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    IEnumerator ManageAnim(){
        
        vocabCard.SetBool("isFlipping",true);
        yield return new WaitForSeconds(0.3f);
        latinSide.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GermanSide.SetActive(true);
        vocabCard.SetBool("isFlipping",false);      
        
    }
    public void nextVocabButtonHandler(){
        GenerateVocab();
    }

    public void GenerateVocab()
    {
        latinSide.SetActive(true);
        GermanSide.SetActive(false);
        Debug.Log(processor.GetComponent<XMLProcesser>().adjectiveList.Count);
        if(!(processor.GetComponent<XMLProcesser>().verbList.Count==0 && processor.GetComponent<XMLProcesser>().substantivList.Count == 0 && processor.GetComponent<XMLProcesser>().adjectiveList.Count == 0)){
            switch(Random.Range(0,3)){
            case 0:
                GenerateSubstantivVocab();
                break;
            case 1:
                GenerateVerbVocab();
                break;
            case 2: 
                GenerateAdjectiveVocab();
                break;
            }
        }else{
            SceneManager.LoadScene("EndTrainingScene");
            Debug.Log("Training beendet");
        }       
    }

    public void GenerateSubstantivVocab(){
        //CheckListForItems
        //Enable SubstantivInputs
        //Disable VerbInputs
        //Insert word into Karteikarte 
        //set Valdiation Data

        if(processor.GetComponent<XMLProcesser>().substantivList.Count>0){
            currentVocabType = "substantiv";
            substantivInputs.SetActive(true);
            verbInputs.SetActive(false);
            adjectiveInputs.SetActive(false);

            currentSubstantiv = processor.GetComponent<XMLProcesser>().substantivList[Random.Range(0, processor.GetComponent<XMLProcesser>().substantivList.Count)];

            processor.GetComponent<XMLProcesser>().substantivList.Remove(currentSubstantiv);

            latinVocab.text = currentSubstantiv.grundform;
            germanVocab.text = currentSubstantiv.bedeutung;
            genitiv.text = currentSubstantiv.genitiv;
            genus.text = currentSubstantiv.genus.ToString();
        }else{
            GenerateVocab();
        }
    }

    public void GenerateVerbVocab(){
        Debug.Log(processor.GetComponent<XMLProcesser>().verbList.Count);
        if(processor.GetComponent<XMLProcesser>().verbList.Count>0){
            currentVocabType = "verb";
            substantivInputs.SetActive(false);
            verbInputs.SetActive(true);
            adjectiveInputs.SetActive(false);

            currentVerb = processor.GetComponent<XMLProcesser>().verbList[Random.Range(0, processor.GetComponent<XMLProcesser>().verbList.Count)];
            processor.GetComponent<XMLProcesser>().verbList.Remove(currentVerb);

            latinVocab.text = currentVerb.infinitiv;
            germanVocab.text = currentVerb.bedeutung;
            genitiv.text = currentVerb.praesensIndikativ + ", " + currentVerb.perfektIndikativ + ", " + currentVerb.ppp;
            genus.text = "";
        }else{
            GenerateVocab();
        }
    }

    public void GenerateAdjectiveVocab(){
        if(processor.GetComponent<XMLProcesser>().adjectiveList.Count > 0){
            currentVocabType = "adjective";
            substantivInputs.SetActive(false);
            verbInputs.SetActive(false);
            adjectiveInputs.SetActive(true);
            
            currentAdjective = processor.GetComponent<XMLProcesser>().adjectiveList[Random.Range(0, processor.GetComponent<XMLProcesser>().adjectiveList.Count)];
            processor.GetComponent<XMLProcesser>().adjectiveList.Remove(currentAdjective);

            latinVocab.text = currentAdjective.nominativ;
            germanVocab.text = currentAdjective.bedeutung;
            genitiv.text = currentAdjective.firstGenitiv + ", " + currentAdjective.secondGenitiv + ", " + currentAdjective.thirdGenitiv;
            genus.text = "";
            
        }else{
            GenerateVocab();
        }
    }
}
