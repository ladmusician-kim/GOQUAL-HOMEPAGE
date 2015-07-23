using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public interface IEnvelopeDTO
    {
        ResultTypeDTO ResultType { get; set; }
        string ErrorMessage { get; set; }
        bool IsSucceeded();
        bool IsFailed();
        bool IsResultType(int type);
    }

#if !NET20
#endif
    ////[JsonObject(MemberSerialization.OptIn)]
    public class EnvelopeDTO<T> : IEnvelopeDTO where T : class
    {
        //[JsonProperty]
#if !NET20
#endif
        public ResultTypeDTO ResultType { get; set; }

        //[JsonProperty]
#if !NET20
#endif
        public T ReturnBody { get; set; }

        //[JsonProperty]
#if !NET20
#endif
        public string ErrorMessage { get; set; }

        // Helper functions
        public bool IsSucceeded() { return ResultType == ResultTypeDTO.Success; }

        public bool IsFailed() { return ResultType != ResultTypeDTO.Success; }

        public bool IsResultType(int type) { return ResultType == (ResultTypeDTO)type; }

        //[JsonIgnore]
#if !NET20
#endif
        public T SafeBody
        {
            get
            {
                if (this.IsSucceeded())
                    return ReturnBody;
                else
                    throw new NotImplementedException(ErrorMessage);
            }
        }
    }

#if NET45
    [JsonObject(MemberSerialization.OptIn)]
#endif
    public class EnvelopeDTO_struct<T> : IEnvelopeDTO where T : struct
    {
#if NET45
        [JsonProperty]
#endif
        public ResultTypeDTO ResultType { get; set; }
#if NET45
        [JsonProperty]
#endif
        public T ReturnBody { get; set; }
#if NET45
        [JsonProperty]
#endif
        public string ErrorMessage { get; set; }
        // Helper functions
        public bool IsSucceeded() { return ResultType == ResultTypeDTO.Success; }
        public bool IsFailed() { return ResultType != ResultTypeDTO.Success; }
        public bool IsResultType(int type) { return ResultType == (ResultTypeDTO)type; }

#if NET45
        [JsonIgnore]
#endif
        public T SafeBody
        {
            get
            {
                if (this.IsSucceeded())
                    return ReturnBody;
                else
                    throw new NotImplementedException(ErrorMessage);
            }
        }
    }

    public enum ResultTypeDTO
    {
        Success = 200,
        Fail = 500,
        Exception = 501,
        IntegrityError = 502,
        UsedCoupon = 600,
        NoCoupon = 700,
        Maintenance = 888
    }

    public class GenericDummyDTO { }

    public class GenericIDLabelDTO
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Label { get; set; }
        public DateTime? Paid { get; set; }
        public int Count { get; set; }
    }

    public class ImageDTO
    {
        public byte[] Filedata { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
    }

    public static class EnvelopeDTO
    {
        public static EnvelopeDTO<T> Succeeded<T>(T returnBody = null) where T : class
        {
            return new EnvelopeDTO<T>
            {
                ResultType = ResultTypeDTO.Success,
                ReturnBody = returnBody
            };
        }

        public static EnvelopeDTO<T> Fail<T>(string errorMessage) where T : class
        {
            return new EnvelopeDTO<T>
            {
                ResultType = ResultTypeDTO.Fail,
                ErrorMessage = errorMessage
            };
        }

        public static EnvelopeDTO<T> Fail<T>(int errorType, string errorMessage) where T : class
        {
            return new EnvelopeDTO<T>
            {
                ResultType = (ResultTypeDTO)errorType,
                ErrorMessage = errorMessage
            };
        }

        public static EnvelopeDTO<T> Exception<T>(System.Exception e) where T : class
        {
            if (e.InnerException != null)
            {
                return new EnvelopeDTO<T>
                {
                    ResultType = ResultTypeDTO.Exception,
                    ErrorMessage = e.InnerException.Message
                };
            }
            else
            {
                return new EnvelopeDTO<T>
                {
                    ResultType = ResultTypeDTO.Exception,
                    ErrorMessage = e.Message
                };
            }
        }

        public static EnvelopeDTO<T> IntegrityError<T>() where T : class
        {
            return new EnvelopeDTO<T>
            {
                ResultType = ResultTypeDTO.IntegrityError
            };
        }
    }

    public static class EnvelopeDTO_struct
    {
        public static EnvelopeDTO_struct<T> Succeeded<T>(T returnBody) where T : struct
        {
            return new EnvelopeDTO_struct<T>
            {
                ResultType = ResultTypeDTO.Success,
                ReturnBody = returnBody
            };
        }

        public static EnvelopeDTO_struct<T> Fail<T>(string errorMessage) where T : struct
        {
            return new EnvelopeDTO_struct<T>
            {
                ResultType = ResultTypeDTO.Fail,
                ErrorMessage = errorMessage
            };
        }

        public static EnvelopeDTO_struct<T> Fail<T>(int errorType, string errorMessage) where T : struct
        {
            return new EnvelopeDTO_struct<T>
            {
                ResultType = (ResultTypeDTO)errorType,
                ErrorMessage = errorMessage
            };
        }

        public static EnvelopeDTO_struct<T> Exception<T>(System.Exception e) where T : struct
        {
            if (e.InnerException != null)
            {
                return new EnvelopeDTO_struct<T>
                {
                    ResultType = ResultTypeDTO.Exception,
                    ErrorMessage = e.InnerException.Message
                };
            }
            else
            {
                return new EnvelopeDTO_struct<T>
                {
                    ResultType = ResultTypeDTO.Exception,
                    ErrorMessage = e.Message
                };
            }
        }

        public static EnvelopeDTO_struct<T> IntegrityError<T>() where T : struct
        {
            return new EnvelopeDTO_struct<T>
            {
                ResultType = ResultTypeDTO.IntegrityError
            };
        }
    }
}