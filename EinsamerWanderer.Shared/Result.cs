using System.Collections.Generic;

namespace EinsamerWanderer.Shared
{
    public class Result<Type> : Result where Type : class
    {
        

        public Type Payload { get; private set; }

        public static Result<Type> SuccessData(Type payload) => 
            new Result<Type>{Successfull = true, Payload = payload};
    }


    public class Result
    {
        public bool Successfull { get; protected set; }
        public List<EWErrror> Errors { get; protected set; }

        public static Result Success =>
            new Result { Successfull = true };

        public static Result Failed(List<EWErrror> errors) =>
            new Result {Errors = errors, Successfull = false};
    }

}