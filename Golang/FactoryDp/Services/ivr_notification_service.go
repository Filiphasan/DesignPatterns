package Services

import (
	"fmt"
	"time"
)

type IvrNotificationService struct {
}

func NewIvrNotificationService() *IvrNotificationService {
	return &IvrNotificationService{}
}

func (i *IvrNotificationService) SendNotification(message string) error {
	// Simulate sending SMS with 100ms sleep
	time.Sleep(100 * time.Millisecond)
	fmt.Printf("Ivr notification: %s\n", message)
	return nil
}
