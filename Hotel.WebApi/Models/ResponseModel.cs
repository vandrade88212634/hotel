﻿using System.Diagnostics.CodeAnalysis;

namespace  Hotel.WebApi.Models
{
    [ExcludeFromCodeCoverage]
    public class ResponseModel<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Messages { get; set; }
        public T Result { get; set; }
    }
}