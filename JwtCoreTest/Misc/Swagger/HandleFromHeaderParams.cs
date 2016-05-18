using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace JwtCoreTest.Misc.Swagger
{
    /// <summary>
    /// 提供Swagger對應FromHeaderAttribute的資訊顯示
    /// </summary>
    public class HandleFromHeaderParams : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var fromHeaderAttributes = apiDescription.ActionDescriptor.GetParameters()
                .Where(param => param.GetCustomAttributes<FromHeaderAttribute>().Any())
            .ToArray();

            foreach (var headerParam in fromHeaderAttributes)
            {
                var operationParameter = operation.parameters.First(p => p.name == headerParam.ParameterName);

                operationParameter.name = headerParam.ParameterName;
                operationParameter.@in = "header";
                operationParameter.type = "string";
            }

        }
    }
}