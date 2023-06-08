package main

import (
	"log"
	"markdown-monitor/service"
)

func main() {
	writer := InitLogs()

	server := new(service.Server)
	if err := server.Start(writer); err != nil {
		log.Fatalf("Server was stopped with error: %s", err.Error())
	}
}
