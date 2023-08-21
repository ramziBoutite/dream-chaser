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
        Vector3 spawnpos = Camera.main.WorldToScreenPoint(character.transform.position);
        Instantiate(damagetxt, spawnpos, Quaternion.identity, canvas.transform);
        TMP_Text _damagetxt = damagetxt.GetComponent<TMP_Text>();
        _damagetxt.text = damage_to_show.ToString();
    }
    public void onhealtxt (GameObject character, int health_to_show)
    {
        Vector3 spawnpos = (Camera.main.WorldToScreenPoint(character.transform.position));
        TMP_Text _damagetxt = Instantiate(healtxt, spawnpos,Quaternion.identity,canvas.transform).GetComponent<TMP_Text>();
        _damagetxt.text = health_to_show.ToString();
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
