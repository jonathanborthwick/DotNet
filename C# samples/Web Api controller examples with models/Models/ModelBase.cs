using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Models
{
    abstract public class BaseModel
    {
        private static string TypeModel = "MODELTYPE";
        private static string TypeError = "ERRORTYPE";
        private List<string> Errors = new List<string>();
        private string ModelType { get; set; }
        public BaseModel()
        {
            this.ModelType = TypeModel;
        }
        public void SetErrorType()
        {
            this.ModelType = TypeError;
        }
        public bool IsErrorType()
        {
            return this.ModelType == TypeError;
        }
        public List<string> GetErrors()
        {
            return this.Errors;
        }
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}