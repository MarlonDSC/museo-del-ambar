using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FantomLib
{
	using UnityEngine.UI;
	using TMPro;
    /// <summary>
    /// DatePicker Dialog Controller
    ///･Note: Callback from Android to Unity is received under 'GameObject.name'. That is, it is unique within the hierarchy. 
    /// (Datetime format)
    /// https://developer.android.com/reference/java/text/SimpleDateFormat.html
    /// (Theme[Style])
    /// https://developer.android.com/reference/android/R.style.html#Theme
    /// </summary>
    public class DatePickerController : MonoBehaviour
    {
        //Inspector Settings
        public string defaultDate = "";                 //When it is empty, it is the current time.
	    public string resultDateFormat = "yyyy/M/d";    //Java Datetime format.
	    public TextMeshProUGUI year;
	    public TextMeshProUGUI month;
	    public TextMeshProUGUI day;
        public static DateTime dateValue;



        public string style = "android:Theme.DeviceDefault.Light.Dialog.Alert"; //Dialog theme

        //Callbacks
        [Serializable] public class ResultHandler : UnityEvent<string> { }      //date string
        public ResultHandler OnResult;


        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        //private void Update()
        //{

        //}
        
        
        //Show dialog
        public void Show()
        {
#if UNITY_EDITOR
            Debug.Log("DatePickerController.Show called");
#elif UNITY_ANDROID
            AndroidPlugin.ShowDatePickerDialog(
                defaultDate,
                resultDateFormat,
	        this.name,
                "ReceiveResult",
                style);
#endif
        }

        //Set date string dynamically and show dialog (current date string will be overwritten)
        public void Show(string defaultDate)
	    {
            this.defaultDate = defaultDate;
            Show();
        }


        //Returns value when 'OK' pressed.
        private void ReceiveResult(string result)
        {
            if (OnResult != null)
	            OnResult.Invoke(result);
            //year.text = result;
            dateValue = (Convert.ToDateTime(result));
            year.text = dateValue.Year.ToString();
            month.text = dateValue.ToString("MMMM").ToUpper();
            day.text = dateValue.Day.ToString();
        }
    }
}
