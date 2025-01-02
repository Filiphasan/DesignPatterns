package main

import (
	"github.com/Filiphasan/DesignPatterns/golang/FactoryDp"
)

func main() {
	useFactoryDp()
}

func useFactoryDp() {

	// Sms notification
	sms, _ := FactoryDp.GetNotificationFactory("SMS")
	_ = sms.SendNotification("Hello, SMS notification")

	// Email notification
	email, _ := FactoryDp.GetNotificationFactory("EMAIL")
	_ = email.SendNotification("Hello, Email notification")

	// Whatsapp notification
	wp, _ := FactoryDp.GetNotificationFactory("WP")
	_ = wp.SendNotification("Hello, Whatsapp notification")

	// Ivr notification
	ivr, _ := FactoryDp.GetNotificationFactory("IVR")
	_ = ivr.SendNotification("Hello, Ivr notification")

}
