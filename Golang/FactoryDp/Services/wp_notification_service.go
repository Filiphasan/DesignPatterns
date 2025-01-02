package Services

import (
	"fmt"
	"time"
)

type WpNotificationService struct {
}

func NewWpNotificationService() *WpNotificationService {
	return &WpNotificationService{}
}

func (w *WpNotificationService) SendNotification(message string) error {
	// Simulate sending SMS with 100ms sleep
	time.Sleep(100 * time.Millisecond)
	fmt.Printf("Wp notification: %s\n", message)
	return nil
}
