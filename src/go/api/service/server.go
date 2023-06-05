package service

import (
	"context"
	"markdown-monitor/service/controllers"
	"net/http"
	"time"
)

const MaxBytes = 1 << 20

type Server struct {
	instance *http.Server
}

func (s *Server) Start(port string) error {
	router := new(controllers.Router)

	s.instance = &http.Server{
		Addr:           ":" + port,
		MaxHeaderBytes: MaxBytes,
		ReadTimeout:    10 * time.Second,
		WriteTimeout:   10 * time.Second,
		Handler:        router.InitRoutes(),
	}

	return s.instance.ListenAndServe()
}

func (s *Server) Stop(context *context.Context) error {
	return s.instance.Shutdown(*context)
}
