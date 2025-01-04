package Services

import (
	"fmt"
	"math/rand"
	"sync"
)

type AnyConnection struct {
	Id     string
	Status bool
}

var lock = &sync.Mutex{}

type ConnectionPool struct {
	connections []*AnyConnection
	maxSize     int
}

var instance *ConnectionPool

func GetConnectionPool(maxSize int) *ConnectionPool {
	if instance == nil {
		lock.Lock()
		defer lock.Unlock()
		if instance == nil {
			fmt.Println("SingletonDp -> Creating ConnectionPool instance")
			instance = &ConnectionPool{
				connections: make([]*AnyConnection, 0),
				maxSize:     maxSize,
			}
			instance.fillConnections()
		} else {
			fmt.Println("SingletonDp -> Returning existing ConnectionPool instance")
		}
	} else {
		fmt.Println("SingletonDp -> Returning existing ConnectionPool instance")
	}
	return instance
}

func (c *ConnectionPool) fillConnections() {
	for i := 0; i < c.maxSize; i++ {
		c.connections = append(c.connections, createConnection())
	}
}

func createConnection() *AnyConnection {
	uniqueId := rand.Int31n(1_000_000)
	return &AnyConnection{Id: fmt.Sprintf("Connection %d", uniqueId), Status: true}
}

func (c *ConnectionPool) Get() *AnyConnection {
	lock.Lock()
	defer lock.Unlock()
	if len(c.connections) == 0 {
		return createConnection()
	}

	conn := c.connections[0]
	c.connections = c.connections[1:]
	return conn
}

func (c *ConnectionPool) Return(conn *AnyConnection) {
	lock.Lock()
	defer lock.Unlock()
	if len(c.connections) < c.maxSize && conn.Status {
		c.connections = append(c.connections, conn)
	} else {
		// Close connection
		fmt.Println("Closing connection: ", conn.Id)
	}
}
