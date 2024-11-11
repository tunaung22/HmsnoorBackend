using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class BaseError
{
    // public HttpStatusCode StatusCode { get; set; }

    public String? Code { get; set; }
    public String? Message { get; set; }
    public String? Url { get; set; }
    // [JsonIgnore]
    public Object? Details { get; set; }

    public override string ToString()
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,

        };

        return JsonSerializer.Serialize(this, options);
    }

}
