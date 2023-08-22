using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    public GameObject damagetxt, healtxt;
    public Canvas canvas;





    private void OnEnable()
    {
        canvas = FindObjectOfType<Canvas>();
        event_class.char_damaged+=(ondamagetxt);
        event_class.char_healed+=(onhealtxt);
    }

    private void OnDisable()
    {
        event_class.char_damaged-=(ondamagetxt);
        event_class.char_healed-=(onhealtxt);
    }

    public void ondamagetxt (GameObject character, int damage_to_show)
    {
        TMP_Text _damagetxt = damagetxt.GetComponent<TMP_Text>();
        
        _damagetxt.text = damage_to_show.ToString();
        Vector3 spawnpos = Camera.main.WorldToScreenPoint(character.transform.position);
        Instantiate(damagetxt, spawnpos, Quaternion.identity, canvas.transform);
        
        
        //_damagetxt.GetComponent<health_text>().startcolor = Color.green;
    }
    public void onhealtxt (GameObject character, int health_to_show)
    {
        TMP_Text _healtxt = healtxt.GetComponent<TMP_Text>();
        Vector3 spawnpos = (Camera.main.WorldToScreenPoint(character.transform.position));
        _healtxt.text = health_to_show.ToString();
        Instantiate(healtxt, spawnpos, Quaternion.identity, canvas.transform);
       
        
      //  _damagetxt.GetComponent<health_text>().startcolor = Color.red;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
