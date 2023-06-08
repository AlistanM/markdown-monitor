package controllers

import (
	"io"
	config "markdown-monitor/configuration"

	"github.com/gin-gonic/gin"
)

type Router struct {
}

func initLogs(router *gin.Engine, writer io.Writer) {
	if config.Instance().EnableServerLogging {
		router.Use(
			gin.LoggerWithWriter(writer, config.Instance().LogPath+".\\not-logged"),
			gin.Recovery(),
		)
	}
}

func (r *Router) InitRoutes(writer io.Writer) *gin.Engine {
	router := gin.New()

	initLogs(router, writer)

	api := router.Group("/")
	{
		api.POST("/test", r.Test)
		api.GET("/", r.Hello)
	}

	return router
}
