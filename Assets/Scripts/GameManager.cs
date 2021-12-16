using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Text text;
    Mapbox.Unity.Map.AbstractMap map;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("InfoCanvas/Text").GetComponent<Text>();
        map = GameObject.Find("Map").GetComponent<Mapbox.Unity.Map.AbstractMap>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

        //map.UpdateMap(new Mapbox.Utils.Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude), map.Zoom);
    }
}
