﻿namespace Host.Middlewares
{
    public class ErrorResult
    {
        public List<string>? Messages { get; set; } = new();

        public string? Source { get; set; }
        public string? Exception { get; set; }
        public string? ErrorId { get; set; }
        public int StatusCode { get; set; }
    }
}