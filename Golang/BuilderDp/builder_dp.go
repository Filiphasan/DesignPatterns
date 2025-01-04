package BuilderDp

import (
	"fmt"
	"github.com/Filiphasan/DesignPatterns/golang/BuilderDp/Builders"
)

func UseBuilderDp() {
	httpUriBuilder := Builders.NewHttpUriBuilder("https://example.com")
	httpUriBuilder = httpUriBuilder.AddPath("api").AddPath("v1").AddPath("users")
	httpUriBuilder = httpUriBuilder.AddQueryParam("firstName", "Hasan").AddQueryParam("lastName", "Erdal")
	uri := httpUriBuilder.Build()

	fmt.Println("URI: ", uri)
}
