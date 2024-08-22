﻿using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    internal class ResponseModelServicesDto<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Messages { get; set; }
        public T Result { get; set; }
    }
}