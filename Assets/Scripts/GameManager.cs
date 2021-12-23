using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameObject menuGame;

    const float MAX_XP = 100;

    float _xp;
    int level = 1;

    InitialCoords initialCoords;
    static public int bananas;
    static public int coins;
    static public int cones;
    static public int lolipops;

    Image xpBar;
    Text levelText;

    //Text text;
    //Mapbox.Unity.Map.AbstractMap map;

    // Start is called before the first frame update
    void Start()
    {
        
        xpBar = GameObject.Find("InfoCanvas/xpBar/Circle1/Circle3").GetComponent<Image>();
        levelText = GameObject.Find("InfoCanvas/xpBar/Circle1/Circle3/Text").GetComponent<Text>();
        menuGame = GameObject.Find("My Info Panel");

        initialCoords = new InitialCoords(Input.location.lastData.latitude, Input.location.lastData.longitude, Input.location.lastData.altitude);

        getData();

        StartCoroutine(saveDataTimer());

        if (!PlayerPrefs.HasKey("firstTime"))
        {
            PlayerPrefs.SetInt("firstTime", 1);
            SceneManager.LoadScene("SampleScene");
        }

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


    public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
    {
        double rlat1 = Math.PI * lat1 / 180;
        double rlat2 = Math.PI * lat2 / 180;
        double theta = lon1 - lon2;
        double rtheta = Math.PI * theta / 180;
        double dist =
            Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
            Math.Cos(rlat2) * Math.Cos(rtheta);
        dist = Math.Acos(dist);
        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;

        switch (unit)
        {
            case 'K': //Kilometers -> default
                return dist * 1.609344;
            case 'N': //Nautical Miles 
                return dist * 0.8684;
            case 'M': //Miles
                return dist;
        }

        return dist;
    }


    public void saveData()
    {
        PlayerPrefs.SetInt("bananas", bananas);
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("cones", cones);
        PlayerPrefs.SetInt("lolipops", lolipops);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetFloat("xp", _xp);
    }

    public void getData()
    {
        bananas = PlayerPrefs.HasKey("bananas") ? PlayerPrefs.GetInt("bananas") : 0;
        coins = PlayerPrefs.HasKey("coins") ? PlayerPrefs.GetInt("coins") : 0;
        cones = PlayerPrefs.HasKey("cones") ? PlayerPrefs.GetInt("cones") : 0;
        lolipops = PlayerPrefs.HasKey("lolipops") ? PlayerPrefs.GetInt("lolipops"): 0;
        level = PlayerPrefs.HasKey("level") ? PlayerPrefs.GetInt("level") : 1;
        xp = PlayerPrefs.HasKey("xp") ? PlayerPrefs.GetFloat("xp") : 0;
    }

    IEnumerator saveDataTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            saveData();
        }
    }

    public void addItem(string name) 
    {

        switch (name)
        {
            case "banana":
                bananas += 1;
                break;
            case "cone":
                cones += 1;
                break;
            case "coin":
                coins += 1;
                break;
            case "lolipop":
                lolipops += 1;
                break;
            default:
                break;
        }

        saveData();

    }


    public void openMenuButton()
    {
        StartCoroutine(DoFadeIn(menuGame.GetComponent<CanvasGroup>()));

        GameObject.Find("Content 0/Desc").GetComponent<Text>().text = initialCoords.latitude + " | " + initialCoords.longitude + " | " + initialCoords.altitude;
        GameObject.Find("Content 1/Desc").GetComponent<Text>().text = Input.location.lastData.latitude + " | " + Input.location.lastData.longitude + " | " + Input.location.lastData.altitude;
        var dist = DistanceTo(initialCoords.latitude, initialCoords.longitude, Input.location.lastData.latitude, Input.location.lastData.longitude, 'K');
        GameObject.Find("Content 2/Desc").GetComponent<Text>().text = Math.Round(dist, 3).ToString() + " Km";
        GameObject.Find("Content 3/Desc").GetComponent<Text>().text = bananas.ToString();
        GameObject.Find("Content 4/Desc").GetComponent<Text>().text = coins.ToString();
        GameObject.Find("Content 5/Desc").GetComponent<Text>().text = cones.ToString();
        GameObject.Find("Content 6/Desc").GetComponent<Text>().text = lolipops.ToString();
    }

    public void closeMenuButton()
    {
        StartCoroutine(DoFadeOut(menuGame.GetComponent<CanvasGroup>()));
    }

    static public IEnumerator DoFadeOut(CanvasGroup canvasG)
    {
        while (canvasG.alpha > 0)
        {
            canvasG.alpha -= Time.deltaTime;
            yield return null;
        }

        canvasG.interactable = false;
        canvasG.blocksRaycasts = false;
    }

    static public IEnumerator DoFadeIn(CanvasGroup canvasG)
    {
        while (canvasG.alpha < 1)
        {
            canvasG.alpha += Time.deltaTime;
            yield return null;
        }

        canvasG.interactable = true;
        canvasG.blocksRaycasts = true;
    }

}

struct InitialCoords
{
    public float latitude;
    public float longitude;
    public float altitude;

    public InitialCoords(float _latitude, float _longitude, float _altitude)
    {
        latitude = _latitude;
        longitude = _longitude;
        altitude = _altitude;
    }

}