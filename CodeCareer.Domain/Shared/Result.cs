﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Shared
{
    public class Result
    {
        public bool Success { get; init; }
        [JsonIgnore]
        public bool Failure => !Success;
        public Error Error { get; }

        protected Result(bool success, Error error)
        {
            if (success && error != Error.None || !success && error == Error.None)
            {
                throw new ArgumentException("Invalid", nameof(error));
            }
            Success = success;
            Error = error;
        }

        public static Result SuccessResult() => new(true, Error.None);

        public static Result FailureResult(Error error) => new(false, error);
    }

    //using for returning the result of the operation with the data.
    public class Result<T> : Result
    {
        public T? Data { get; init; }

        private Result(bool success, Error error, T? data = default) : base(success, error)
        {
            Data = data;
        }

        public static Result<T> SuccessResult(T data) => new(true, Error.None, data);
        public new static Result<T> FailureResult(Error error) => new(false, error);
    }
}
