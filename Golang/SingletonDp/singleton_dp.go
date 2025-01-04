package SingletonDp

import (
	"fmt"
	"github.com/Filiphasan/DesignPatterns/golang/SingletonDp/Services"
)

func UseSingletonDp() {
	connectionPool := Services.GetConnectionPool(20)
	for i := 0; i < 5; i++ {
		connectionPool = Services.GetConnectionPool(20)
	}

	connection := connectionPool.Get()
	connection2 := connectionPool.Get()
	fmt.Println("Connection 1: ", connection.Id)
	fmt.Println("Connection 2: ", connection2.Id)
	connection2.Status = false
	connectionPool.Return(connection)
	connectionPool.Return(connection2)
}
