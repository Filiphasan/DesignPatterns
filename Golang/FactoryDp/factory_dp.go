package FactoryDp

import (
	"errors"
	"github.com/Filiphasan/DesignPatterns/golang/FactoryDp/Services"
)

type NotificationService interface {
	SendNotification(message string) error
}

func getNotificationFactory(notificationType string) (NotificationService, error) {
	if notificationType == "SMS" {
		return Services.NewSmsService(), nil
	} else if notificationType == "EMAIL" {
		return Services.NewMailService(), nil
	} else if notificationType == "WP" {
		return Services.NewWpNotificationService(), nil
	} else if notificationType == "IVR" {
		return Services.NewIvrNotificationService(), nil
	}

	return nil, errors.New("invalid notification type")
}

func UseFactoryDp() {

	// Sms notification
	sms, _ := getNotificationFactory("SMS")
	_ = sms.SendNotification("Hello, SMS notification")

	// Email notification
	email, _ := getNotificationFactory("EMAIL")
	_ = email.SendNotification("Hello, Email notification")

	// Whatsapp notification
	wp, _ := getNotificationFactory("WP")
	_ = wp.SendNotification("Hello, Whatsapp notification")

	// Ivr notification
	ivr, _ := getNotificationFactory("IVR")
	_ = ivr.SendNotification("Hello, Ivr notification")

}
