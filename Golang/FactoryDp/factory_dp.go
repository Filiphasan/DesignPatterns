package FactoryDp

import (
	"errors"
	"github.com/Filiphasan/DesignPatterns/golang/FactoryDp/Services"
)

type NotificationService interface {
	SendNotification(message string) error
}

func GetNotificationFactory(notificationType string) (NotificationService, error) {
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
