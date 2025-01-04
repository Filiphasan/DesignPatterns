package Builders

import (
	"fmt"
	"time"
)

type FluentEmailBuilder struct {
	From    string
	To      []string
	Cc      []string
	Bcc     []string
	Subject string
	Body    string
}

func NewFluentEmailBuilder() *FluentEmailBuilder {
	return &FluentEmailBuilder{}
}

func (f *FluentEmailBuilder) SetFrom(from string) *FluentEmailBuilder {
	f.From = from
	return f
}

func (f *FluentEmailBuilder) AddTo(to string) *FluentEmailBuilder {
	f.To = append(f.To, to)
	return f
}

func (f *FluentEmailBuilder) AddCc(cc string) *FluentEmailBuilder {
	f.Cc = append(f.Cc, cc)
	return f
}

func (f *FluentEmailBuilder) AddBcc(bcc string) *FluentEmailBuilder {
	f.Bcc = append(f.Bcc, bcc)
	return f
}

func (f *FluentEmailBuilder) SetSubject(subject string) *FluentEmailBuilder {
	f.Subject = subject
	return f
}

func (f *FluentEmailBuilder) SetBody(body string) *FluentEmailBuilder {
	f.Body = body
	return f
}

func (f *FluentEmailBuilder) Send() {
	// Send email here
	time.Sleep(1 * time.Second)
	fmt.Println("Email sent successfully")
}
