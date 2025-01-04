package main

import (
	"fmt"
	"github.com/Filiphasan/DesignPatterns/golang/BuilderDp"
	"github.com/Filiphasan/DesignPatterns/golang/FactoryDp"
)

func main() {
	fmt.Println("----------------------------------------------")
	fmt.Println("Factory Design Pattern Example Below")
	FactoryDp.UseFactoryDp()

	fmt.Println("----------------------------------------------")
	fmt.Println("Builder Design Pattern Example Below")
	BuilderDp.UseBuilderDp()
}
