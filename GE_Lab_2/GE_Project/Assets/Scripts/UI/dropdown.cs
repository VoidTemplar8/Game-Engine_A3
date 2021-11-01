using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdown : MonoBehaviour
{
    //public Text TextBox;
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> platforms = new List<string>();
        platforms.Add("Disappearing");
        platforms.Add("Rotating");
        platforms.Add("Checkpoint");
        platforms.Add("End");
        platforms.Add("Generic");

        //for putting platform types in the dropdown menu
        foreach(var platform in platforms)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = platform });
        }

        DropdownItemPressed(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemPressed(dropdown); });
        
    }

    void DropdownItemPressed (Dropdown dropdown)
    {
        int index = dropdown.value;
        CreatingPlatforms.objectIndex = index;
    }

}
