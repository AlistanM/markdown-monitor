package controllers

import (
	"encoding/json"
	"io/ioutil"
	"log"
	"markdown-monitor/service/models"
	"strconv"

	"github.com/gin-gonic/gin"
)

func (r *Router) Test(context *gin.Context) {
	jsonData, err := ioutil.ReadAll(context.Request.Body)
	if err != nil {
		log.Fatal("Error in body of Test method")
	}

	var data models.Entity

	json.Unmarshal([]byte(jsonData), &data)

	list := []string{}
	list = append(list, data.Name)
	list = append(list, strconv.Itoa(int(data.EntityAge)))

	result, _ := json.Marshal(list)

	context.Writer.Write(result)
}

func (r *Router) Hello(context *gin.Context) {
	context.Writer.WriteString("API")
}
