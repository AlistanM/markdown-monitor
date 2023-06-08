package main

import (
	"fmt"
	"io"
	"log"
	config "markdown-monitor/configuration"
	"os"
	"time"
)

var programLogPath string

func InitLogs() io.Writer {
	programLogPath = config.Instance().LogPath

	createDirIfNotExists(programLogPath)

	f, err := os.OpenFile(programLogPath+getLogName(), os.O_RDWR|os.O_CREATE|os.O_APPEND, 0666)
	if err != nil {
		log.Fatalf("File opening finished with error: %s", err.Error())
	}

	log.SetOutput(f)
	return f
}

func createDirIfNotExists(path string) {
	if _, err := os.Stat(path); os.IsNotExist(err) {
		err := os.Mkdir(path, os.ModePerm)
		if err != nil {
			log.Fatalf("Dir creating finished with error: %s", err.Error())
		}
	}
}

func getLogName() string {
	now := time.Now()
	return fmt.Sprintf("log_%02d_%02d_%02d_%02d_%02d_%02d.log", now.Day(), now.Month(), now.Year(), now.Hour(), now.Minute(), now.Second())
}
