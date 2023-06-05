package controllers

import (
	"github.com/gin-gonic/gin"
)

type Router struct {
}

func (r *Router) InitRoutes() *gin.Engine {
	router := gin.New()

	api := router.Group("/")
	{
		api.POST("/test", r.Test)
		api.GET("/", r.Hello)
	}

	return router
}
