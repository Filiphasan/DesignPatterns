package Services

import (
	"fmt"
	"time"
)

type MailService struct {
}

func NewMailService() *MailService {
	return &MailService{}
}

func (m *MailService) SendNotification(message string) error {
	// Simulate sending SMS with 100ms sleep
	time.Sleep(100 * time.Millisecond)
	fmt.Printf("Mail notification: %s\n", message)
	return nil
}
