using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject textUIObject;
    public Text textUI;
    public Text nameText;

    private void Awake()
    {
        instance = this;
    }

    public void ActiveTextUI(string name, string str)
    {
        textUIObject.SetActive(true);
        textUI.text = str;
        nameText.text = name;
    }

}
