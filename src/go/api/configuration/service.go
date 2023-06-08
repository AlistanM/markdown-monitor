package config

import (
	"encoding/xml"
	"io/ioutil"
	"log"
)

const ConfigPath = ".\\go-config.xml"

var instance *Model

func initInstance() {
	content, err := ioutil.ReadFile(ConfigPath)
	if err != nil {
		log.Fatalf("Reading go-config file finished with error; File: '%s'; error: %s", ConfigPath, err.Error())
	}

	err = xml.Unmarshal(content, &instance)
	if err != nil {
		log.Fatalf("Serializing go-config file finished with error; error: %s", err.Error())
	}
}

func Instance() *Model {
	if instance == nil {
		initInstance()
	}

	return instance
}
