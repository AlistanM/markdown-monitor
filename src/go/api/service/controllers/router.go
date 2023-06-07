package controllers

import (
	"github.com/gin-gonic/gin"
)

type Router struct {
}

const LogPath = "..\\logs\\"

func (r *Router) InitRoutes() *gin.Engine {
	router := gin.New()

	router.Use(
		gin.LoggerWithWriter(gin.DefaultWriter, LogPath),
		gin.Recovery(),
	)

	api := router.Group("/")
	{
		api.POST("/test", r.Test)
		api.GET("/", r.Hello)
	}

	return router
}
