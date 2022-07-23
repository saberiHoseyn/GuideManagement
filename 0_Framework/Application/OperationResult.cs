﻿namespace Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; } = false;
        public string Message { get; set; }

        public OperationResult()
        {
        }
        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
