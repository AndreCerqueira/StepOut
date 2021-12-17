using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const float MAX_XP = 100;

    float _xp;
    int level = 1;

    Image xpBar;
    Text levelText;

    //Text text;
    //Mapbox.Unity.Map.AbstractMap map;

    // Start is called before the first frame update
    void Start()
    {
        
        xpBar = GameObject.Find("InfoCanvas/xpBar/Circle1/Circle3").GetComponent<Image>();
        levelText = GameObject.Find("InfoCanvas/xpBar/Circle1/Circle3/Text").GetComponent<Text>();
        xp = 100f;
        //text = GameObject.Find("InfoCanvas/Text").GetComponent<Text>();
        //map = GameObject.Find("Map").GetComponent<Mapbox.Unity.Map.AbstractMap>();
    }


    // Update is called once per frame
    void Update()
    {
        //text.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

    }

    public float xp
    {
        get { return _xp; }
        set { 
            _xp = value;
            xpBar.fillAmount = _xp / 100;
            
            if (_xp >= MAX_XP)
            {
                level++;
                levelText.text = level.ToString();
                xp -= 100;
            }
        
        }
    }

}
