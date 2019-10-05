using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour
{
    // Youtube: Timers that run outside your app

    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static TimeMaster instance;

    // Use this for initialisation

    void Awake() {

        // Create instance of our TimeMaster script
        instance = this;

        // Set our player prefs to the save location
        saveLocation = "lastSaveDate1";
        
    }

    /// Checks the current time against the saved time
    public float CheckDate() 
    {
        //Store the current time when it starts

        currentDate = System.DateTime.Now;
        print("Current Date: " + currentDate);
        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        // Grab the old time from the player prefs as a long

        long tempLong = Convert.ToInt64(tempString);

        //Convert the old time from binary to a DateTime variable

        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("Old Date : " + oldDate);

        //Use the subract method and store the result as a timespan

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);

        return (float)difference.TotalSeconds;

    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());

        print ("Saving this date to player prefs: " + System.DateTime.Now);
    }





}
