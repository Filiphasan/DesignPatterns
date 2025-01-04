package main

import (
	"fmt"
	"github.com/Filiphasan/DesignPatterns/golang/BuilderDp"
	"github.com/Filiphasan/DesignPatterns/golang/FactoryDp"
	"github.com/Filiphasan/DesignPatterns/golang/SingletonDp"
)

const Separator string = "\n----------------------------------------------"

func main() {
	fmt.Println(Separator)
	fmt.Println("Factory Design Pattern Example Below")
	FactoryDp.UseFactoryDp()

	fmt.Println(Separator)
	fmt.Println("Builder Design Pattern Example Below")
	BuilderDp.UseBuilderDp()

	fmt.Println(Separator)
	fmt.Println("Singleton Design Pattern Example Below")
	SingletonDp.UseSingletonDp()
}
