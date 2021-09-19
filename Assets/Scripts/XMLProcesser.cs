using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml;
using System.IO;

[System.Serializable]
public class Verb{

    public string infinitiv { get; set; }
    public string praesensIndikativ { get; set; }
    public string perfektIndikativ { get; set; }
    public string ppp { get; set; } 
    public string bedeutung { get; set; }

    public Verb(string infinitiv, string praesensIndikativ,string perfektIndikativ,string ppp,string bedeutung){
        this.infinitiv = infinitiv;
        this.praesensIndikativ =  praesensIndikativ;
        this.perfektIndikativ = perfektIndikativ;
        this.ppp = ppp;
        this.bedeutung = bedeutung;
    }
}

[System.Serializable]
public class Substantiv{

    public string grundform { get; set; }
    public Genus genus { get; set; }
    public string genitiv { get; set; }
    public string bedeutung { get; set; }

    public Substantiv(string grundform, Genus genus, string genitiv, string bedeutung){
        this.grundform = grundform;
        this.genus =genus;
        this.genitiv = genitiv;
        this.bedeutung = bedeutung;
    }
}
[System.Serializable]
public class Adjective{

    public string nominativ { get; set; }
    public string firstGenitiv { get; set; }
    public string secondGenitiv { get; set; }
    public string thirdGenitiv { get; set; }

    public string bedeutung { get; set; }

    public Adjective(string nominativ, string firstGenitiv, string secondGenitiv, string thirdGenitiv, string bedeutung){
        
        this.nominativ = nominativ;
        this.firstGenitiv = firstGenitiv;
        this.secondGenitiv = secondGenitiv;
        this.thirdGenitiv = thirdGenitiv;
        this.bedeutung = bedeutung;

    }


}
public class XMLProcesser : MonoBehaviour
{
    [SerializeField]
    string url;
    [SerializeField]
    TMP_InputField urlField;

    [SerializeField]
    TMP_Text fileList;

    [SerializeField]
    public List<Verb> verbList;
    Genus genus1;
    [SerializeField]
    public List<Substantiv> substantivList;
    [SerializeField]
    public List<Adjective> adjectiveList;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void ProcessData(){
        url = urlField.text;
        Debug.Log(url);
        if(url == ""){
            return;
        }
        try{
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes){
                if(node["type"].InnerText == "verb"){
                    
                    var currentInfinitiv = node["infinitiv"].InnerText;
                    var currentPraesensIndikativ = node["praesensIndikativ"].InnerText;
                    var currentPerfektIndikativ = node["perfektIndikativ"].InnerText;
                    var currentPpp = node["supinstamm"].InnerText;
                    var currentBedeutung = node["bedeutung"].InnerText;

                    var word = new Verb(
                        currentInfinitiv,
                        currentPraesensIndikativ,
                        currentPerfektIndikativ,
                        currentPpp,
                        currentBedeutung
                    );

                    verbList.Add(word);

                    Debug.Log(word.infinitiv);

                }else if(node["type"].InnerText == "substantiv"){
                    var currentgrundform = node["grundform"].InnerText;
                    
                    switch( node["genus"].InnerText){
                        case "maskulinum":
                            genus1 = Genus.maskulinum;
                            break;
                        case "femininum":
                            genus1 = Genus.femininum;
                            break;
                        case "neutrum":
                            genus1 = Genus.neutrum;
                            break;
                        default:
                        Debug.LogError("[Error ID 10T]: Unknown Genus");
                            break;
                    }
                    var currentgenitiv = node["genitiv"].InnerText;
                    var currentbedeutung  = node["bedeutung"].InnerText;

                    var word = new Substantiv(
                        currentgrundform,
                        genus1,
                        currentgenitiv,
                        currentbedeutung
                    );

                    substantivList.Add(word);

                    Debug.Log(word.grundform);

                }else if(node["type"].InnerText == "adjektiv"){
                        

                        var currentNominativ = node["nominativ"].InnerText;
                        var currentFirstGenitiv = node["firstGenitiv"].InnerText;
                        var currentSecondGenitiv = node["secondGenitiv"].InnerText;
                        var currentThirdGenitiv =  node["thirdGenitiv"].InnerText;
                        var currentBedeutung = node["bedeutung"].InnerText;

                        Debug.Log(node["nominativ"].InnerText);
                        Debug.Log(node["firstGenitiv"].InnerText);
                        Debug.Log(node["secondGenitiv"].InnerText);
                        Debug.Log(node["thirdGenitiv"].InnerText);
                        Debug.Log(node["bedeutung"].InnerText);

                        var adjective = new Adjective(
                            currentNominativ,
                            currentFirstGenitiv,
                            currentSecondGenitiv,
                            currentThirdGenitiv,
                            currentBedeutung);
                            Debug.Log(adjective);
                            adjectiveList.Add(adjective); 
                        
                }else{
                    Debug.LogError("[Error ID 10T]: Unknown Wordtype");
                }
            }
            
            fileList.text += url +";" +"\n";
            PlayerPrefs.SetString("VocabLists", fileList.text);
        }
        catch(IOException e){
            Debug.LogError(e);
            Debug.LogError("[Error ID 10T]: File not Found");
        }        
    }
    public void ClearData(){
        verbList.Clear();
        substantivList.Clear();
        //TODO: Add Adjective List

        fileList.text = "";
        PlayerPrefs.SetString("VocabLists", fileList.text);
        
    }

}
