package BuilderDp

import (
	"fmt"
	"github.com/Filiphasan/DesignPatterns/golang/BuilderDp/Builders"
)

func UseBuilderDp() {
	httpUriBuilder := Builders.NewHttpUriBuilder("https://example.com")
	httpUriBuilder.AddPath("api").AddPath("v1").AddPath("users")
	httpUriBuilder.AddQueryParam("firstName", "Hasan").AddQueryParam("lastName", "Erdal")
	uri := httpUriBuilder.Build()

	fmt.Println("URI: ", uri)

	emailBuilder := Builders.NewFluentEmailBuilder()
	emailBuilder.SetFrom("test@test.com")
	emailBuilder.AddTo("to1@outlook.com").AddTo("to2@outlook.com")
	emailBuilder.AddCc("cc1@outlook.com")
	emailBuilder.AddBcc("bcc1@outlook.com")
	emailBuilder.SetSubject("Test Email")
	emailBuilder.SetBody("This is a test email")
	emailBuilder.Send()
}
