package Services

import (
	"fmt"
	"time"
)

type SmsService struct {
}

func NewSmsService() *SmsService {
	return &SmsService{}
}

func (s *SmsService) SendNotification(message string) error {
	// Simulate sending SMS with 100ms sleep
	time.Sleep(100 * time.Millisecond)
	fmt.Printf("Sms notification: %s\n", message)
	return nil
}
