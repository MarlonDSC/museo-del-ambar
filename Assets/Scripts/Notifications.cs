using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		//para remover las notificaciones
		AndroidNotificationCenter.CancelAllDisplayedNotifications();
		
		//Para crear el canal de notificaciones de android para enviar mensajes
		
		var channel = new AndroidNotificationChannel()
		{
			Id = "channel_id",
			Name = "Default Channel",
			Importance = Importance.Default,
			Description = "Tuti notifications",
};
		AndroidNotificationCenter.RegisterNotificationChannel(channel);
		
		//Para crear la notificacion que sera enviada 
		var notification = new AndroidNotification();
		notification.Title = "Hey! espero que vuelvas pronto";
		notification.Text = "¡Ambarito espera con ansias tu regreso!";
		notification.FireTime = System.DateTime.Now.AddMinutes(5);

		//para enviar la notificacion
		var id= AndroidNotificationCenter.SendNotification(notification, "channel_id");
		
		// if the script is run and a message is already scheduled, cancel it and re-schedule another message
		if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id)== NotificationStatus.Scheduled)
		{
			
			AndroidNotificationCenter.CancelAllNotifications();
			AndroidNotificationCenter.SendNotification(notification, "channel_id");
		}
		
	}
   
   
   
   
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		
		
	}
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
}
