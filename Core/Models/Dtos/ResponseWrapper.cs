using System.Text.Json.Serialization;

namespace fnbs.Core.Models.Dtos;

public class ResponseWrapper<T>
{
    public T data { get; set; }
    public string message { get; set; } = "";
    public bool success { get; set; } = true;
    public int statusCode { get; set; } = 200;
    public string correlationID { get; set; } = Guid.NewGuid().ToString();


    // Infos gerais para o log;

    [JsonIgnore] private string error { get; set; }


    public void SetSuccessStatus()
    {
        if (this.statusCode >= 400 && this.statusCode < 200)
            this.success = false;
    }

    public class Builder
    {
        private ResponseWrapper<T> responseWrapper;

        public Builder()
        {
            responseWrapper = new ResponseWrapper<T> { };
        }

        public Builder SetStatus(int status)
        {
            responseWrapper.statusCode = status;
            return this;
        }

        public Builder SetData(T data)
        {
            responseWrapper.data = data;
            return this;
        }

        public Builder SetMessage(string message)
        {
            responseWrapper.message = message;
            return this;
        }

        public Builder SetSuccess(bool success)
        {
            responseWrapper.success = success;
            return this;
        }

        public Builder SetCorrelationID(string correlationID)
        {
            responseWrapper.correlationID = correlationID;
            return this;
        }

        //   public Builder SetLogId(int logId)
        //   {
        //     responseWrapper.LogId = logId;
        //     return this;
        //   }
        public Builder SetError(string error)
        {
            responseWrapper.error = error;
            return this;
        }


        public ResponseWrapper<T> Build()
        {
            responseWrapper.SetSuccessStatus();
            return responseWrapper;
        }
    }
}