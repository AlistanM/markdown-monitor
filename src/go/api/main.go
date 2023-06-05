package main

import (
	"log"
	"markdown-monitor/service"
)

func main() {
	server := new(service.Server)
	if err := server.Start("8080"); err != nil {
		log.Fatalf("Server was stopped with error: %s", err.Error())
	}
}
