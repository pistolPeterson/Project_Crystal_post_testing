using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//gray grey
public class RaeusWordDictionary : MonoBehaviour
{
    List<RaeusData> raeusDictionaryInstance = new List<RaeusData>();

    public RaeusProperData rpd = new RaeusProperData();

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        raeusDictionaryInstance.Add(new RaeusData() { Word = "Apple", Definition = "Red Fruit" });
        raeusDictionaryInstance.Add(new RaeusData() { Word = "Pancake", Definition = "delicious sweet carbs" });
        raeusDictionaryInstance.Add(new RaeusData() { Word = "Music", Definition = "The language of the gods" });

        rpd.raeusDataEntry.Add("Apple", "Red Fruit");
    

        Debug.Log(ListAllWords());
        Debug.Log(ListAllDefinitions());
        Debug.Log(ListAllWordsAndDefinition());
        Debug.Log(FindDefinition("Apple"));
        Debug.Log(FindDefinition("fgfgafdgfg"));
    }


    public string FindDefinition(string word)
    {
       for(int i = 0; i < raeusDictionaryInstance.Count; i++)
        {
            if(raeusDictionaryInstance[i].Word.ToUpper().Equals(word.ToUpper()))
            {
                return raeusDictionaryInstance[i].Definition;
            }
        }

        return "No Definition found for word: " + word;
    }

    public string ListAllWords()//return "Apple Music"
    {
        string text = "";
        foreach(var raeData in raeusDictionaryInstance)
        {
            text += raeData.Word + " ";
        }

        return text;
    }

    public string ListAllWordsAndDefinition()
    {
        string text = "";
        foreach (var raeData in raeusDictionaryInstance)
        {
            text += raeData.Word + ": " + raeData.Definition + "\n ";
        }

        return text;
    }


    public string ListAllDefinitions()
    {
        string text = "";
        foreach (var raeData in raeusDictionaryInstance)
        {
            text += raeData.Definition + " ";
        }

        return text;
    }
}


public class RaeusProperData 
{
    public Dictionary<string, string> raeusDataEntry;
    Dictionary<Dictionary<string, int>, Dictionary<string, int>> inceptionDictionary;

    void start()
    {
        Dictionary<string, int> x = new Dictionary<string, int>();
        x.Add("pete", 7);
        x.Add("rae", 21);
        inceptionDictionary.Add(x , x);
    }
}

public class RaeusData
{
    //word
    public string Word { get; set; }
    //defination
    public string Definition { get; set; }
}