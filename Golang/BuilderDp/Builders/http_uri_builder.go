package Builders

import (
	"fmt"
	"strings"
)

type HttpUriBuilder struct {
	baseUrl     string
	paths       []string
	queryParams map[string]string
}

func NewHttpUriBuilder(baseUrl string) *HttpUriBuilder {
	return &HttpUriBuilder{
		baseUrl:     baseUrl,
		paths:       make([]string, 0),
		queryParams: make(map[string]string),
	}
}

func (h *HttpUriBuilder) AddPath(path string) *HttpUriBuilder {
	h.paths = append(h.paths, path)
	return h
}

func (h *HttpUriBuilder) AddQueryParam(key string, value string) *HttpUriBuilder {
	h.queryParams[key] = value
	return h
}

func (h *HttpUriBuilder) Build() string {
	paths := strings.Join(h.paths, "/")

	if len(h.queryParams) == 0 {
		return fmt.Sprintf("%s/%s", h.baseUrl, paths)
	}

	var qParams []string
	for k, v := range h.queryParams {
		qParams = append(qParams, fmt.Sprintf("%s=%s", k, v))
	}
	return fmt.Sprintf("%s/%s?%s", h.baseUrl, paths, strings.Join(qParams, "&"))
}
